using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;

public class translatemeyamosso
{
    private translatemeyamosso()
    {
    }

    public static string GetResourceValuemosso(string keyVal)
    {
        if (!string.IsNullOrEmpty(keyVal))
        {
            string AppCultureUInow = Left[LCase[Thread.CurrentThread.CurrentUICulture.Name], 2];
            return CheckTranslateen(keyVal, AppCultureUInow);
        }
        else
        {
            return keyVal;
        }
    }

    public static string GetResourcemosso(string keyVal)
    {
        // 'url="~/Pages/Homecar.aspx"

        if (string.IsNullOrEmpty(keyVal) | string.IsNullOrWhiteSpace(keyVal))
        {
            return myvirtualpathfun() + "images/dashboard/10001.png";
        }
        else
        {
            string urlfilanl = keyVal;
            urlfilanl = Path.GetFileName(urlfilanl);
            // ' urlfilanl = Left(urlfilanl, Len(urlfilanl) - 5)
            if (IsNothing[ConfigurationManager.AppSettings["imagepath"]] == false)
            {
                urlfilanl = ConfigurationManager.AppSettings["imagepath"].ToString() + "/images/dashboard/" + urlfilanl + ".png";
                if (File.Exists(urlfilanl))
                {
                    return urlfilanl;
                }
                else
                {
                    return myvirtualpathfun() + "images/dashboard/10001.png";
                }
            }
            else
            {
                string filpathe = MyMapPath("/images/dashboard");
                if (File.Exists(filpathe + @"\" + urlfilanl + ".png"))
                {
                    urlfilanl = myvirtualpathfun() + "images/dashboard/" + urlfilanl + ".png";
                    return urlfilanl;
                }
                else
                {
                    return myvirtualpathfun() + "images/dashboard/10001.png";
                }
            }
        }
    }

    public static string myvirtualpathfun()
    {
        string myvirtualpath = "";
        if (HttpContext.Current.Request.ApplicationPath == "/")
        {
            myvirtualpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpContext.Current.Request.ApplicationPath;
        }
        else
        {
            myvirtualpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpContext.Current.Request.ApplicationPath + "/";
        }

        return myvirtualpath;
    }

    public static string MyMapPath(string path)
    {
        if (HttpContext.Current.Request.ApplicationPath == "/")
        {
        }
        else
        {
            path = HttpContext.Current.Request.ApplicationPath + path;
        }

        return HttpContext.Current.Server.MapPath(path);
    }
    // Variable used to prevent infinite loop
    public static string GetResourcemosso1(string AppRelativeTemplateSourceDirectory, string AppRelativeVirtualPath)
    {
        // 'url="~/Pages/Homecar.aspx"

        if (string.IsNullOrEmpty(AppRelativeTemplateSourceDirectory) | string.IsNullOrWhiteSpace(AppRelativeTemplateSourceDirectory))
        {
            return "../images/dashboard/10001.png";
        }
        else
        {
            string urlfilanl = Right[AppRelativeVirtualPath, Len[AppRelativeVirtualPath] - Len[AppRelativeTemplateSourceDirectory] + 1];
            urlfilanl = Left[urlfilanl, Len[urlfilanl] - 5];
            string appDirectory = HttpContext.Current.Server.MapPath("~");
            if (File.Exists(appDirectory + @"\images\dashboard\" + urlfilanl + ".png"))
            {
                urlfilanl = "../images/dashboard/" + urlfilanl + ".png";
                return urlfilanl;
            }
            else
            {
                return "../images/dashboard/10001.png";
            }
        }
    }

    public static string GetVirtualPath(string physicalPath)
    {
        string rootpath = HttpContext.Current.Server.MapPath("~/");
        physicalPath = physicalPath.Replace(rootpath, "");
        physicalPath = physicalPath.Replace(@"\\", "/");
        return "~/" + physicalPath;
    }

    public static string GetResourceValue(string keyVal, string appName)
    {
        if (!string.IsNullOrEmpty(keyVal))
        {
            string AppCultureUInow = UCase[Thread.CurrentThread.CurrentUICulture.Name];
            return CheckTranslateen(keyVal, AppCultureUInow);
        }
        else
        {
            return keyVal;
        }
    }

    public static string GetResourceValue(string keyVal)
    {
        if (!string.IsNullOrEmpty(keyVal))
        {
            string AppCultureUInow = LCase[Thread.CurrentThread.CurrentUICulture.Name];
            return CheckTranslateen(keyVal, AppCultureUInow);
        }
        else
        {
            return keyVal;
        }
    }

    public static string CheckTranslatear(string varclass)
    {
        try
        {
            if (HttpContext.Current.Session("TransaltsystemList") is object)
            {
                var dt = new DataTable();
                dt = (DataTable)HttpContext.Current.Session("TransaltsystemList");
                string filterExp = "contolname = '" + Trim[varclass] + "'";
                string sortExp = "contolname";
                DataRow[] drarray;
                int i;
                drarray = dt.Select(filterExp, sortExp, DataViewRowState.CurrentRows);
                var loopTo = drarray.Length - 1;
                for (i = 0; i <= loopTo; i++)
                    return drarray[i]["ar"].ToString();
            }
            else
            {
                using (var mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ezee"].ToString()))
                {
                    try
                    {
                        // ------------------------------------------------
                        string strSql = "select rtrim(ltrim(contolname)) as contolname,en,ar from Transaltsystem";
                        var ds1 = new DataSet();
                        var da1 = new SqlDataAdapter();
                        da1.SelectCommand = new SqlCommand(strSql, mySqlConnection);
                        da1.Fill(ds1);
                        if (ds1 is object && ds1.Tables.Count > 0)
                        {
                            System.Web.HttpContext.Current.Session["TransaltsystemList"] = ds1.Tables[0];
                        }
                        else
                        {
                            System.Web.HttpContext.Current.Session["TransaltsystemList"] = null;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        if (mySqlConnection.State == ConnectionState.Open)
                            mySqlConnection.Close();
                    }
                }

                if (HttpContext.Current.Session("TransaltsystemList") is object)
                {
                    var dt = new DataTable();
                    dt = (DataTable)HttpContext.Current.Session("TransaltsystemList");
                    string filterExp = "contolname = '" + Trim[varclass] + "'";
                    string sortExp = "contolname";
                    DataRow[] drarray;
                    int i;
                    drarray = dt.Select(filterExp, sortExp, DataViewRowState.CurrentRows);
                    var loopTo1 = drarray.Length - 1;
                    for (i = 0; i <= loopTo1; i++)
                        return drarray[i]["ar"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
        }

        return varclass;
    }

    public static string CheckTranslateen(string varclass, string AppCultureUInow)
    {
        try
        {
            if (HttpContext.Current.Session("TransaltsystemList") is object)
            {
                var dt = new DataTable();
                dt = (DataTable)HttpContext.Current.Session("TransaltsystemList");
                string filterExp = "contolname = '" + Trim[varclass] + "'";
                string sortExp = "contolname";
                DataRow[] drarray;
                int i;
                string transresult = "";
                drarray = dt.Select(filterExp, sortExp, DataViewRowState.CurrentRows);
                var loopTo = drarray.Length - 1;
                for (i = 0; i <= loopTo; i++)
                {
                    transresult = drarray[i][AppCultureUInow].ToString();
                    if (Len[Trim[transresult]] > 0)
                    {
                        return transresult;
                    }
                    else
                    {
                        return varclass;
                    }
                }
            }
            else
            {
                using (var mySqlConnection = new SqlConnection(global::eZee.Data.ConnectionStringSettingsFactory.Create("ezee").ConnectionString))
                {
                    try
                    {
                        // ------------------------------------------------
                        string strSql = "select rtrim(ltrim(contolname)) as contolname,* from Transaltsystem";
                        var ds1 = new DataSet();
                        var da1 = new SqlDataAdapter();
                        da1.SelectCommand = new SqlCommand(strSql, mySqlConnection);
                        da1.Fill(ds1);
                        if (ds1 is object && ds1.Tables.Count > 0)
                        {
                            System.Web.HttpContext.Current.Session["TransaltsystemList"] = ds1.Tables[0];
                        }
                        else
                        {
                            System.Web.HttpContext.Current.Session["TransaltsystemList"] = null;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        if (mySqlConnection.State == ConnectionState.Open)
                            mySqlConnection.Close();
                    }
                }

                if (HttpContext.Current.Session("TransaltsystemList") is object)
                {
                    var dt = new DataTable();
                    dt = (DataTable)HttpContext.Current.Session("TransaltsystemList");
                    string filterExp = "contolname = '" + Trim[varclass] + "'";
                    string sortExp = "contolname";
                    DataRow[] drarray;
                    int i;
                    string transresult = "";
                    drarray = dt.Select(filterExp, sortExp, DataViewRowState.CurrentRows);
                    var loopTo1 = drarray.Length - 1;
                    for (i = 0; i <= loopTo1; i++)
                    {
                        transresult = drarray[i][AppCultureUInow].ToString();
                        if (Len[transresult] > 0)
                        {
                            return transresult;
                        }
                        else
                        {
                            return varclass;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }

        return varclass;
    }
}