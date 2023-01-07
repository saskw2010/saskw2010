using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using Microsoft.VisualBasic.CompilerServices;

namespace eZee.Rules
{
    public partial class SharedBusinessRules : eZee.Data.BusinessRules
    {
        public string getmyreferance()
        {
            if (IsNothing[HttpContext.Current.Session.Item("sgm")] == false)
            {
                using (var calc = new eZee.Data.SqlText("select max(ReferanceNo) " + "from [schvchReferancno] where sgm=@sgm"))
                {
                    calc.AddParameter("@sgm", (Int64)HttpContext.Current.Session.Item("sgm"));
                    var total = calc.ExecuteScalar();
                    if (DBNull.Value.Equals(total))
                    {
                        return "1";
                    }
                    else
                    {
                        return Convert.ToDecimal(total) + 1;
                    }
                }
            }
            else
            {
                return "0";
            }
        }

        public string getuseremail()
        {
            MembershipUser user = Membership.GetUser(eZee.Data.BusinessRulesBase.UserName);
            // Dim user As newmembership = newmembership.SelectSingle(newUser.ProviderUserKey)
            if (user is object)
            {
                string userApplicationId1;
                userApplicationId1 = user.Email;
                return userApplicationId1;
            }
            else
            {
                return "   _no_n0_name////   ";
            }
        }
        // <ControllerAction(, "editForm1", "Update", ActionPhase.Before)>
        // Public Sub AssignFieldValuesToschApplicationedit()

        // Result.ShowMessage("Custom:   " & args.CommandName)

        // Dim Requestsx As New PageRequest
        // Requestsx.Controller = args.Controller
        // Requestsx.View = args.View
        // Requestsx.SortExpression = args.SortExpression
        // If (Not (args.Filter) Is Nothing) Then
        // 'Dim dve As eZee.Web.DataViewExtender = New DataViewExtender()
        // 'dve.AssignStartupFilter(args.Filter)
        // Requestsx.Filter = args.Filter.ToArray()
        // End If
        // Request.PageSize = Int32.MaxValue
        // Request.RequiresRowCount = True
        // Request.RequiresMetaData = True
        // Dim page As ViewPage = ControllerFactory.CreateDataController.GetPage(Requestsx.Controller, Requestsx.View, Requestsx)
        // Dim tablerequestreport1 As DataTable = page.ToDataTable()
        // 'context.Session("tablerequestreport") = tablerequestreport1
        // Dim appDirectory1 As String = HttpContext.Current.Server.MapPath("~")
        // Dim username As String
        // Dim timestampstring As String
        // username = HttpContext.Current.User.Identity.Name()
        // timestampstring = System.DateTime.Now.ToString("yyyyMMddHHmmss")
        // Dim mydocpath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        // Dim reportFileNamemossopath As String = appDirectory1 + "\Reportsdata\" ' mydocpath
        // Dim reportFileNamemosso As String = "mostafaxlml" + username + timestampstring
        // 'Dim writer = New XmlTextWriter(@"C:\test.xml", encoding.)
        // Dim utfencoder As Encoding = UTF8Encoding.GetEncoding("UTF-8", New EncoderReplacementFallback(""), New DecoderReplacementFallback(""))
        // Dim sbWrite As New StringBuilder()
        // Dim strWrite As New StringWriter(sbWrite)
        // Dim xmlWrite As New CustomXmlWriter(reportFileNamemossopath + reportFileNamemosso + ".xml", UTF8Encoding.GetEncoding("UTF-8", New EncoderReplacementFallback(""), New DecoderReplacementFallback("")))

        // tablerequestreport1.WriteXml(xmlWrite, System.Data.XmlWriteMode.WriteSchema)

        // xmlWrite.Flush()
        // xmlWrite.Close()

        // End If
        // End Sub


        protected override void AfterSqlAction(eZee.Data.ActionArgs args, eZee.Data.ActionResult result)
        {
            if (result.Errors.Count == 0 & (base.Arguments.CommandName ?? "") == "Update" | (base.Arguments.CommandName ?? "") == "Report" | (base.Arguments.CommandName ?? "") == "Insert" | (base.Arguments.CommandName ?? "") == "Delete")
            {
                var dbinerto = new global::dblayer();
                bool xinsert;
                xinsert = dbinerto.Insert("insert into webuserlog([username] ,[controllername]  ,[viewnm]  ,[Actionnm] ,[Actionargument]) values ('" + HttpContext.Current.User.Identity.Name + "','" + args.Controller + "','" + args.View + "','" + base.Arguments.CommandName + "','" + base.Arguments.CommandArgument + "')");
                result.Continue();
            }
        }

        protected override void ExecuteAction(eZee.Data.ActionArgs args, eZee.Data.ActionResult result)
        {
            if ((args.CommandName ?? "") == "Report")
            {
                result.ShowMessage("Report" + args.CommandName);
            }
            else if ((args.CommandName ?? "") == "Custom")
            {
                result.ShowMessage("Custom:   " + args.CommandName);
            }
        }

        public static DataTable getdatatable(string argsController, string argsView, string argfilter)
        {
            var Request = new eZee.Data.PageRequest();
            Request.Controller = argsController;
            string[] mArr;
            mArr = Split[argfilter, "-mos//tafa//-"];
            Request.Filter = mArr;
            Request.ExternalFilter = null;
            Request.View = argsView;
            Request.SortExpression = null;
            Request.PageSize = 1000000;
            Request.RequiresRowCount = true;
            Request.RequiresMetaData = true;
            var page = eZee.Data.ControllerFactory.CreateDataController().GetPage(argsController, argsView, Request);
            var table = page.ToDataTable();
            return table;
        }

        public static DataTable getdatatable2016()
        {
            var Request = new eZee.Data.PageRequest();
            Request.Controller = eZee.Data.ActionArgs.Current.Controller;
            Request.Filter = eZee.Data.ActionArgs.Current.Filter;
            Request.ExternalFilter = eZee.Data.ActionArgs.Current.ExternalFilter;
            Request.View = eZee.Data.ActionArgs.Current.View;
            Request.SortExpression = eZee.Data.ActionArgs.Current.SortExpression;
            Request.PageSize = 10000000;
            Request.RequiresRowCount = true;
            Request.RequiresMetaData = true;
            var page = eZee.Data.ControllerFactory.CreateDataController().GetPage(eZee.Data.ActionArgs.Current.Controller, eZee.Data.ActionArgs.Current.View, Request);
            var table = page.ToDataTable();
            // Dim appDirectory1 As String = HttpContext.Current.Server.MapPath("~")
            // Dim username As String
            // Dim timestampstring As String
            // username = HttpContext.Current.User.Identity.Name()
            // timestampstring = System.DateTime.Now.ToString("yyyyMMddHHmmss")
            // Dim reportFileName As String = appDirectory1 + "\Reports\mostafaxlml" + username + timestampstring + ".xml"
            // table.WriteXml(reportFileName, System.Data.XmlWriteMode.IgnoreSchema)
            // Dim reportFileName1 As String = appDirectory1 + "\Reports\mostafaxlml" + username + timestampstring + ".xsd"
            // table.WriteXmlSchema(reportFileName1)
            return table;
        }

        protected override void EnumerateDynamicAccessControlRules(string controllerName)
        {
            if (base.IsTagged("searchme"))
            {
                if (IsNothing[base.Context.Session["HomePhoneText"]] | string.IsNullOrEmpty(Conversions.ToString(base.Context.Session["HomePhoneText"])))
                {
                    base.Context.Session["HomePhoneText"] = "0";
                }

                if (IsNothing[base.Context.Session["HomePhoneText"]] | string.IsNullOrEmpty(Conversions.ToString(base.Context.Session["HomePhoneText"])))
                {
                }
                else
                {
                    switch (controllerName) // check table then put it or no by select from informationschema where table 
                    {
                        case "TblAppointments":
                            {
                                base.RegisterAccessControlRule("IDATUTO", "IDATUTO in(select IDATUTO from TblAppointments where HomePhone=@HomePhone OR MobilePhone=@MobilePhone )", eZee.Data.AccessPermission.Allow, new eZee.Data.SqlParam("@HomePhone", base.Context.Session["HomePhoneText"]), new eZee.Data.SqlParam("@MobilePhone", base.Context.Session["HomePhoneText"]));
                                break;
                            }

                        // Case "TblAppointmentsArchive"
                        // RegisterAccessControlRule("Archivid", "Archivid in(select Archivid from TblAppointmentsArchive where HomePhone=@HomePhone OR MobilePhone=@MobilePhone )", AccessPermission.Allow,
                        // New SqlParam("@HomePhone", Context.Session("HomePhoneText")), New SqlParam("@MobilePhone", Context.Session("HomePhoneText")))
                        // Case "Tbl_ArchAppoint"
                        // RegisterAccessControlRule("ArchAppointAutoid", "ArchAppointAutoid in(select ArchAppointAutoid from Tbl_ArchAppoint where HomePhone=@HomePhone OR MobilePhone=@MobilePhone )", AccessPermission.Allow,
                        // New SqlParam("@HomePhone", Context.Session("HomePhoneText")), New SqlParam("@MobilePhone", Context.Session("HomePhoneText")))

                        // ---------------------------------------------------
                        case "HomePhoneliststatus":
                            {
                                base.RegisterAccessControlRule("HomePhonelook", "HomePhonelook=@HomePhone", eZee.Data.AccessPermission.Allow, new eZee.Data.SqlParam("@HomePhone", base.Context.Session["HomePhoneText"]));
                                break;
                            }

                        case "TblCustomers":
                            {
                                // Case "TblCustomersArchive"
                                // RegisterAccessControlRule("Archiveidauo", "Archiveidauo in(select Archiveidauo from TblCustomersArchive where HomePhone=@HomePhone OR MobilePhone=@MobilePhone OR Workphone=@Workphone )", AccessPermission.Allow,
                                // New SqlParam("@HomePhone", Context.Session("HomePhoneText")), New SqlParam("@MobilePhone", Context.Session("HomePhoneText")), New SqlParam("@Workphone", Context.Session("HomePhoneText")))

                                // Case "Tbl_ArchCustomers"
                                // RegisterAccessControlRule("Rainbow_no", "Rainbow_no in(select Rainbow_no from Tbl_ArchCustomers where HomePhone=@HomePhone OR MobilePhone=@MobilePhone OR Workphone=@Workphone )", AccessPermission.Allow,
                                // New SqlParam("@HomePhone", Context.Session("HomePhoneText")), New SqlParam("@MobilePhone", Context.Session("HomePhoneText")), New SqlParam("@Workphone", Context.Session("HomePhoneText")))



                                base.RegisterAccessControlRule("Rainbow_no", "Rainbow_no in(select Rainbow_no from TblCustomers where HomePhone=@HomePhone OR MobilePhone=@MobilePhone OR Workphone=@Workphone )", eZee.Data.AccessPermission.Allow, new eZee.Data.SqlParam("@HomePhone", base.Context.Session["HomePhoneText"]), new eZee.Data.SqlParam("@MobilePhone", base.Context.Session["HomePhoneText"]), new eZee.Data.SqlParam("@Workphone", base.Context.Session["HomePhoneText"]));
                                break;
                            }

                        default:
                            {
                                break;
                            }
                    }
                }
            }
            // AddTag("UserIsInformed")




            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (base.UserIsInRole("Administrator"))
                {
                }
                // UnrestrictedAccess()
                else if (base.UserIsInRole("Administrators"))
                {
                    base.RegisterAccessControlRule("CompanyAccount", "CompanyAccount=@CompanyAccount", eZee.Data.AccessPermission.Allow, new eZee.Data.SqlParam("@CompanyAccount", Companycode()));
                    base.RegisterAccessControlRule("RoleName", "RoleName=@RoleName", eZee.Data.AccessPermission.Deny, new eZee.Data.SqlParam("@RoleName", "Administrator"));
                }
                else
                {
                    base.RegisterAccessControlRule("CompanyAccount", "CompanyAccount=@CompanyAccount", eZee.Data.AccessPermission.Allow, new eZee.Data.SqlParam("@CompanyAccount", Companycode()));
                    base.RegisterAccessControlRule("RoleName", "RoleName=@RoleName", eZee.Data.AccessPermission.Deny, new eZee.Data.SqlParam("@RoleName", "Administrator"));
                    base.RegisterAccessControlRule("activeflage", "activeflage=@activeflage", eZee.Data.AccessPermission.Deny, new eZee.Data.SqlParam("@activeflage", 0));
                    base.RegisterAccessControlRule("activeflageD", "activeflageD=@activeflageD", eZee.Data.AccessPermission.Deny, new eZee.Data.SqlParam("@activeflageD", 0));
                    base.RegisterAccessControlRule("activeflagetele", "activeflagetele=@activeflagetele", eZee.Data.AccessPermission.Deny, new eZee.Data.SqlParam("@activeflagetele", 0));
                    base.RegisterAccessControlRule("activeflageserviced", "activeflageserviced=@activeflageserviced", eZee.Data.AccessPermission.Deny, new eZee.Data.SqlParam("@activeflageserviced", 0));
                    switch (controllerName) // check table then put it or no by select from informationschema where table 
                    {
                        case "schApplication1001":
                        case "schApplication1002":
                            {
                                if (string.IsNullOrEmpty(getThebranchDesc1("schApplication")))
                                {
                                }
                                else
                                {
                                    base.RegisterAccessControlRule("branch", getThebranchDesc1("schApplication"), eZee.Data.AccessPermission.Allow);
                                }

                                break;
                            }

                        case "EVOL_Memo":
                            {
                                RegisterAccessControlRule("ID", " EVOL_Memo.ID in (select id from EVOLMemo where UserName=@UserName)", eZee.Data.AccessPermission.Allow, new eZee.Data.SqlParam("@UserName", HttpContext.Current.User.Identity.Name));
                                break;
                            }

                        default:
                            {
                                if (string.IsNullOrEmpty(getThebranchDesc1(controllerName)))
                                {
                                }
                                else
                                {
                                    base.RegisterAccessControlRule("branch", getThebranchDesc1(controllerName), eZee.Data.AccessPermission.Allow);
                                }

                                if (string.IsNullOrEmpty(getThebranchDesc1sgm(controllerName)))
                                {
                                }
                                else
                                {
                                    base.RegisterAccessControlRule("sgm", getThebranchDesc1sgm(controllerName), eZee.Data.AccessPermission.Allow);
                                }

                                break;
                            }
                    }
                }
            }
        }

        public string getsgmusername()
        {
            string myIntsgm = HttpContext.Current.User.Identity.Name;
            if (string.IsNullOrEmpty(myIntsgm))
            {
                return "   _";
            }
            else
            {
                return myIntsgm;
            }
        }

        public string getmycashaccount()
        {
            string myIntsgm = 1.ToString(); // HttpContext.Current.User.Identity.Name
            if (string.IsNullOrEmpty(myIntsgm))
            {
                return "   _";
            }
            else
            {
                return myIntsgm;
            }
        }

        public string getmysalesaccount()
        {
            string myIntsgm = 1.ToString(); // HttpContext.Current.User.Identity.Name
            if (string.IsNullOrEmpty(myIntsgm))
            {
                return "   _";
            }
            else
            {
                return myIntsgm;
            }
        }

        public string getmyfirstbranch()
        {
            string myIntsgm = 1.ToString();
            if (base.UserIsInRole("Administrator") | base.UserIsInRole("Administrators"))
            {
                return myIntsgm;
            }
            else
            {
                using (var calc = new eZee.Data.SqlText("select Top(1) brn_no from QUserdetailsegmentbrnch where UserName='" + HttpContext.Current.User.Identity.Name + "'"))
                {
                    var total = calc.ExecuteScalar();
                    if (DBNull.Value.Equals(total))
                    {
                        myIntsgm = 1.ToString();
                    }
                    else
                    {
                        myIntsgm = Convert.ToDecimal(total).ToString;
                    }
                }

                return myIntsgm;
            }
        }

        public string Companycode()
        {
            string myInt = HttpContext.Current.Session("nameofmycompany");
            if (string.IsNullOrEmpty(myInt))
            {
                return "   _";
            }
            else
            {
                return myInt;
            }
        }

        public string getThebranchDesc1sgm(string controllerName)
        {
            string getThebranchDesc1sgmRet = default;
            if (IsNothing[HttpContext.Current.Session("getThebranchDesc1sgm")] | string.IsNullOrEmpty(HttpContext.Current.Session("getThebranchDesc1sgm")))
            {
                getThebranchDesc1sgmRet = "";
                using (var mySqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["eZee"].ToString()))
                {
                    try
                    {
                        // ------------------------------------------------
                        string strSql = "select * from Userdetailsegmentsgm where UserName='" + HttpContext.Current.User.Identity.Name + "'";
                        var ds1 = new DataSet();
                        var da1 = new SqlDataAdapter();
                        da1.SelectCommand = new SqlCommand(strSql, mySqlConnection);
                        da1.Fill(ds1);
                        if (ds1 is object && ds1.Tables.Count > 0)
                        {
                            string satot = "";
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow idatarow in ds1.Tables[0].Rows)
                                {
                                    if (string.IsNullOrEmpty(satot))
                                    {
                                        // satot = controllerName & ".branch=" & idatarow.Item("branch") & ""
                                        satot = Conversions.ToString(" sgm=" + idatarow["sgm"] + "");
                                    }
                                    else
                                    {
                                        // satot = satot & " OR " & controllerName & ".branch=" & idatarow.Item("branch") & ""
                                        satot = Conversions.ToString(satot + " OR " + "sgm=" + idatarow["sgm"] + "");
                                    }
                                }

                                satot = " Select sgm from glmulcmp where sgm=0 OR " + satot;
                                HttpContext.Current.Session("getThebranchDesc1sgm") = satot;
                                return satot;
                            }

                            HttpContext.Current.Session("getThebranchDesc1sgm") = satot;
                            return satot;
                        }
                        else
                        {
                            HttpContext.Current.Session("getThebranchDesc1sgm") = getThebranchDesc1sgmRet;
                            return getThebranchDesc1sgmRet;
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
            }
            else
            {
                return HttpContext.Current.Session("getThebranchDesc1sgm");
            }

            return getThebranchDesc1sgmRet;
        }

        public string getThebranchDesc1(string controllerName)
        {
            string getThebranchDesc1Ret = default;
            if (IsNothing[HttpContext.Current.Session("getThebranchDesc1")] | string.IsNullOrEmpty(HttpContext.Current.Session("getThebranchDesc1")))
            {
                getThebranchDesc1Ret = "";
                using (var mySqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["eZee"].ToString()))
                {
                    try
                    {
                        // ------------------------------------------------
                        string strSql = "select * from Userdetailsegment where UserName='" + HttpContext.Current.User.Identity.Name + "'";
                        var ds1 = new DataSet();
                        var da1 = new SqlDataAdapter();
                        da1.SelectCommand = new SqlCommand(strSql, mySqlConnection);
                        da1.Fill(ds1);
                        if (ds1 is object && ds1.Tables.Count > 0)
                        {
                            string satot = "";
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow idatarow in ds1.Tables[0].Rows)
                                {
                                    if (string.IsNullOrEmpty(satot))
                                    {
                                        // satot = controllerName & ".branch=" & idatarow.Item("branch") & ""
                                        satot = Conversions.ToString(" branch=" + idatarow["branch"] + "");
                                    }
                                    else
                                    {
                                        // satot = satot & " OR " & controllerName & ".branch=" & idatarow.Item("branch") & ""
                                        satot = Conversions.ToString(satot + " OR " + "branch=" + idatarow["branch"] + "");
                                    }
                                }

                                satot = " Select branch from schbranch where branch=0 OR " + satot;
                                HttpContext.Current.Session("getThebranchDesc1") = satot;
                                return satot;
                            }

                            HttpContext.Current.Session("getThebranchDesc1") = satot;
                            return satot;
                        }
                        else
                        {
                            HttpContext.Current.Session("getThebranchDesc1") = getThebranchDesc1Ret;
                            return getThebranchDesc1Ret;
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
            }
            else
            {
                return HttpContext.Current.Session("getThebranchDesc1");
            }

            return getThebranchDesc1Ret;
        }

        public string getsgm()
        {
            using (var mySqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["eZee"].ToString()))
            {
                try
                {
                    // ------------------------------------------------
                    string strSql = "select * from Quserdetailesegment where UserName='" + HttpContext.Current.User.Identity.Name + "'";
                    var ds1 = new DataSet();
                    var da1 = new SqlDataAdapter();
                    da1.SelectCommand = new SqlCommand(strSql, mySqlConnection);
                    da1.Fill(ds1);
                    if (ds1 is object && ds1.Tables.Count > 0)
                    {
                        string satot = "";
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow idatarow in ds1.Tables[0].Rows)
                                satot = Conversions.ToString(satot + idatarow["branch"] + ",");  // "','"
                        }

                        if (Right[satot, 1] == ",")
                        {
                            satot = Left[satot, Len[satot] - 1];
                        }

                        if (Len[satot] == 1)
                        {
                            System.Web.HttpContext.Current.Session["getsgm"] = null;
                        }
                        else
                        {
                            System.Web.HttpContext.Current.Session["getsgm"] = satot;
                        }
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Session["getsgm"] = null;
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

            string myIntsgm = HttpContext.Current.Session("getsgm");
            if (string.IsNullOrEmpty(myIntsgm))
            {
                return "0";
            }
            else
            {
                return myIntsgm;
            }
        }

        // Public Function userApplicationId() As String

        // Dim newUser As MembershipUser = Membership.GetUser(UserName)
        // Dim user As newmembership = newmembership.SelectSingle(newUser.ProviderUserKey)
        // If (Not (user) Is Nothing) Then
        // Dim userApplicationId1 As String
        // userApplicationId1 = user.Email
        // Return userApplicationId1
        // Else
        // Return "   _no_n0_name////   "
        // End If
        // End Function
        public bool checkNewrole(string controllerNamestr)
        {
            try
            {
                using (var mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString))
                {
                    try
                    {



                        // ------------------------------------------------
                        string strSql = "select insertAction  from vwaspnetpageforUsers where insertAction=0 and   UserName='" + HttpContext.Current.User.Identity.Name + "' and tablo='" + controllerNamestr + "'";
                        var ds1 = new DataSet();
                        var da1 = new SqlDataAdapter();
                        da1.SelectCommand = new SqlCommand(strSql, mySqlConnection);
                        da1.Fill(ds1);
                        if (ds1 is object && ds1.Tables[0].Rows.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                    finally
                    {
                        if (mySqlConnection.State == ConnectionState.Open)
                            mySqlConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool checkeditrole(string controllerNamestr)
        {
            try
            {
                using (var mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString))
                {
                    try
                    {

                        // ------------------------------------------------
                        string strSql = "select updateAction  from vwaspnetpageforUsers where updateAction=0 and   UserName='" + HttpContext.Current.User.Identity.Name + "' and tablo='" + controllerNamestr + "'";
                        var ds1 = new DataSet();
                        var da1 = new SqlDataAdapter();
                        da1.SelectCommand = new SqlCommand(strSql, mySqlConnection);
                        da1.Fill(ds1);
                        if (ds1 is object && ds1.Tables[0].Rows.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                    finally
                    {
                        if (mySqlConnection.State == ConnectionState.Open)
                            mySqlConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool checkdeleterole(string controllerNamestr)
        {
            try
            {
                using (var mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString))
                {
                    try
                    {
                        // ------------------------------------------------
                        string strSql = "select deleteAction  from vwaspnetpageforUsers where deleteAction=0 and   UserName='" + HttpContext.Current.User.Identity.Name + "' and tablo='" + controllerNamestr + "'";
                        var ds1 = new DataSet();
                        var da1 = new SqlDataAdapter();
                        da1.SelectCommand = new SqlCommand(strSql, mySqlConnection);
                        da1.Fill(ds1);
                        if (ds1 is object && ds1.Tables[0].Rows.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                    finally
                    {
                        if (mySqlConnection.State == ConnectionState.Open)
                            mySqlConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override bool SupportsVirtualization(string controllerName)
        {
            return true;    // Not UserIsInRole("Administrators")
        }

        protected override void VirtualizeController(string controllerName)
        {
            // NodeSet().SelectActions("ReportAsWord", "ReportAsPdf", "ReportAsImage", "ExportRss", "DataSheet", "Grid").Delete()


            if (base.UserIsInRole("ReportAsExcel"))
            {
            }
            else
            {
                base.NodeSet().SelectActions("ReportAsExcel").Delete();
                base.NodeSet().SelectActions("ExportCsv").Delete();
            }

            if (base.UserIsInRole("ExportRowset"))
            {
            }
            else
            {
                base.NodeSet().SelectActions("ExportRowset").Delete();
            }

            if (base.UserIsInRole("Import"))
            {
            }
            else
            {
                base.NodeSet().SelectActions("Import").Delete();
            }

            if (base.UserIsInRole("Administrator"))
            {
            }
            // NodeSet().SelectActions("ReportAsWord", "ReportAsPdf", "ReportAsImage").Delete()
            // If UserIsInRole("exportexcel") Then
            // NodeSet().SelectActions("ReportAsWord", "ReportAsPdf", "ReportAsImage").Delete()
            // End If
            // -----------------------------
            else if (base.UserIsInRole("ReadOnley") | base.IsTagged("masterlist"))
            {
                // Dim restrictedCommands() As String =
                // {"Edit", "New", "Delete", "Duplicate", "Import"}
                // Dim actionIterator As XPathNodeIterator = navigator.Select("//c:action", resolver)
                // While (actionIterator.MoveNext())
                // Dim commandName As String = actionIterator.Current.GetAttribute(
                // "commandName", String.Empty)
                // If (restrictedCommands.Contains(commandName)) Then
                // actionIterator.Current.CreateAttribute(
                // String.Empty, "roles", String.Empty, "Administrators")
                // End If
                // End While
                switch (controllerName)
                {
                    case "AccnoDates":
                    case "_Dates":
                    case "_Dates1":
                    case "_Dates2":
                    case "_Dates3":
                    case "_Dates4":
                    case "AccnoDates1":
                    case "AccnoDates2":
                    case "AccnoDates3":
                    case "accinstallment1001":
                        {
                            break;
                        }

                    default:
                        {
                            base.NodeSet().SelectActions("New", "Update", "Delete", "Insert", "Duplicate", "Import", "ExportCsv", "ExportRowset", "ExportRss", "DataSheet", "Grid", "ReportAsExcel").Delete();
                            base.NodeSet().SelectActionGroups("Grid").SelectActions("New", "Update", "Delete", "Edit", "Insert", "Duplicate", "Import", "ExportCsv", "ExportRowset", "ExportRss", "DataSheet", "Grid", "ReportAsExcel").Delete();

                            break;
                        }
                }
            }
            else
            {
                // Select Case controllerName



                // Case "GLmstrfl", "accountclasslist", "GLmfband", "GLmfbab"


                // '       If (IsTagged("runningcontract")) Then
                // '        End If
                // NodeSet().SelectActions("New", "Edit", "Delete", "Duplicate", "Import") _
                // .Delete()
                // ' delete all remaining actions in the 'Grid' scope 
                // NodeSet().SelectActionGroups("Grid") _
                // .SelectActions() _
                // .Delete()
                // '            ' add new 'Navigate' action to the 'Grid' scope 
                // '            NodeSet().SelectActionGroups("Grid") _
                // '                .CreateAction(
                // '                    "Navigate",
                // '                    "ajrcontractrun.aspx?ajrCntrctSr={ajrCntrctSr}&_controller=ajrContracts" +
                // '                    "&_commandName=Edit&_commandArgument=editcontract")




                // End Select

            }
            // Dim myrolbool As Boolean = False
            // myrolbool = iseditinginmyrol(controllerName)
            // myrolbool = False
            // If (myrolbool) Then
            // NodeSet().SelectActions("New", "Edit", "Delete", "Duplicate", "Import").Delete()
            // End If

            var regionLabel = base.Navigator.SelectSingleNode("/c:dataController/c:restConfig", base.Resolver);
            if (regionLabel is object)
            {
            }
            else
            {
                base.Navigator.SelectSingleNode("/c:dataController", base.Resolver).AppendChild("<restConfig>Uri: ." + vbCrLf + " Method: GET" + vbCrLf + " Users: * " + vbCrLf + " JSON: True   </restConfig>");
            }

            // add here Rules from Rules in sitcontent Or sitRulesContent 
            // Dim regionLabel1 As XPathNavigator = Navigator.SelectSingleNode("/c:dataController/c:restConfig", Resolver)
            // If (Not regionLabel Is Nothing) Then
            // Else
            // Navigator.SelectSingleNode("/c:dataController", Resolver).AppendChild("<restConfig>Uri: ." & vbCrLf & " Method: GET" & vbCrLf & " Users: * " & vbCrLf & " JSON: True   </restConfig>")
            // End If

            // "/c:dataController/c:fields/c:field[@name='Region']/@label"

            // Dim resapi As Object = NodeSet().Elem("/c:dataController/c:restConfig")
            // If (Not (resapi) Is Nothing) Then
            // If resapi.nodes.count = 0 Then

            // Dim resapi1 As ControllerNodeSet = NodeSet().Elem("/c:dataController")
            // resapi1.AppendTo("c:restConfig").Value("mostafa")
            // End If
            // End If
            string kf = string.Empty;
            object iterator = base.NodeSet().Select("/c:dataController/c:fields").Select("c:field[@isPrimaryKey='true']/@name");
            if (iterator is object)
            {
                kf = iterator.ToString();
            }
            // workflow----- idfilter=" + Controller. +"&
            if (IsNothing[iterator])
            {
                if (base.NodeSet().SelectActionGroup("ag2").IsEmpty)
                {
                }
                else
                {
                    base.NodeSet().SelectActionGroups("Grid").CreateAction("Navigate", "webreportviwer.aspx?reportquery=" + controllerName);
                }
            }
            else if (base.NodeSet().SelectActionGroup("ag2").IsEmpty)
            {
            }
            else
            {
                base.NodeSet().SelectActionGroups("Grid").CreateAction("Navigate", "_blank:webreportviwer.aspx?idfilter={" + iterator.ToString() + "}&reportquery=" + controllerName);
            }
            // "webreportviwerDyn.aspx?reportquery=" + controllerName + "", "mrt100001")
            switch (controllerName)
            {
                case "schvchdlydetailreg1001":
                case "schvchdlydetailpayment1001":
                    {
                        break;
                    }

                default:
                    {
                        DataTable dtDataTable;
                        dtDataTable = global::DataLogic.GetData("select * from mrtcontrollerName where controllerName<>ReportCode and   controllerName='" + controllerName + "' order by controllerNameid");
                        if (dtDataTable.Rows.Count > 0)
                        {
                            string strDetail = "";
                            double strDetailid = 0;
                            // NodeSet().Select("/c:dataController/c:actions").CreateActionGroup("ag7pdfmos1")

                            // NodeSet().SelectActionGroup("ag7pdfmos1").Attr("headerText", translatemeyamosso.GetResourceValuemosso("PdfReports1"))
                            // NodeSet().Select("/c:dataController/c:actions").CreateActionGroup("ag7xlxmos1")

                            // NodeSet().SelectActionGroup("ag7xlxmos1").Attr("headerText", translatemeyamosso.GetResourceValuemosso("xlxReports1"))

                            foreach (DataRow row in dtDataTable.Rows)
                            {
                                strDetailid = Convert.ToDouble(row["controllerNameid"]);
                                strDetailid = 10000 + strDetailid;
                                if (base.NodeSet().SelectActionGroup("ag7").IsEmpty)
                                {
                                }
                                else
                                {
                                    base.NodeSet().SelectActionGroup("ag7").CreateAction("ReportAsPdf", "", Conversions.ToString(row["ReportCode"]));
                                    base.NodeSet().SelectActionGroup("ag7").SelectAction(Conversions.ToString(row["ReportCode"])).Attr("headerText", global::translatemeyamosso.GetResourceValuemosso(Conversions.ToString(row["ReportCode"])));
                                }

                                if (base.NodeSet().SelectActionGroup("ag7pdfmos").IsEmpty)
                                {
                                }
                                else
                                {
                                    base.NodeSet().SelectActionGroup("ag7pdfmos").CreateAction("ReportAsPdf", "mospdf", Conversions.ToString(row["ReportCode"]));
                                    base.NodeSet().SelectActionGroup("ag7pdfmos").SelectAction(Conversions.ToString(row["ReportCode"])).Attr("headerText", global::translatemeyamosso.GetResourceValuemosso(Conversions.ToString(row["ReportCode"])));
                                }

                                if (base.NodeSet().SelectActionGroup("ag7xlxmos").IsEmpty)
                                {
                                }
                                else
                                {
                                    base.NodeSet().SelectActionGroup("ag7xlxmos").CreateAction("ReportAsPdf", "mosxlx", Conversions.ToString(row["ReportCode"]));
                                    base.NodeSet().SelectActionGroup("ag7xlxmos").SelectAction(Conversions.ToString(row["ReportCode"])).Attr("headerText", global::translatemeyamosso.GetResourceValuemosso(Conversions.ToString(row["ReportCode"])));
                                }
                            }

                            if (base.UserIsInRole("ReportDesigner"))
                            {
                                string newnumberreport;
                                newnumberreport = (strDetailid + 1).ToString();
                                newnumberreport = (10000 + Conversions.ToDouble(newnumberreport)).ToString();
                                if (base.NodeSet().SelectActionGroup("ag7").IsEmpty)
                                {
                                }
                                else
                                {
                                    base.NodeSet().SelectActionGroup("ag7").CreateAction("ReportAsPdf", "newrpt", "mrt" + controllerName + newnumberreport);
                                    base.NodeSet().SelectActionGroup("ag7").SelectAction("mrt" + controllerName + newnumberreport).Attr("headerText", global::translatemeyamosso.GetResourceValuemosso("NewReport"));
                                }
                            }
                        }
                        else if (base.UserIsInRole("ReportDesigner"))
                        {
                            if (base.NodeSet().SelectActionGroup("ag7").IsEmpty)
                            {
                            }
                            else
                            {
                                base.NodeSet().SelectActionGroup("ag7").CreateAction("ReportAsPdf", "newrpt", "mrt" + controllerName + "100001");
                                base.NodeSet().SelectActionGroup("ag7").SelectAction("mrt" + controllerName + "100001").Attr("headerText", global::translatemeyamosso.GetResourceValuemosso("NewReport"));
                            }
                        }

                        if (base.UserIsInRole("ReportDesigner"))
                        {
                            if (base.NodeSet().SelectActionGroup("ag7").IsEmpty)
                            {
                            }
                            else
                            {
                                base.NodeSet().SelectActionGroup("ag7").CreateAction("ReportAsPdf", "DaynamicMrtReport", "Daynamic100001");
                            }
                        }

                        break;
                    }
            }
        }

        public bool iseditinginmyrol(string controllerNamestr)
        {
            try
            {
                if (HttpContext.Current.Session("rolesList") is object)
                {
                    var dt = new DataTable();
                    dt = (DataTable)HttpContext.Current.Session("rolesList");
                    string filterExp = "Rolesname = '" + controllerNamestr + "'";
                    string sortExp = "Rolesname";
                    DataRow[] drarray;
                    // Dim i As Integer
                    drarray = dt.Select(filterExp, sortExp, DataViewRowState.CurrentRows);
                    if (drarray.Length > 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        public string authorizedme(string varclass)
        {
            // Try

            if (HttpContext.Current.Session("rolesList") is null)
            {
                using (var mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString))
                {
                    // Try

                    // ------------------------------------------------
                    string strSql = "select pagesname as Rolesname from vwaspnetpageforUsers where  UserName='" + HttpContext.Current.User.Identity.Name + "'";
                    var ds1 = new DataSet();
                    var da1 = new SqlDataAdapter();
                    da1.SelectCommand = new SqlCommand(strSql, mySqlConnection);
                    da1.Fill(ds1);
                    if (ds1 is object && ds1.Tables.Count > 0)
                    {
                        System.Web.HttpContext.Current.Session["rolesList"] = ds1.Tables[0];
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Session["rolesList"] = null;
                    }
                    // Catch ex As Exception
                    // Finally
                    // If (mySqlConnection.State = ConnectionState.Open) Then mySqlConnection.Close()
                    // End Try
                }
            }

            if (HttpContext.Current.Session("rolesList") is object)
            {
                var dt = new DataTable();
                dt = (DataTable)HttpContext.Current.Session("rolesList");
                string filterExp = "Rolesname = '" + varclass + "'";
                string sortExp = "Rolesname";
                DataRow[] drarray;
                int i;
                drarray = dt.Select(filterExp, sortExp, DataViewRowState.CurrentRows);
                if (drarray.Length > 0)
                {
                    var loopTo = drarray.Length - 1;
                    for (i = 0; i <= loopTo; i++)
                        return drarray[i]["Rolesname"].ToString();
                }
                else
                {
                    return " ";
                }
            }
            else
            {
                return varclass;
            }

            // Catch ex As Exception
            // End Try


            return varclass;
        }
    }
}

namespace eZee.Web
{
    public partial class PageBase
    {
        public PageBase()
        {
            this.Load += Page_Load;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                string rolesstringtitle;
                rolesstringtitle = Right[this.Page.AppRelativeVirtualPath, Len[this.Page.AppRelativeVirtualPath] - Len[this.Page.AppRelativeTemplateSourceDirectory]];
                rolesstringtitle = Left[rolesstringtitle, Len[rolesstringtitle] - 5];
                this.Page.Title = global::translatemeyamosso.GetResourceValuemosso(this.Page.Title); // rolesstringtitle
                System.DateTime d;
                d = DateTime.Now;
                if (DateValue[d.ToString()] > DateValue["2020-10-13"])
                {
                    // ' MsgBox("wow", MsgBoxStyle.Exclamation, "teto")
                    // rolesList
                    base.Context.Response.Redirect("~/pages/Expires.html");
                }
                // If IsNothing(Context.User.Identity.Name) Or String.IsNullOrEmpty(Context.User.Identity.Name) Then
                // Else

                // 'workstation id from connection 
                // ' DirectCast(connection, System.Data.SqlClient.SqlConnection).WorkstationId()

                // Dim rolesstring1 As String
                // 'Dim rolesstringtitle As String
                // rolesstring1 = Right(Me.Page.AppRelativeVirtualPath, Len(Me.Page.AppRelativeVirtualPath) - Len(Me.Page.AppRelativeTemplateSourceDirectory))
                // 'rolesstringtitle = Left(rolesstring1, Len(rolesstring1) - 5) 

                // Select Case rolesstring1
                // Case "user_details.aspx", "MYprofile_1.aspx", "MYprofile.aspx"

                // Case Else
                // Dim sqlstatmentcheck As String
                // sqlstatmentcheck = "select count(*) as tecko from [user_details]  where  UserName='" & Context.User.Identity.Name & "'"
                // Dim tekost As Object
                // tekost = DataLogic.GetValue(sqlstatmentcheck)
                // If IsNothing(tekost) = True Then
                // Response.Redirect("~/Pages/MYprofile_1.aspx")
                // Else
                // If tekost = 0 Then
                // Response.Redirect("~/Pages/MYprofile_1.aspx")
                // End If
                // End If
                // End Select
                // End If                '' MsgBox("wow", MsgBoxStyle.Exclamation, "teto")
                // 'rolesList
                // Dim rolesstring As String
                // rolesstring = Right(Me.Page.AppRelativeVirtualPath, Len(Me.Page.AppRelativeVirtualPath) - Len(Me.Page.AppRelativeTemplateSourceDirectory))
                // ' rolesstring = Left(rolesstring, Len(rolesstring) - 5) 
                // Select Case rolesstring
                // Case "myinfo.aspx", "Login.aspx", "Users.aspx", "UsersTypes.aspx", "UsersTypes_roles.aspx", "usertypRolsjoin.aspx", "userRights.aspx"
                // Case "Home.aspx", "UserRolesGroup.aspx", "UserRolesGroupjoin.aspx", "userRolesnew.aspx", "Users_Home.aspx"
                // Case "SignIn.aspx"
                // Case "SignOut.aspx", "SendUserInfo.aspx", "LargeListSelector.aspx", "changeUsersPage.aspx", "SetLanguagePage.aspx", "AddTransaltsystemPage.aspx", "TransaltsystemWebReport.aspx", "SelectEditTransaltsystemPage.aspx"
                // Case "ConfigureAddRecord.aspx", "ConfigureEditRecord.aspx", "ConfigureSpecialEditRecord.aspx", "ConfigureSpecialViewRecord.aspx", "ShowTransaltsystemTablePage.aspx", "ShowTransaltsystemPage.aspx", "EditTransaltsystemTablePage.aspx"
                // Case "ConfigureViewRecord.aspx", "ExportFieldValue.aspx", "Forbidden.aspx", "SelectFileToImport.aspx", "Show_Error.aspx", "EditTransaltsystemPage.aspx", "SearchEditTransaltsystemPage.aspx", "ForgotUser.aspx"
                // Case Else
                // 'rolesstring = "New" & rolesstring.ToString()
                // 'If (authorizedme(UCase(rolesstring).ToString()) = UCase(rolesstring).ToString) Then

                // 'Else
                // '    Response.Red   irect("../Security.aspx")
                // 'End If
                // End Select

                // Dim stmap As Control = FindControlRecursive(Me.Page, "SiteMapDataSource1")
                // Dim txtCtl As Control = FindControlRecursive(Me.Page, "TreeView1")

                // If IsNothing(txtCtl) Then
                // Else
                // Dim ca As System.Web.UI.WebControls.TreeView = TryCast(txtCtl, System.Web.UI.WebControls.TreeView)
                // If IsNothing(ca) Then
                // Else
                // ca.Visible = False

                // 'oldtreeview will disable and hiden
                // 'ca.DataBind()
                // 'ConfigureNodeTargets(ca.Nodes)
                // '/// use telrik  module  this example for from file
                // Dim teleric As RadSiteMapDataSource
                // teleric = New RadSiteMapDataSource
                // teleric.ShowStartingNode = "false"
                // teleric.StartFromCurrentNode = "true"
                // 'teleric.SiteMapFile = translatemeyamosso.GetVirtualPath(Server.MapPath("../Web.Sitemap"))
                // ''// Create an instance of the XmlSiteMapProvider class.
                // 'Dim testXmlProvider As XmlSiteMapProvider = New XmlSiteMapProvider()
                // 'Dim providerAttributes As NameValueCollection = New NameValueCollection(1)
                // 'providerAttributes.Add("siteMapFile", translatemeyamosso.GetVirtualPath(Server.MapPath("../Web.Sitemap")))
                // ''// Initialize the provider with a provider name and file name.
                // 'testXmlProvider.Initialize("testProvider", providerAttributes)
                // ''// Call the BuildSiteMap to load the site map information into memory.
                // 'testXmlProvider.BuildSiteMap()
                // '-------------------------------end of example but we dont use it for security cannot control if read from sitmape
                // Dim smd As SiteMapDataSource = New SiteMapDataSource()
                // smd.Provider = SiteMap.Providers("XmlSiteMapProvider")     'testXmlProvider  this is the secrte
                // smd.ShowStartingNode = "true"
                // smd.StartFromCurrentNode = "true"
                // Dim tv2 As TreeView = New TreeView()
                // '-----------------------startmostafa2014-11-12
                // Dim telrikrad As RadSiteMap = New RadSiteMap
                // telrikrad.DataSourceID = "XmlSiteMapProvider"
                // telrikrad.ShowNodeLines = "true"
                // telrikrad.Width = 450
                // Dim telriksitemaplevelsetting As SiteMapLevelSetting = New SiteMapLevelSetting
                // telriksitemaplevelsetting.Layout = SiteMapLayout.List
                // telriksitemaplevelsetting.Level = "0"
                // telriksitemaplevelsetting.ListLayout.RepeatColumns = 3
                // telriksitemaplevelsetting.ListLayout.RepeatDirection = SiteMapRepeatDirection.Vertical
                // telrikrad.LevelSettings.Add(telriksitemaplevelsetting)
                // '----------------endmostafa2014-11-12
                // tv2.DataSource = smd
                // tv2.DataBind() '//Important or all is blank
                // tv2.CssClass = "TreeView"
                // tv2.ImageSet = TreeViewImageSet.Simple2
                // Dim stmap1 As ContentPlaceHolder = FindControlRecursive(Me.Page, "PageContentPlaceHolder")
                // If IsNothing(stmap1) Then
                // Else

                // ConfigureNodeTargets(tv2.Nodes)

                // stmap1.Controls.Add(tv2)
                // stmap1.Controls.Add(telrikrad)
                // telrikrad.Visible = True
                // tv2.Visible = True
                // End If
                // ''''Dim DynamicUserControl As UserControl = LoadControl("~/Controls/TableOfContentsajar.ascx")
                // ''''Dim stmap1 As ContentPlaceHolder = FindControlRecursive(Me.Page, "PageContentPlaceHolder")
                // ''''If IsNothing(stmap1) Then
                // ''''Else
                // ''''    'telrikrad.Visible = False
                // ''''    ' ConfigureNodeTargets1(telrikrad.Nodes)
                // ''''    DynamicUserControl.Visible = False
                // ''''    stmap1.Controls.Add(DynamicUserControl)
                // ''''    ' stmap1.Controls.Add(telrikrad)
                // ''''    DynamicUserControl.Visible = True
                // ''''    'telrikrad.Visible = True
                // ''''End If

                // End If
                // End If
                // ---------------------------------------------------------



                // '---------------------------------------------------------------
                // 'For Each c As Control In Me.Page.Controls

                // '    Dim xcv As String = c.GetType.ToString()
                // '    MsgBox(xcv)

                // Next
            }
        }

        public Control FindControlRecursive(Control ctrl, string id)
        {
            // Exit if this is the control we're looking for.

            // Else, look in the hiearchy.
            if (ctrl.ID == id)
                return ctrl;
            foreach (Control childCtrl in ctrl.Controls)
            {
                var resCtrl = FindControlRecursive(childCtrl, id);
                // Exit if we've found the result
                if (resCtrl is object)
                    return resCtrl;
            }

            return default;
        }
        /// Private Sub ConfigureNodeTargets1(ByVal nodes As RadSiteMapNodeCollection)
        /// For Each n As RadSiteMapNode In nodes
        /// Dim m As Match = Regex.Match(n.NavigateUrl, "^(_\w+):(.+)$")
        /// If m.Success Then
        /// n.Target = m.Groups(1).Value
        /// n.NavigateUrl = m.Groups(2).Value
        /// End If
        /// n.Text = GetResourceValuemosso(n.Text)
        /// ConfigureNodeTargets1(n.Nodes)
        /// Next
        /// End Sub
        private void ConfigureNodeTargets(TreeNodeCollection nodes)
        {
            foreach (TreeNode n in nodes)
            {
                Match m = Regex.Match(n.NavigateUrl, @"^(_\w+):(.+)$");
                if (m.Success)
                {
                    n.Target = m.Groups(1).Value;
                    n.NavigateUrl = m.Groups(2).Value;
                }

                n.Text = global::translatemeyamosso.GetResourceValuemosso(n.Text);
                ConfigureNodeTargets(n.ChildNodes);
            }
        }

        public string authorizedme(string varclass)
        {
            try
            {
                if (HttpContext.Current.Session("rolesList") is object)
                {
                    var dt = new DataTable();
                    dt = (DataTable)HttpContext.Current.Session("rolesList");
                    string filterExp = "Rolesname = '" + varclass + "'";
                    string sortExp = "Rolesname";
                    DataRow[] drarray;
                    int i;
                    drarray = dt.Select(filterExp, sortExp, DataViewRowState.CurrentRows);
                    if (drarray.Length > 0)
                    {
                        var loopTo = drarray.Length - 1;
                        for (i = 0; i <= loopTo; i++)
                            return drarray[i]["Rolesname"].ToString();
                    }
                    else
                    {
                        return " ";
                    }
                }
                else
                {
                    return varclass;
                }
            }
            catch (Exception ex)
            {
            }

            return varclass;
        }
    }
}