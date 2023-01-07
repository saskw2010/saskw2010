Imports eZee.Data
Imports System.Data
Imports System.Xml
Imports System.Data.SqlClient
Imports translatemeyamosso
Imports System.Data.Common
Imports System.IO
Imports System.Web.Configuration
Imports DataLogic
Imports System.Xml.XPath
Imports System.Threading
Namespace eZee.Rules

    Partial Public Class SharedBusinessRules
        Inherits eZee.Data.BusinessRules


        Public Function getmyreferance() As String
            If IsNothing(HttpContext.Current.Session.Item("sgm")) = False Then
                Using calc As SqlText = New SqlText(
                        "select max(ReferanceNo) " +
                        "from [schvchReferancno] where sgm=@sgm")
                    calc.AddParameter("@sgm", CType(HttpContext.Current.Session.Item("sgm"), Int64))
                    Dim total As Object = calc.ExecuteScalar()
                    If DBNull.Value.Equals(total) Then

                        Return "1"
                    Else

                        Return Convert.ToDecimal(total) + 1
                    End If
                End Using

            Else
                Return "0"
            End If
        End Function
        Public Function getuseremail() As String

            Dim user As MembershipUser = Membership.GetUser(UserName)
            'Dim user As newmembership = newmembership.SelectSingle(newUser.ProviderUserKey)
            If (Not (user) Is Nothing) Then
                Dim userApplicationId1 As String
                userApplicationId1 = user.Email
                Return userApplicationId1
            Else
                Return "   _no_n0_name////   "
            End If
        End Function
        '<ControllerAction(, "editForm1", "Update", ActionPhase.Before)>
        'Public Sub AssignFieldValuesToschApplicationedit()

        '    Result.ShowMessage("Custom:   " & args.CommandName)

        '    Dim Requestsx As New PageRequest
        '        Requestsx.Controller = args.Controller
        '        Requestsx.View = args.View
        '        Requestsx.SortExpression = args.SortExpression
        '        If (Not (args.Filter) Is Nothing) Then
        '            'Dim dve As eZee.Web.DataViewExtender = New DataViewExtender()
        '            'dve.AssignStartupFilter(args.Filter)
        '            Requestsx.Filter = args.Filter.ToArray()
        '        End If
        '        Request.PageSize = Int32.MaxValue
        '        Request.RequiresRowCount = True
        '        Request.RequiresMetaData = True
        '        Dim page As ViewPage = ControllerFactory.CreateDataController.GetPage(Requestsx.Controller, Requestsx.View, Requestsx)
        '        Dim tablerequestreport1 As DataTable = page.ToDataTable()
        '        'context.Session("tablerequestreport") = tablerequestreport1
        '        Dim appDirectory1 As String = HttpContext.Current.Server.MapPath("~")
        '        Dim username As String
        '        Dim timestampstring As String
        '        username = HttpContext.Current.User.Identity.Name()
        '        timestampstring = System.DateTime.Now.ToString("yyyyMMddHHmmss")
        '        Dim mydocpath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        '        Dim reportFileNamemossopath As String = appDirectory1 + "\Reportsdata\" ' mydocpath
        '        Dim reportFileNamemosso As String = "mostafaxlml" + username + timestampstring
        '        'Dim writer = New XmlTextWriter(@"C:\test.xml", encoding.)
        '        Dim utfencoder As Encoding = UTF8Encoding.GetEncoding("UTF-8", New EncoderReplacementFallback(""), New DecoderReplacementFallback(""))
        '        Dim sbWrite As New StringBuilder()
        '        Dim strWrite As New StringWriter(sbWrite)
        '        Dim xmlWrite As New CustomXmlWriter(reportFileNamemossopath + reportFileNamemosso + ".xml", UTF8Encoding.GetEncoding("UTF-8", New EncoderReplacementFallback(""), New DecoderReplacementFallback("")))

        '        tablerequestreport1.WriteXml(xmlWrite, System.Data.XmlWriteMode.WriteSchema)

        '        xmlWrite.Flush()
        '        xmlWrite.Close()

        '    End If
        'End Sub


        Protected Overrides Sub AfterSqlAction(args As ActionArgs, result As ActionResult)
            If (result.Errors.Count = 0 And Arguments.CommandName = "Update" Or Arguments.CommandName = "Report" Or
                Arguments.CommandName = "Insert" Or Arguments.CommandName = "Delete") Then

                Dim dbinerto As New dblayer
                Dim xinsert As Boolean
                xinsert = dbinerto.Insert("insert into webuserlog([username] ,[controllername]  ,[viewnm]  ,[Actionnm] ,[Actionargument]) values ('" & HttpContext.Current.User.Identity.Name & "','" & args.Controller & "','" & args.View & "','" & Arguments.CommandName & "','" & Arguments.CommandArgument & "')")


                result.Continue()

            End If



        End Sub
        Protected Overrides Sub ExecuteAction(args As ActionArgs, result As ActionResult)
            If (args.CommandName = "Report") Then
                result.ShowMessage("Report" & args.CommandName)

            ElseIf (args.CommandName = "Custom") Then
                result.ShowMessage("Custom:   " & args.CommandName)
            End If
        End Sub



        Public Shared Function getdatatable(argsController As String, argsView As String, argfilter As String) As DataTable

            Dim Request As New PageRequest
            Request.Controller = argsController
            Dim mArr() As String
            mArr = Split(argfilter, "-mos//tafa//-")
            Request.Filter = mArr
            Request.ExternalFilter = Nothing
            Request.View = argsView
            Request.SortExpression = Nothing
            Request.PageSize = 1000000
            Request.RequiresRowCount = True
            Request.RequiresMetaData = True
            Dim page As ViewPage = ControllerFactory.CreateDataController.GetPage(argsController, argsView, Request)
            Dim table As DataTable = page.ToDataTable()
            Return table
        End Function
        Public Shared Function getdatatable2016() As DataTable

            Dim Request As New PageRequest
            Request.Controller = eZee.Data.ActionArgs.Current.Controller
            Request.Filter = eZee.Data.ActionArgs.Current.Filter
            Request.ExternalFilter = eZee.Data.ActionArgs.Current.ExternalFilter
            Request.View = eZee.Data.ActionArgs.Current.View
            Request.SortExpression = eZee.Data.ActionArgs.Current.SortExpression
            Request.PageSize = 10000000
            Request.RequiresRowCount = True
            Request.RequiresMetaData = True
            Dim page As ViewPage = ControllerFactory.CreateDataController.GetPage(eZee.Data.ActionArgs.Current.Controller, eZee.Data.ActionArgs.Current.View, Request)
            Dim table As DataTable = page.ToDataTable()
            'Dim appDirectory1 As String = HttpContext.Current.Server.MapPath("~")
            'Dim username As String
            'Dim timestampstring As String
            'username = HttpContext.Current.User.Identity.Name()
            'timestampstring = System.DateTime.Now.ToString("yyyyMMddHHmmss")
            'Dim reportFileName As String = appDirectory1 + "\Reports\mostafaxlml" + username + timestampstring + ".xml"
            'table.WriteXml(reportFileName, System.Data.XmlWriteMode.IgnoreSchema)
            'Dim reportFileName1 As String = appDirectory1 + "\Reports\mostafaxlml" + username + timestampstring + ".xsd"
            'table.WriteXmlSchema(reportFileName1)
            Return table
        End Function
        Protected Overrides Sub EnumerateDynamicAccessControlRules(controllerName As String)

            If (IsTagged("searchme")) Then
                If IsNothing(Context.Session("HomePhoneText")) Or String.IsNullOrEmpty(Context.Session("HomePhoneText")) Then
                    Context.Session("HomePhoneText") = "0"
                End If

                If IsNothing(Context.Session("HomePhoneText")) Or String.IsNullOrEmpty(Context.Session("HomePhoneText")) Then
                Else
                    Select Case controllerName ' check table then put it or no by select from informationschema where table 
                        Case "TblAppointments"
                            RegisterAccessControlRule("IDATUTO", "IDATUTO in(select IDATUTO from TblAppointments where HomePhone=@HomePhone OR MobilePhone=@MobilePhone )", AccessPermission.Allow,
                       New SqlParam("@HomePhone", Context.Session("HomePhoneText")), New SqlParam("@MobilePhone", Context.Session("HomePhoneText")))

                            ' Case "TblAppointmentsArchive"
                            '    RegisterAccessControlRule("Archivid", "Archivid in(select Archivid from TblAppointmentsArchive where HomePhone=@HomePhone OR MobilePhone=@MobilePhone )", AccessPermission.Allow,
                            'New SqlParam("@HomePhone", Context.Session("HomePhoneText")), New SqlParam("@MobilePhone", Context.Session("HomePhoneText")))
                            ' Case "Tbl_ArchAppoint"
                            '     RegisterAccessControlRule("ArchAppointAutoid", "ArchAppointAutoid in(select ArchAppointAutoid from Tbl_ArchAppoint where HomePhone=@HomePhone OR MobilePhone=@MobilePhone )", AccessPermission.Allow,
                            ' New SqlParam("@HomePhone", Context.Session("HomePhoneText")), New SqlParam("@MobilePhone", Context.Session("HomePhoneText")))

                            '---------------------------------------------------
                        Case "HomePhoneliststatus"
                            RegisterAccessControlRule("HomePhonelook", "HomePhonelook=@HomePhone", AccessPermission.Allow,
                       New SqlParam("@HomePhone", Context.Session("HomePhoneText")))

                        Case "TblCustomers"
                            RegisterAccessControlRule("Rainbow_no", "Rainbow_no in(select Rainbow_no from TblCustomers where HomePhone=@HomePhone OR MobilePhone=@MobilePhone OR Workphone=@Workphone )", AccessPermission.Allow,
                       New SqlParam("@HomePhone", Context.Session("HomePhoneText")), New SqlParam("@MobilePhone", Context.Session("HomePhoneText")), New SqlParam("@Workphone", Context.Session("HomePhoneText")))
                            'Case "TblCustomersArchive"
                            '    RegisterAccessControlRule("Archiveidauo", "Archiveidauo in(select Archiveidauo from TblCustomersArchive where HomePhone=@HomePhone OR MobilePhone=@MobilePhone OR Workphone=@Workphone )", AccessPermission.Allow,
                            '         New SqlParam("@HomePhone", Context.Session("HomePhoneText")), New SqlParam("@MobilePhone", Context.Session("HomePhoneText")), New SqlParam("@Workphone", Context.Session("HomePhoneText")))

                            'Case "Tbl_ArchCustomers"
                            '    RegisterAccessControlRule("Rainbow_no", "Rainbow_no in(select Rainbow_no from Tbl_ArchCustomers where HomePhone=@HomePhone OR MobilePhone=@MobilePhone OR Workphone=@Workphone )", AccessPermission.Allow,
                            '         New SqlParam("@HomePhone", Context.Session("HomePhoneText")), New SqlParam("@MobilePhone", Context.Session("HomePhoneText")), New SqlParam("@Workphone", Context.Session("HomePhoneText")))



                        Case Else
                    End Select
                End If
            End If
            'AddTag("UserIsInformed")




            If HttpContext.Current.User.Identity.IsAuthenticated Then
                If UserIsInRole("Administrator") Then
                    'UnrestrictedAccess()
                ElseIf UserIsInRole("Administrators") Then
                    RegisterAccessControlRule("CompanyAccount", "CompanyAccount=@CompanyAccount", AccessPermission.Allow,
                   New SqlParam("@CompanyAccount", Companycode()))
                    RegisterAccessControlRule("RoleName", "RoleName=@RoleName", AccessPermission.Deny,
                                      New SqlParam("@RoleName", "Administrator"))

                Else
                    RegisterAccessControlRule("CompanyAccount", "CompanyAccount=@CompanyAccount", AccessPermission.Allow,
                    New SqlParam("@CompanyAccount", Companycode()))

                    RegisterAccessControlRule("RoleName", "RoleName=@RoleName", AccessPermission.Deny,
                                      New SqlParam("@RoleName", "Administrator"))

                    RegisterAccessControlRule("activeflage", "activeflage=@activeflage", AccessPermission.Deny,
                                        New SqlParam("@activeflage", 0))
                    RegisterAccessControlRule("activeflageD", "activeflageD=@activeflageD", AccessPermission.Deny,
                                        New SqlParam("@activeflageD", 0))
                    RegisterAccessControlRule("activeflagetele", "activeflagetele=@activeflagetele", AccessPermission.Deny,
                                        New SqlParam("@activeflagetele", 0))
                    RegisterAccessControlRule("activeflageserviced", "activeflageserviced=@activeflageserviced", AccessPermission.Deny,
                     New SqlParam("@activeflageserviced", 0))
                    Select Case controllerName ' check table then put it or no by select from informationschema where table 
                        Case "schApplication1001", "schApplication1002"
                            If getThebranchDesc1("schApplication") = "" Then
                            Else
                                RegisterAccessControlRule("branch", getThebranchDesc1("schApplication"), AccessPermission.Allow)
                            End If
                        Case "EVOL_Memo"
                            RegisterAccessControlRule("ID", " EVOL_Memo.ID in (select id from EVOLMemo where UserName=@UserName)", AccessPermission.Allow, New SqlParam("@UserName", HttpContext.Current.User.Identity.Name))
                        Case Else
                            If getThebranchDesc1(controllerName) = "" Then
                            Else
                                RegisterAccessControlRule("branch", getThebranchDesc1(controllerName), AccessPermission.Allow)

                            End If
                            If getThebranchDesc1sgm(controllerName) = "" Then
                            Else
                                RegisterAccessControlRule("sgm", getThebranchDesc1sgm(controllerName), AccessPermission.Allow)

                            End If
                    End Select
                End If
            End If
        End Sub
        Public Function getsgmusername() As String
            Dim myIntsgm As String = HttpContext.Current.User.Identity.Name
            If String.IsNullOrEmpty(myIntsgm) Then
                Return "   _"
            Else
                Return myIntsgm
            End If
        End Function
        Public Function getmycashaccount() As String
            Dim myIntsgm As String = 1 ' HttpContext.Current.User.Identity.Name
            If String.IsNullOrEmpty(myIntsgm) Then
                Return "   _"
            Else
                Return myIntsgm
            End If
        End Function
        Public Function getmysalesaccount() As String
            Dim myIntsgm As String = 1 'HttpContext.Current.User.Identity.Name
            If String.IsNullOrEmpty(myIntsgm) Then
                Return "   _"
            Else
                Return myIntsgm
            End If
        End Function
        Public Function getmyfirstbranch() As String
            Dim myIntsgm As String = 1
            If UserIsInRole("Administrator") Or UserIsInRole("Administrators") Then
                Return myIntsgm
            Else

                Using calc As SqlText = New SqlText("select Top(1) brn_no from QUserdetailsegmentbrnch where UserName='" & HttpContext.Current.User.Identity.Name & "'")

                    Dim total As Object = calc.ExecuteScalar()
                    If DBNull.Value.Equals(total) Then
                        myIntsgm = 1

                    Else

                        myIntsgm = Convert.ToDecimal(total).ToString

                    End If
                End Using
                Return myIntsgm

            End If
        End Function
        Public Function Companycode() As String
            Dim myInt As String = HttpContext.Current.Session("nameofmycompany")
            If String.IsNullOrEmpty(myInt) Then
                Return "   _"
            Else
                Return myInt
            End If

        End Function
        Public Function getThebranchDesc1sgm(controllerName As String) As String
            If IsNothing(HttpContext.Current.Session("getThebranchDesc1sgm")) Or String.IsNullOrEmpty(HttpContext.Current.Session("getThebranchDesc1sgm")) Then

                getThebranchDesc1sgm = ""
                Using mySqlConnection As New SqlConnection(ConnectionStringSettingsFactory.getconnection().ConnectionString)
                    Try
                        '------------------------------------------------
                        Dim strSql As String = "select * from Userdetailsegmentsgm where UserName='" & HttpContext.Current.User.Identity.Name & "'"
                        Dim ds1 As New DataSet()
                        Dim da1 As New SqlDataAdapter()
                        da1.SelectCommand = New SqlCommand(strSql, mySqlConnection)
                        da1.Fill(ds1)
                        If (ds1 IsNot Nothing AndAlso ds1.Tables.Count > 0) Then

                            Dim satot As String = ""
                            If ds1.Tables(0).Rows.Count > 0 Then

                                For Each idatarow As DataRow In ds1.Tables(0).Rows
                                    If satot = "" Then
                                        'satot = controllerName & ".branch=" & idatarow.Item("branch") & ""
                                        satot = " sgm=" & idatarow.Item("sgm") & ""
                                    Else
                                        'satot = satot & " OR " & controllerName & ".branch=" & idatarow.Item("branch") & ""
                                        satot = satot & " OR " & "sgm=" & idatarow.Item("sgm") & ""
                                    End If

                                Next
                                satot = " Select sgm from glmulcmp where sgm=0 OR " & satot
                                HttpContext.Current.Session("getThebranchDesc1sgm") = satot
                                Return satot
                            End If
                            HttpContext.Current.Session("getThebranchDesc1sgm") = satot
                            Return satot
                        Else
                            HttpContext.Current.Session("getThebranchDesc1sgm") = getThebranchDesc1sgm
                            Return getThebranchDesc1sgm
                        End If
                    Catch ex As Exception
                    Finally
                        If (mySqlConnection.State = ConnectionState.Open) Then mySqlConnection.Close()
                    End Try
                End Using
            Else
                Return HttpContext.Current.Session("getThebranchDesc1sgm")
            End If
        End Function
        Public Function getThebranchDesc1(controllerName As String) As String
            If IsNothing(HttpContext.Current.Session("getThebranchDesc1")) Or String.IsNullOrEmpty(HttpContext.Current.Session("getThebranchDesc1")) Then

                getThebranchDesc1 = ""
                Using mySqlConnection As New SqlConnection(ConnectionStringSettingsFactory.getconnection().ConnectionString)
                    Try
                        '------------------------------------------------
                        Dim strSql As String = "select * from Userdetailsegment where UserName='" & HttpContext.Current.User.Identity.Name & "'"
                        Dim ds1 As New DataSet()
                        Dim da1 As New SqlDataAdapter()
                        da1.SelectCommand = New SqlCommand(strSql, mySqlConnection)
                        da1.Fill(ds1)
                        If (ds1 IsNot Nothing AndAlso ds1.Tables.Count > 0) Then

                            Dim satot As String = ""
                            If ds1.Tables(0).Rows.Count > 0 Then

                                For Each idatarow As DataRow In ds1.Tables(0).Rows
                                    If satot = "" Then
                                        'satot = controllerName & ".branch=" & idatarow.Item("branch") & ""
                                        satot = " branch=" & idatarow.Item("branch") & ""
                                    Else
                                        'satot = satot & " OR " & controllerName & ".branch=" & idatarow.Item("branch") & ""
                                        satot = satot & " OR " & "branch=" & idatarow.Item("branch") & ""
                                    End If

                                Next
                                satot = " Select branch from schbranch where branch=0 OR " & satot
                                HttpContext.Current.Session("getThebranchDesc1") = satot
                                Return satot
                            End If
                            HttpContext.Current.Session("getThebranchDesc1") = satot
                            Return satot
                        Else
                            HttpContext.Current.Session("getThebranchDesc1") = getThebranchDesc1
                            Return getThebranchDesc1
                        End If
                    Catch ex As Exception
                    Finally
                        If (mySqlConnection.State = ConnectionState.Open) Then mySqlConnection.Close()
                    End Try
                End Using
            Else
                Return HttpContext.Current.Session("getThebranchDesc1")
            End If
        End Function
        Public Function getsgm() As String

            Using mySqlConnection As New SqlConnection(ConnectionStringSettingsFactory.getconnection().ConnectionString)
                Try
                    '------------------------------------------------
                    Dim strSql As String = "select * from Quserdetailesegment where UserName='" & HttpContext.Current.User.Identity.Name & "'"
                    Dim ds1 As New DataSet()
                    Dim da1 As New SqlDataAdapter()
                    da1.SelectCommand = New SqlCommand(strSql, mySqlConnection)
                    da1.Fill(ds1)
                    If (ds1 IsNot Nothing AndAlso ds1.Tables.Count > 0) Then

                        Dim satot As String = ""
                        If ds1.Tables(0).Rows.Count > 0 Then

                            For Each idatarow As DataRow In ds1.Tables(0).Rows
                                satot = satot & idatarow.Item("branch") & ","  '"','"
                            Next
                        End If
                        If Right(satot, 1) = "," Then
                            satot = Left(satot, Len(satot) - 1)
                        End If
                        If Len(satot) = 1 Then
                            System.Web.HttpContext.Current.Session("getsgm") = Nothing
                        Else
                            System.Web.HttpContext.Current.Session("getsgm") = satot

                        End If

                    Else
                        System.Web.HttpContext.Current.Session("getsgm") = Nothing
                    End If
                Catch ex As Exception
                Finally
                    If (mySqlConnection.State = ConnectionState.Open) Then mySqlConnection.Close()
                End Try
            End Using
            Dim myIntsgm As String = HttpContext.Current.Session("getsgm")
            If String.IsNullOrEmpty(myIntsgm) Then
                Return "0"
            Else
                Return myIntsgm
            End If

        End Function

        'Public Function userApplicationId() As String

        '    Dim newUser As MembershipUser = Membership.GetUser(UserName)
        '    Dim user As newmembership = newmembership.SelectSingle(newUser.ProviderUserKey)
        '    If (Not (user) Is Nothing) Then
        '        Dim userApplicationId1 As String
        '        userApplicationId1 = user.Email
        '        Return userApplicationId1
        '    Else
        '        Return "   _no_n0_name////   "
        '    End If
        'End Function
        Public Function checkNewrole(ByVal controllerNamestr As String) As Boolean
            Try
                Using mySqlConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString)
                    Try



                        '------------------------------------------------
                        Dim strSql As String = "select insertAction  from vwaspnetpageforUsers where insertAction=0 and   UserName='" & HttpContext.Current.User.Identity.Name & "' and tablo='" & controllerNamestr & "'"
                        Dim ds1 As New DataSet()
                        Dim da1 As New SqlDataAdapter()
                        da1.SelectCommand = New SqlCommand(strSql, mySqlConnection)
                        da1.Fill(ds1)
                        If (ds1 IsNot Nothing AndAlso ds1.Tables(0).Rows.Count > 0) Then
                            Return True
                        Else
                            Return False



                        End If
                    Catch ex As Exception
                        Return False
                    Finally
                        If (mySqlConnection.State = ConnectionState.Open) Then mySqlConnection.Close()
                    End Try
                End Using

            Catch ex As Exception
                Return False
            End Try



        End Function
        Public Function checkeditrole(ByVal controllerNamestr As String) As Boolean
            Try
                Using mySqlConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString)
                    Try

                        '------------------------------------------------
                        Dim strSql As String = "select updateAction  from vwaspnetpageforUsers where updateAction=0 and   UserName='" & HttpContext.Current.User.Identity.Name & "' and tablo='" & controllerNamestr & "'"
                        Dim ds1 As New DataSet()
                        Dim da1 As New SqlDataAdapter()
                        da1.SelectCommand = New SqlCommand(strSql, mySqlConnection)
                        da1.Fill(ds1)
                        If (ds1 IsNot Nothing AndAlso ds1.Tables(0).Rows.Count > 0) Then
                            Return True





                        Else
                            Return False


                        End If
                    Catch ex As Exception
                        Return False
                    Finally
                        If (mySqlConnection.State = ConnectionState.Open) Then mySqlConnection.Close()
                    End Try
                End Using




            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Function checkdeleterole(ByVal controllerNamestr As String) As Boolean
            Try
                Using mySqlConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString)
                    Try
                        '------------------------------------------------
                        Dim strSql As String = "select deleteAction  from vwaspnetpageforUsers where deleteAction=0 and   UserName='" & HttpContext.Current.User.Identity.Name & "' and tablo='" & controllerNamestr & "'"
                        Dim ds1 As New DataSet()
                        Dim da1 As New SqlDataAdapter()
                        da1.SelectCommand = New SqlCommand(strSql, mySqlConnection)
                        da1.Fill(ds1)
                        If (ds1 IsNot Nothing AndAlso ds1.Tables(0).Rows.Count > 0) Then
                            Return True
                        Else
                            Return False


                        End If
                    Catch ex As Exception
                        Return False
                    Finally
                        If (mySqlConnection.State = ConnectionState.Open) Then mySqlConnection.Close()
                    End Try
                End Using




            Catch ex As Exception
                Return False
            End Try
        End Function


        Public Overrides Function SupportsVirtualization(ByVal controllerName As String) As Boolean
            Return True    'Not UserIsInRole("Administrators")
        End Function
        Protected Overrides Sub VirtualizeController(ByVal controllerName As String)
            '  NodeSet().SelectActions("ReportAsWord", "ReportAsPdf", "ReportAsImage", "ExportRss", "DataSheet", "Grid").Delete()


            If UserIsInRole("ReportAsExcel") Then
            Else
                NodeSet().SelectActions("ReportAsExcel").Delete()
                NodeSet().SelectActions("ExportCsv").Delete()
            End If
            If UserIsInRole("ExportRowset") Then
            Else
                NodeSet().SelectActions("ExportRowset").Delete()
            End If
            If UserIsInRole("Import") Then
            Else
                NodeSet().SelectActions("Import").Delete()
            End If
            If UserIsInRole("Administrator") Then

            Else
                '  NodeSet().SelectActions("ReportAsWord", "ReportAsPdf", "ReportAsImage").Delete()
                'If UserIsInRole("exportexcel") Then
                '    NodeSet().SelectActions("ReportAsWord", "ReportAsPdf", "ReportAsImage").Delete()
                'End If
                '-----------------------------
                If UserIsInRole("ReadOnley") Or (IsTagged("masterlist")) Then
                    'Dim restrictedCommands() As String =
                    '    {"Edit", "New", "Delete", "Duplicate", "Import"}
                    'Dim actionIterator As XPathNodeIterator = navigator.Select("//c:action", resolver)
                    'While (actionIterator.MoveNext())
                    '    Dim commandName As String = actionIterator.Current.GetAttribute(
                    '        "commandName", String.Empty)
                    '    If (restrictedCommands.Contains(commandName)) Then
                    '        actionIterator.Current.CreateAttribute(
                    '            String.Empty, "roles", String.Empty, "Administrators")
                    '    End If
                    'End While
                    Select Case controllerName
                        Case "AccnoDates", "_Dates", "_Dates1", "_Dates2", "_Dates3", "_Dates4", "AccnoDates1", "AccnoDates2", "AccnoDates3", "accinstallment1001"



                        Case Else
                            NodeSet().SelectActions("New", "Update", "Delete", "Insert", "Duplicate", "Import", "ExportCsv", "ExportRowset", "ExportRss", "DataSheet", "Grid", "ReportAsExcel") _
                                            .Delete()
                            NodeSet().SelectActionGroups("Grid") _
                                    .SelectActions("New", "Update", "Delete", "Edit", "Insert", "Duplicate", "Import", "ExportCsv", "ExportRowset", "ExportRss", "DataSheet", "Grid", "ReportAsExcel") _
                                    .Delete()

                    End Select
                Else
                    'Select Case controllerName



                    '    Case "GLmstrfl", "accountclasslist", "GLmfband", "GLmfbab"


                    '        '       If (IsTagged("runningcontract")) Then
                    '        '        End If
                    '        NodeSet().SelectActions("New", "Edit", "Delete", "Duplicate", "Import") _
                    '                    .Delete()
                    '        ' delete all remaining actions in the 'Grid' scope 
                    '        NodeSet().SelectActionGroups("Grid") _
                    '            .SelectActions() _
                    '            .Delete()
                    '        '            ' add new 'Navigate' action to the 'Grid' scope 
                    '        '            NodeSet().SelectActionGroups("Grid") _
                    '        '                .CreateAction(
                    '        '                    "Navigate",
                    '        '                    "ajrcontractrun.aspx?ajrCntrctSr={ajrCntrctSr}&_controller=ajrContracts" +
                    '        '                    "&_commandName=Edit&_commandArgument=editcontract")




                    'End Select

                End If
            End If
            'Dim myrolbool As Boolean = False
            'myrolbool = iseditinginmyrol(controllerName)
            'myrolbool = False
            'If (myrolbool) Then
            '    NodeSet().SelectActions("New", "Edit", "Delete", "Duplicate", "Import").Delete()
            'End If

            Dim regionLabel As XPathNavigator = Navigator.SelectSingleNode("/c:dataController/c:restConfig", Resolver)
            If (Not regionLabel Is Nothing) Then
            Else
                Navigator.SelectSingleNode("/c:dataController", Resolver).AppendChild("<restConfig>Uri: ." & vbCrLf & " Method: GET,POST,PUT,DELETE " & vbCrLf & " Users: * " & vbCrLf & " JSON: True   </restConfig>")


            End If

            'add here Rules from Rules in sitcontent Or sitRulesContent 
            'Dim regionLabel1 As XPathNavigator = Navigator.SelectSingleNode("/c:dataController/c:restConfig", Resolver)
            'If (Not regionLabel Is Nothing) Then
            'Else
            '    Navigator.SelectSingleNode("/c:dataController", Resolver).AppendChild("<restConfig>Uri: ." & vbCrLf & " Method: GET" & vbCrLf & " Users: * " & vbCrLf & " JSON: True   </restConfig>")
            'End If

            '"/c:dataController/c:fields/c:field[@name='Region']/@label"

            'Dim resapi As Object = NodeSet().Elem("/c:dataController/c:restConfig")
            'If (Not (resapi) Is Nothing) Then
            '    If resapi.nodes.count = 0 Then

            '        Dim resapi1 As ControllerNodeSet = NodeSet().Elem("/c:dataController")
            '        resapi1.AppendTo("c:restConfig").Value("mostafa")
            '    End If
            'End If
            Dim kf As String = String.Empty
            Dim iterator As Object = NodeSet().Select("/c:dataController/c:fields").Select("c:field[@isPrimaryKey='true']/@name")
            If (Not (iterator) Is Nothing) Then
                kf = iterator.ToString
            End If
            'workflow----- idfilter=" + Controller. +"&
            If IsNothing(iterator) Then
            Else
                If NodeSet().SelectActionGroup("ag2").IsEmpty Then
                Else

                    Dim reportviwerpath As String = "webreportviwer.aspx"

                    If (Information.IsNothing(ConfigurationManager.AppSettings("reportappurl"))) Then
                    Else

                        reportviwerpath = ConfigurationManager.AppSettings("reportappurl").ToString() + "/pages/webreportviwer.aspx"
                    End If

                    Dim AppCultureUInow As String = Left(LCase(CType(Thread.CurrentThread.CurrentUICulture.Name, String)), 2)

                    NodeSet().SelectActionGroups("Grid").CreateAction("Navigate", "_blank:" + reportviwerpath + "?idfilter={" + iterator.ToString + "}&lang=" + AppCultureUInow + "&reportquery=" + controllerName + "&reportquery=" + controllerName)
                    NodeSet().SelectActionGroups("Grid").CreateAction("ReportAsPdf", "DaynamicMrtReport", "Daynamic100001")
                    NodeSet().SelectActionGroups("Grid").CreateAction("ReportAsPdf", "newrpt", "mrt" & controllerName & "master")
                    NodeSet().SelectActionGroups("Grid").SelectAction("mrt" & controllerName & "master").Attr("headerText", translatemeyamosso.GetResourceValuemosso("mrt" & controllerName & "master"))

                End If
            End If
            '"webreportviwerDyn.aspx?reportquery=" + controllerName + "", "mrt100001")
            Select Case controllerName
                Case "schvchdlydetailreg1001", "schvchdlydetailpayment1001"
                Case Else
                    Dim dtDataTable As DataTable
                    dtDataTable = GetData("select * from mrtcontrollerName where controllerName<>ReportCode and   controllerName='" & controllerName & "' order by controllerNameid")

                    If dtDataTable.Rows.Count > 0 Then
                        Dim row As DataRow
                        Dim strDetail As String = ""
                        Dim strDetailid As Double = 0
                        'NodeSet().Select("/c:dataController/c:actions").CreateActionGroup("ag7pdfmos1")

                        'NodeSet().SelectActionGroup("ag7pdfmos1").Attr("headerText", translatemeyamosso.GetResourceValuemosso("PdfReports1"))
                        'NodeSet().Select("/c:dataController/c:actions").CreateActionGroup("ag7xlxmos1")

                        'NodeSet().SelectActionGroup("ag7xlxmos1").Attr("headerText", translatemeyamosso.GetResourceValuemosso("xlxReports1"))

                        For Each row In dtDataTable.Rows
                            strDetailid = Convert.ToDouble(row("controllerNameid"))
                            strDetailid = 10000 + strDetailid
                            If NodeSet().SelectActionGroup("ag7").IsEmpty Then
                            Else
                                NodeSet().SelectActionGroup("ag7").CreateAction("ReportAsPdf", "", row("ReportCode"))
                                NodeSet().SelectActionGroup("ag7").SelectAction(row("ReportCode")).Attr("headerText", translatemeyamosso.GetResourceValuemosso(row("ReportCode")))
                            End If

                            If NodeSet().SelectActionGroup("ag7pdfmos").IsEmpty Then
                            Else

                                NodeSet().SelectActionGroup("ag7pdfmos").CreateAction("ReportAsPdf", "mospdf", row("ReportCode"))
                                NodeSet().SelectActionGroup("ag7pdfmos").SelectAction(row("ReportCode")).Attr("headerText", translatemeyamosso.GetResourceValuemosso(row("ReportCode")))
                            End If
                            If NodeSet().SelectActionGroup("ag7xlxmos").IsEmpty Then

                            Else
                                NodeSet().SelectActionGroup("ag7xlxmos").CreateAction("ReportAsPdf", "mosxlx", row("ReportCode"))
                                NodeSet().SelectActionGroup("ag7xlxmos").SelectAction(row("ReportCode")).Attr("headerText", translatemeyamosso.GetResourceValuemosso(row("ReportCode")))
                            End If

                        Next row
                        If UserIsInRole("ReportDesigner") Then
                            Dim newnumberreport As String
                            newnumberreport = strDetailid + 1
                            newnumberreport = 10000 + newnumberreport
                            If NodeSet().SelectActionGroup("ag7").IsEmpty Then
                            Else
                                NodeSet().SelectActionGroup("ag7").CreateAction("ReportAsPdf", "newrpt", "mrt" & controllerName & newnumberreport)
                                NodeSet().SelectActionGroup("ag7").SelectAction("mrt" & controllerName & newnumberreport).Attr("headerText", translatemeyamosso.GetResourceValuemosso("NewReport"))
                            End If
                        End If
                    Else
                        If UserIsInRole("ReportDesigner") Then
                            If NodeSet().SelectActionGroup("ag7").IsEmpty Then
                            Else
                                NodeSet().SelectActionGroup("ag7").CreateAction("ReportAsPdf", "newrpt", "mrt" & controllerName & "100001")
                                NodeSet().SelectActionGroup("ag7").SelectAction("mrt" & controllerName & "100001").Attr("headerText", translatemeyamosso.GetResourceValuemosso("NewReport"))
                            End If
                        End If
                    End If
                    If UserIsInRole("ReportDesigner") Then
                        If NodeSet().SelectActionGroup("ag7").IsEmpty Then
                        Else
                            NodeSet().SelectActionGroup("ag7").CreateAction("ReportAsPdf", "DaynamicMrtReport", "Daynamic100001")
                        End If
                    End If
            End Select
        End Sub





        Public Function iseditinginmyrol(ByVal controllerNamestr As String) As Boolean
            Try
                If (HttpContext.Current.Session("rolesList") IsNot Nothing) Then
                    Dim dt As New DataTable
                    dt = CType(HttpContext.Current.Session("rolesList"), DataTable)
                    Dim filterExp As String = "Rolesname = '" & controllerNamestr & "'"
                    Dim sortExp As String = "Rolesname"
                    Dim drarray() As DataRow
                    'Dim i As Integer
                    drarray = dt.Select(filterExp, sortExp, DataViewRowState.CurrentRows)
                    If drarray.Length > 0 Then

                        Return False

                    Else
                        Return True
                    End If
                Else
                    Return False

                End If
            Catch ex As Exception
                Return True
            End Try



        End Function




        Function authorizedme(ByVal varclass As String) As String
            'Try

            If (HttpContext.Current.Session("rolesList") Is Nothing) Then
                Using mySqlConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("LocalSqlServer").ToString)
                    'Try

                    '------------------------------------------------
                    Dim strSql As String = "select pagesname as Rolesname from vwaspnetpageforUsers where  UserName='" & HttpContext.Current.User.Identity.Name & "'"
                    Dim ds1 As New DataSet()
                    Dim da1 As New SqlDataAdapter()
                    da1.SelectCommand = New SqlCommand(strSql, mySqlConnection)
                    da1.Fill(ds1)
                    If (ds1 IsNot Nothing AndAlso ds1.Tables.Count > 0) Then
                        System.Web.HttpContext.Current.Session("rolesList") = ds1.Tables(0)
                    Else
                        System.Web.HttpContext.Current.Session("rolesList") = Nothing

                    End If
                    ' Catch ex As Exception
                    ' Finally
                    'If (mySqlConnection.State = ConnectionState.Open) Then mySqlConnection.Close()
                    ' End Try
                End Using

            End If
            If (HttpContext.Current.Session("rolesList") IsNot Nothing) Then
                Dim dt As New DataTable
                dt = CType(HttpContext.Current.Session("rolesList"), DataTable)
                Dim filterExp As String = "Rolesname = '" & varclass & "'"
                Dim sortExp As String = "Rolesname"
                Dim drarray() As DataRow
                Dim i As Integer
                drarray = dt.Select(filterExp, sortExp, DataViewRowState.CurrentRows)
                If drarray.Length > 0 Then
                    For i = 0 To (drarray.Length - 1)
                        Return drarray(i)("Rolesname").ToString
                    Next
                Else
                    Return " "
                End If
            Else
                Return varclass


            End If

            'Catch ex As Exception
            ' End Try


            Return varclass
        End Function


    End Class

End Namespace


Namespace eZee.Web

    Partial Public Class PageBase
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not (IsPostBack) Then
                Dim rolesstringtitle As String
                rolesstringtitle = Right(Me.Page.AppRelativeVirtualPath, Len(Me.Page.AppRelativeVirtualPath) - Len(Me.Page.AppRelativeTemplateSourceDirectory))
                rolesstringtitle = Left(rolesstringtitle, Len(rolesstringtitle) - 5)
                Me.Page.Title = translatemeyamosso.GetResourceValuemosso(Me.Page.Title) 'rolesstringtitle
                Dim d As System.DateTime
                d = DateTime.Now
                If DateValue(d.ToString) > DateValue("2022-10-13") Then
                    '' MsgBox("wow", MsgBoxStyle.Exclamation, "teto")
                    'rolesList
                    Context.Response.Redirect("~/pages/Expires.html")
                End If

                Dim pagepath As String = Request.FilePath
                    Dim xnode As SiteMapNode
                    Dim stmap As Control = FindControlRecursive(Me.Page, "SiteMapDataSource1")
                    If IsNothing(stmap) Then
                    Else
                        Form.Controls.Remove(stmap)
                    End If
                    'SiteMapDataSource
                    Dim siteMapDataSource1 = New SiteMapDataSource()
                    siteMapDataSource1.ID = "SiteMapDataSource1"
                    If IsNothing(siteMapDataSource1.Provider.CurrentNode) Then
                    Else
                        xnode = siteMapDataSource1.Provider.GetParentNode(siteMapDataSource1.Provider.CurrentNode)
                        Dim xpathme As String = xnode.RootNode.Title
                    End If

                    If Len(Request.FilePath) > 7 Then
                        Dim pagename As String
                        pagename = Path.GetFileName(Request.FilePath)
                        '    pagename = Right(Request.Path, Len(Request.Path) - 7)
                        pagename = Left(pagename, Len(pagename) - 5)

                        Dim SiteMapPathphysical As String = Server.MapPath("/appsitemap/" + pagename + ".sitemap")
                        If File.Exists(SiteMapPathphysical) Then
                            HttpContext.Current.Session("SiteMapProviderssessionname") = pagename
                        End If
                        If (HttpContext.Current.Session("SiteMapProviderssessionname") IsNot Nothing) Then
                        Else
                            HttpContext.Current.Session("SiteMapProviderssessionname") = "Home"
                        End If
                        SiteMapPathphysical = Server.MapPath("/appsitemap/" + HttpContext.Current.Session("SiteMapProviderssessionname") + ".sitemap")
                        Dim sitmapfile As String = HttpContext.Current.Session("SiteMapProviderssessionname").ToString()
                        If File.Exists(SiteMapPathphysical) Then
                            '1- check nod in web.config
                            '2- add nod to providers in web.config
                            'initialize the schema
                            Dim foundprovider As Integer = 0
                            Dim mossoxmldocument As New XmlDocument
                            mossoxmldocument.Load(Server.MapPath("/web.config"))
                            Dim mnodelist As XmlNodeList
                            mnodelist = mossoxmldocument.SelectNodes("configuration/system.web/siteMap/providers/add")
                            Dim mossonode As XmlNode
                            For Each mossonode In mnodelist
                                Dim strnode As String
                                Dim strname As String
                                strnode = mossonode.Attributes("name").Value
                                If HttpContext.Current.Session("SiteMapProviderssessionname") = strnode Then
                                    foundprovider = 1
                                End If
                                strname = mossonode.Attributes("type").Value


                            Next
                            If foundprovider = 1 Then
                                siteMapDataSource1.Provider = SiteMap.Providers(HttpContext.Current.Session("SiteMapProviderssessionname").ToString())

                            ElseIf foundprovider = 0 Then
                                '1- add node in web.confid
                                Dim mossonodemaster As XmlNode
                                mossonodemaster = mossoxmldocument.SelectSingleNode("configuration/system.web/siteMap/providers")
                                If IsNothing(mossonodemaster) = False Then


                                    Dim mossonodechild As XmlNode
                                    mossonodechild = mossoxmldocument.CreateNode(XmlNodeType.Element, "add", "")
                                    '//Create a New attribute.
                                    'String ns = root.GetNamespaceOfPrefix("bk");
                                    'XmlNode attr = doc.CreateNode(XmlNodeType.Attribute, "genre", ns);
                                    'attr.Value = "novel";
                                    Dim attr As XmlNode = mossoxmldocument.CreateNode(XmlNodeType.Attribute, "name", "")
                                    attr.Value = "" + sitmapfile + ""
                                    mossonodechild.Attributes.SetNamedItem(attr)
                                    '-----------------------------------------------
                                    Dim attr1 As XmlNode = mossoxmldocument.CreateNode(XmlNodeType.Attribute, "type", "")
                                    attr1.Value = "eZee.Services.ApplicationSiteMapProvider"
                                    mossonodechild.Attributes.SetNamedItem(attr1)
                                    '-----------------------------------------------
                                    Dim attr2 As XmlNode = mossoxmldocument.CreateNode(XmlNodeType.Attribute, "siteMapFile", "")
                                    attr2.Value = "appsitemap/" + sitmapfile + ".sitemap"
                                    mossonodechild.Attributes.SetNamedItem(attr2)
                                    '----------------------------------------------------
                                    Dim attr3 As XmlNode = mossoxmldocument.CreateNode(XmlNodeType.Attribute, "securityTrimmingEnabled", "")
                                    attr3.Value = "true"
                                    mossonodechild.Attributes.SetNamedItem(attr3)
                                    '--------------------------------------------------
                                    mossonodemaster.AppendChild(mossonodechild)

                                    mossoxmldocument.Save(Server.MapPath("/web.config"))
                                    siteMapDataSource1.Provider = SiteMap.Providers(sitmapfile)
                                End If
                            End If
                            siteMapDataSource1.ShowStartingNode = False
                            Form.Controls.Add(siteMapDataSource1)
                        End If
                    End If
                End If

        End Sub
        Function FindControlRecursive(ByVal ctrl As Control,
            ByVal id As String) As Control
            ' Exit if this is the control we're looking for.
            If ctrl.ID = id Then Return ctrl

            ' Else, look in the hiearchy.
            Dim childCtrl As Control


            For Each childCtrl In ctrl.Controls
                Dim resCtrl As Control = FindControlRecursive(childCtrl, id)
                ' Exit if we've found the result
                If Not resCtrl Is Nothing Then Return resCtrl
            Next
        End Function
        '''Private Sub ConfigureNodeTargets1(ByVal nodes As RadSiteMapNodeCollection)
        '''    For Each n As RadSiteMapNode In nodes
        '''        Dim m As Match = Regex.Match(n.NavigateUrl, "^(_\w+):(.+)$")
        '''        If m.Success Then
        '''            n.Target = m.Groups(1).Value
        '''            n.NavigateUrl = m.Groups(2).Value
        '''        End If
        '''        n.Text = GetResourceValuemosso(n.Text)
        '''        ConfigureNodeTargets1(n.Nodes)
        '''    Next
        '''End Sub
        Private Sub ConfigureNodeTargets(ByVal nodes As TreeNodeCollection)
            For Each n As TreeNode In nodes
                Dim m As Match = Regex.Match(n.NavigateUrl, "^(_\w+):(.+)$")
                If m.Success Then
                    n.Target = m.Groups(1).Value
                    n.NavigateUrl = m.Groups(2).Value
                End If
                n.Text = GetResourceValuemosso(n.Text)

                ConfigureNodeTargets(n.ChildNodes)
            Next
        End Sub
        Function authorizedme(ByVal varclass As String) As String
            Try
                If (HttpContext.Current.Session("rolesList") IsNot Nothing) Then
                    Dim dt As New DataTable
                    dt = CType(HttpContext.Current.Session("rolesList"), DataTable)
                    Dim filterExp As String = "Rolesname = '" & varclass & "'"
                    Dim sortExp As String = "Rolesname"
                    Dim drarray() As DataRow
                    Dim i As Integer
                    drarray = dt.Select(filterExp, sortExp, DataViewRowState.CurrentRows)
                    If drarray.Length > 0 Then
                        For i = 0 To (drarray.Length - 1)
                            Return drarray(i)("Rolesname").ToString
                        Next
                    Else
                        Return " "
                    End If
                Else
                    Return varclass

                End If
            Catch ex As Exception
            End Try

            Return varclass
        End Function
    End Class
End Namespace


