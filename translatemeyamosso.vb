Imports System.Data.SqlClient
Imports System.Configuration							
Imports System.Threading
Imports System.Data
Imports eZee.Data
Imports System.IO

Public Class translatemeyamosso
    Private Sub New()
    End Sub
    Public Shared Function GetResourceValuemosso(ByVal keyVal As String) As String


        If keyVal <> "" Then

            Dim AppCultureUInow As String = Left(LCase(CType(Thread.CurrentThread.CurrentUICulture.Name, String)), 2)

            Return CheckTranslateen(keyVal, AppCultureUInow)
        Else
            Return keyVal

        End If

    End Function
    Public Shared Function GetResourcemosso(ByVal keyVal As String) As String
        ''url="~/Pages/Homecar.aspx"

        If String.IsNullOrEmpty(keyVal) Or String.IsNullOrWhiteSpace(keyVal) Then
            Return myvirtualpathfun() + "images/dashboard/10001.png"
        Else
            Dim urlfilanl As String = keyVal
            urlfilanl = Path.GetFileName(urlfilanl)
            '' urlfilanl = Left(urlfilanl, Len(urlfilanl) - 5)
            If IsNothing(ConfigurationManager.AppSettings("imagepath")) = False Then

                urlfilanl = ConfigurationManager.AppSettings("imagepath").ToString() + "/images/dashboard/" + urlfilanl + ".png"



                If (System.IO.File.Exists(urlfilanl)) Then
                    Return urlfilanl
                Else
                    Return myvirtualpathfun() + "images/dashboard/10001.png"
                End If
            Else



                Dim filpathe As String = MyMapPath("/images/dashboard")

                If (System.IO.File.Exists(filpathe + "\" + urlfilanl + ".png")) Then


                    urlfilanl = myvirtualpathfun() + "images/dashboard/" + urlfilanl + ".png"
                    Return urlfilanl
                Else
                    Return myvirtualpathfun() + "images/dashboard/10001.png"
                End If
            End If
        End If
    End Function
    Public Shared Function myvirtualpathfun() As String
        Dim myvirtualpath As String = ""
        If HttpContext.Current.Request.ApplicationPath = "/" Then
            myvirtualpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpContext.Current.Request.ApplicationPath
        Else
            myvirtualpath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpContext.Current.Request.ApplicationPath + "/"
        End If

        Return myvirtualpath
    End Function
    Public Shared Function MyMapPath(path As String) As String
        If HttpContext.Current.Request.ApplicationPath = "/" Then
        Else
            path = HttpContext.Current.Request.ApplicationPath + path

        End If
        Return HttpContext.Current.Server.MapPath(path)

    End Function
    ' Variable used to prevent infinite loop
    Public Shared Function GetResourcemosso1(ByVal AppRelativeTemplateSourceDirectory As String, ByVal AppRelativeVirtualPath As String) As String
        ''url="~/Pages/Homecar.aspx"

        If String.IsNullOrEmpty(AppRelativeTemplateSourceDirectory) Or String.IsNullOrWhiteSpace(AppRelativeTemplateSourceDirectory) Then
            Return "../images/dashboard/10001.png"
        Else


            Dim urlfilanl As String = Right(AppRelativeVirtualPath, Len(AppRelativeVirtualPath) - Len(AppRelativeTemplateSourceDirectory) + 1)
            urlfilanl = Left(urlfilanl, Len(urlfilanl) - 5)

            Dim appDirectory As String = HttpContext.Current.Server.MapPath("~")

            If (System.IO.File.Exists(appDirectory + "\images\dashboard\" + urlfilanl + ".png")) Then
                urlfilanl = "../images/dashboard/" + urlfilanl + ".png"
                Return urlfilanl
            Else
                Return "../images/dashboard/10001.png"
            End If
        End If
    End Function

    Public Shared Function GetVirtualPath(ByVal physicalPath As String) As String
        Dim rootpath As String = HttpContext.Current.Server.MapPath("~/")
        physicalPath = physicalPath.Replace(rootpath, "")
        physicalPath = physicalPath.Replace("\\", "/")
        Return "~/" + physicalPath
    End Function
    Public Shared Function GetResourceValue(ByVal keyVal As String, ByVal appName As String) As String

        If keyVal <> "" Then

            Dim AppCultureUInow As String = UCase(CType(System.Threading.Thread.CurrentThread.CurrentUICulture.Name, String))


            Return CheckTranslateen(keyVal, AppCultureUInow)


        Else
            Return keyVal
        End If



    End Function

    Public Shared Function GetResourceValue(ByVal keyVal As String) As String


        If keyVal <> "" Then

            Dim AppCultureUInow As String = LCase(CType(System.Threading.Thread.CurrentThread.CurrentUICulture.Name, String))
            Return CheckTranslateen(keyVal, AppCultureUInow)
        Else
            Return keyVal
        End If



    End Function

    Public Shared Function CheckTranslatear(ByVal varclass As String) As String
        Try
            If (HttpContext.Current.Session("TransaltsystemList") IsNot Nothing) Then

                Dim dt As New DataTable
                dt = CType(HttpContext.Current.Session("TransaltsystemList"), DataTable)
                Dim filterExp As String = "contolname = '" & Trim(varclass) & "'"
                Dim sortExp As String = "contolname"
                Dim drarray() As DataRow
                Dim i As Integer
                drarray = dt.Select(filterExp, sortExp, DataViewRowState.CurrentRows)
                For i = 0 To (drarray.Length - 1)
                    Return drarray(i)("ar").ToString
                Next
            Else
                Using mySqlConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("ezee").ToString)
                    Try
                        '------------------------------------------------
                        Dim strSql As String = "select rtrim(ltrim(contolname)) as contolname,en,ar from Transaltsystem"
                        Dim ds1 As New DataSet()
                        Dim da1 As New SqlDataAdapter()
                        da1.SelectCommand = New SqlCommand(strSql, mySqlConnection)
                        da1.Fill(ds1)
                        If (ds1 IsNot Nothing AndAlso ds1.Tables.Count > 0) Then
                            System.Web.HttpContext.Current.Session("TransaltsystemList") = ds1.Tables(0)
                        Else
                            System.Web.HttpContext.Current.Session("TransaltsystemList") = Nothing
                        End If
                    Catch ex As Exception
                    Finally
                        If (mySqlConnection.State = ConnectionState.Open) Then mySqlConnection.Close()
                    End Try
                End Using
                If (HttpContext.Current.Session("TransaltsystemList") IsNot Nothing) Then
                    Dim dt As New DataTable
                    dt = CType(HttpContext.Current.Session("TransaltsystemList"), DataTable)
                    Dim filterExp As String = "contolname = '" & Trim(varclass) & "'"
                    Dim sortExp As String = "contolname"
                    Dim drarray() As DataRow
                    Dim i As Integer
                    drarray = dt.Select(filterExp, sortExp, DataViewRowState.CurrentRows)
                    For i = 0 To (drarray.Length - 1)
                        Return drarray(i)("ar").ToString
                    Next
                End If

            End If
        Catch ex As Exception
        End Try

        Return varclass
    End Function

    Public Shared Function CheckTranslateen(ByVal varclass As String, ByVal AppCultureUInow As String) As String
        Try

            If (HttpContext.Current.Session("TransaltsystemList") IsNot Nothing) Then
                Dim dt As New DataTable
                dt = CType(HttpContext.Current.Session("TransaltsystemList"), DataTable)
                Dim filterExp As String = "contolname = '" & Trim(varclass) & "'"
                Dim sortExp As String = "contolname"
                Dim drarray() As DataRow
                Dim i As Integer
                Dim transresult As String = ""
                drarray = dt.Select(filterExp, sortExp, DataViewRowState.CurrentRows)
                For i = 0 To (drarray.Length - 1)
                    transresult = drarray(i)(AppCultureUInow).ToString()
                    If Len(Trim(transresult)) > 0 Then
                        Return transresult
                    Else
                        Return varclass
                    End If

                Next
            Else
                Using mySqlConnection As New SqlConnection(ConnectionStringSettingsFactory.getconnection().ConnectionString)
                    Try
                        '------------------------------------------------
                        Dim strSql As String = "select rtrim(ltrim(contolname)) as contolname,* from Transaltsystem"
                        Dim ds1 As New DataSet()
                        Dim da1 As New SqlDataAdapter()
                        da1.SelectCommand = New SqlCommand(strSql, mySqlConnection)
                        da1.Fill(ds1)
                        If (ds1 IsNot Nothing AndAlso ds1.Tables.Count > 0) Then
                            System.Web.HttpContext.Current.Session("TransaltsystemList") = ds1.Tables(0)
                        Else
                            System.Web.HttpContext.Current.Session("TransaltsystemList") = Nothing
                        End If
                    Catch ex As Exception
                    Finally
                        If (mySqlConnection.State = ConnectionState.Open) Then mySqlConnection.Close()
                    End Try
                End Using
                If (HttpContext.Current.Session("TransaltsystemList") IsNot Nothing) Then
                    Dim dt As New DataTable
                    dt = CType(HttpContext.Current.Session("TransaltsystemList"), DataTable)
                    Dim filterExp As String = "contolname = '" & Trim(varclass) & "'"
                    Dim sortExp As String = "contolname"
                    Dim drarray() As DataRow
                    Dim i As Integer
                    Dim transresult As String = ""
                    drarray = dt.Select(filterExp, sortExp, DataViewRowState.CurrentRows)
                    For i = 0 To (drarray.Length - 1)
                        transresult = drarray(i)(AppCultureUInow).ToString()
                        If Len(transresult) > 0 Then
                            Return transresult
                        Else
                            Return varclass
                        End If

                    Next
                End If

            End If
        Catch ex As Exception
        End Try

        Return varclass
    End Function



End Class