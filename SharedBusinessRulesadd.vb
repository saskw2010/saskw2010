Imports Microsoft.VisualBasic
Imports eZee.Data
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports eZee.Web
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Xml.XPath
Imports System.Xml
Imports System.ComponentModel
Imports System.Text
Imports System.Data.SqlClient
Imports translatemeyamosso
Imports System.Configuration
Imports System.Data.Common
Imports System.IO
Imports System.Transactions
Imports System.Web
Imports System.Web.Caching
Imports System.Web.Configuration
Imports System.Web.Security
Imports System.Xml.Xsl
Imports System.Reflection
Imports DataLogic

Namespace eZee.Services


    Partial Public Class ApplicationServices
        Inherits EnterpriseApplicationServices
        Public Overridable Sub CreateStandardMembershipAccountslooping(ByVal username As String, ByVal password As String, ByVal approles As String)
            If (Membership.GetUser(username) Is Nothing) Then
                Dim status As MembershipCreateStatus
                Dim unused As MembershipUser = Membership.CreateUser(username, password, username + "@wytsky.com", "aaa", "a", True, status)
                Using calc As SqlText = New SqlText(" insert into AspNetUserRoles(UserId,RoleId) select AspNetUsers.id as UserId,AspNetRoles.id as RoleId from AspNetUsers cross join AspNetRoles where (AspNetUsers.username='" + username + "' and AspNetRoles.Name='filteAppPage') or (AspNetUsers.username='" + username + "' and AspNetRoles.Name='" + approles + "')")
                    calc.ExecuteNonQuery()
                End Using
            End If
        End Sub
        Public Overridable Sub electionusercreationcheck()
            Dim dt As New DataTable
            dt = DataLogic.GetData("select meteername3,meteername4 from electionmotran where meteername3 is not null")
            For counter As Integer = 0 To dt.Rows.Count - 1

                Dim username As String = dt.Rows(counter)(0).ToString
                Dim password As String = dt.Rows(counter)(1).ToString

                CreateStandardMembershipAccountslooping(username, "lsky@365", "electedPrepareAppPage")

            Next counter

            ' agentAppPage

            Dim dtg As New DataTable
            dtg = DataLogic.GetData("select madmon,'gsky@365' as passwordg from electionmotran where madmon is not null group by madmon")
            For counterg As Integer = 0 To dtg.Rows.Count - 1

                Dim usernameg As String = dtg.Rows(counterg)(0).ToString
                Dim passwordg As String = dtg.Rows(counterg)(1).ToString

                CreateStandardMembershipAccountslooping(usernameg, "gsky@365", "agentAppPage")

            Next counterg
            '----------------------------------


            Dim dt1 As New DataTable
            dt1 = DataLogic.GetData("select electionareaid,'censky@365' as passwordm from Electionmadameenmain where electionareaid is not null group by electionareaid ")
            For counter1 As Integer = 0 To dt1.Rows.Count - 1

                Dim username1 As String = dt1.Rows(counter1)(0).ToString
                Dim password1 As String = dt1.Rows(counter1)(1).ToString

                CreateStandardMembershipAccountslooping(username1, "censky@365", "centralCommitteeApp")

            Next counter1
            Dim dt2 As New DataTable
            dt2 = DataLogic.GetData("select right(ElectionmadameenTel,8) as ElectionmadameenTel ,usernamemain  from Electionmadameenmain  where usernamemain is not  null")
            For counter2 As Integer = 0 To dt2.Rows.Count - 1

                Dim username2 As String = dt2.Rows(counter2)(0).ToString
                Dim password2 As String = dt2.Rows(counter2)(1).ToString + "@sky"

                CreateStandardMembershipAccountslooping(username2, password2, "moderatorAppPage")

            Next counter2


        End Sub

        Public Overrides Sub CreateStandardMembershipAccounts()
            'Create a separate code file with a definition of the partial class ApplicationServices overriding
            'this method to prevent automatic registration of 'admin' and 'user'. Do not change this file directly.
            ' RegisterStandardMembershipAccounts()
            'and AspNetRoles.Name='filteAppPage'

            Using calc1 As SqlText = New SqlText("exec dbo.fixuserlist")
                calc1.ExecuteNonQuery()
            End Using




            If (Membership.GetUser("sky365") Is Nothing) Then
                Dim status As MembershipCreateStatus
                Dim unused As MembershipUser = Membership.CreateUser("sky365", "sky365@365", "sky@wytsky.com", "aaa", "a", True, status)
                Using calc As SqlText = New SqlText(" insert into AspNetUserRoles(UserId,RoleId) select AspNetUsers.id as UserId,AspNetRoles.id as RoleId from AspNetUsers cross join AspNetRoles where AspNetUsers.username='sky365'")
                    calc.ExecuteNonQuery()
                End Using
            End If
            If (Membership.GetUser("wytsky2020") Is Nothing) Then
                Dim status As MembershipCreateStatus
                Dim unused As MembershipUser = Membership.CreateUser("wytsky2020", "wytsky@365", "wytsky2020@wytsky.com", "aaa", "a", True, status)
                Using calc As SqlText = New SqlText(" insert into AspNetUserRoles(UserId,RoleId) select AspNetUsers.id as UserId,AspNetRoles.id as RoleId from AspNetUsers cross join AspNetRoles where AspNetUsers.username='wytsky2020'")
                    calc.ExecuteNonQuery()
                End Using
            End If
            If (Membership.GetUser("user5") Is Nothing) Then
                Dim status As MembershipCreateStatus
                Dim unused5 As MembershipUser = Membership.CreateUser("user5", "user5@365", "user5@wytsky.com", "aaa", "a", True, status)
                Using calc As SqlText = New SqlText(" insert into AspNetUserRoles(UserId,RoleId) select AspNetUsers.id as UserId,AspNetRoles.id as RoleId from AspNetUsers cross join AspNetRoles where AspNetUsers.username='user5'")
                    calc.ExecuteNonQuery()
                End Using
            End If
            If (Membership.GetUser("user4") Is Nothing) Then
                Dim status As MembershipCreateStatus
                Dim unused4 As MembershipUser = Membership.CreateUser("user4", "user4@365", "user4@wytsky.com", "aaa", "a", True, status)
                Using calc As SqlText = New SqlText(" insert into AspNetUserRoles(UserId,RoleId) select AspNetUsers.id as UserId,AspNetRoles.id as RoleId from AspNetUsers cross join AspNetRoles where AspNetUsers.username='user4'")
                    calc.ExecuteNonQuery()
                End Using
            End If

            If (Membership.GetUser("user3") Is Nothing) Then
                Dim status As MembershipCreateStatus
                Dim unused3 As MembershipUser = Membership.CreateUser("user3", "user3@365", "user3@wytsky.com", "aaa", "a", True, status)
                Using calc As SqlText = New SqlText(" insert into AspNetUserRoles(UserId,RoleId) select AspNetUsers.id as UserId,AspNetRoles.id as RoleId from AspNetUsers cross join AspNetRoles where AspNetUsers.username='user3'")
                    calc.ExecuteNonQuery()
                End Using
            End If

            If (Membership.GetUser("user2") Is Nothing) Then
                Dim status As MembershipCreateStatus
                Dim unused2 As MembershipUser = Membership.CreateUser("user2", "user2@365", "user2@wytsky.com", "aaa", "a", True, status)
                Using calc As SqlText = New SqlText(" insert into AspNetUserRoles(UserId,RoleId) select AspNetUsers.id as UserId,AspNetRoles.id as RoleId from AspNetUsers cross join AspNetRoles where AspNetUsers.username='user2'")
                    calc.ExecuteNonQuery()
                End Using
            End If
            If (Membership.GetUser("user1") Is Nothing) Then
                Dim status As MembershipCreateStatus
                Dim unused1 As MembershipUser = Membership.CreateUser("user1", "user1@365", "user1@wytsky.com", "aaa", "a", True, status)
                Using calc As SqlText = New SqlText(" insert into AspNetUserRoles(UserId,RoleId) select AspNetUsers.id as UserId,AspNetRoles.id as RoleId from AspNetUsers cross join AspNetRoles where AspNetUsers.username='user1'")
                    calc.ExecuteNonQuery()
                End Using
            End If

            Using calc1 As SqlText = New SqlText("exec dbo.fixuserlistroles")
                calc1.ExecuteNonQuery()
            End Using

            ' call election usercreate sub
            ' electionusercreationcheck()


        End Sub


    End Class
End Namespace

Namespace eZee.Data


    Partial Public Class ConnectionStringSettingsFactory
        Protected Overrides Function CreateSettings(connectionStringName As String) As ConnectionStringSettings

            Dim settings As New ConnectionStringSettings With {
                .Name = connectionStringName,
                .ProviderName = "System.Data.SqlClient",
                .ConnectionString = "Data Source=.;Initial Catalog=xxxx;Persist Security Info=True;User ID=xxx;Password=mos@2017;"
            }

            If IsNothing(ConfigurationManager.AppSettings("" & connectionStringName & "ProviderName")) Then
                settings.ProviderName = "System.Data.SqlClient"
            Else
                settings.ProviderName = ConfigurationManager.AppSettings("" & connectionStringName & "ProviderName").ToString()
            End If
            If IsNothing(ConfigurationManager.AppSettings("" & connectionStringName & "ConnectionString")) Then
                If IsNothing(ConfigurationManager.ConnectionStrings(connectionStringName)) Then
                    settings.ConnectionString = "Data Source=.;Initial Catalog=ALSADEQeZee;Persist Security Info=True;User ID=sa;Password=mos@2017;"
                Else
                    settings.ConnectionString = ConfigurationManager.ConnectionStrings(connectionStringName).ConnectionString
                End If
            Else
                settings.ConnectionString = ConfigurationManager.AppSettings("" & connectionStringName & "ConnectionString").ToString()
            End If




            'If (HttpContext.Current.User) IsNot Nothing Then
            'If HttpContext.Current.User.Identity.IsAuthenticated Then
            'End If
            'End If

            Dim csb As New SqlConnectionStringBuilder(settings.ConnectionString)
            Dim urlstring As String
            If IsNothing(ConfigurationManager.AppSettings("imagepath")) Then

                If IsNothing(ConfigurationManager.AppSettings("ChartImageHandlerphras")) Then
                    urlstring = "sa"
                Else
                    urlstring = Right(ConfigurationManager.AppSettings("ChartImageHandlerphras").ToString(), Len(ConfigurationManager.AppSettings("ChartImageHandlerphras").ToString()) - 5)
                End If

                Dim urlstring1 As String
                If IsNothing(ConfigurationManager.AppSettings("ChartImageHandlerphras1")) Then
                    urlstring1 = "mos@2017"
                Else
                    urlstring1 = Right(ConfigurationManager.AppSettings("ChartImageHandlerphras1").ToString(), Len(ConfigurationManager.AppSettings("ChartImageHandlerphras1").ToString()) - 5)
                End If
                csb.UserID = urlstring
                csb.Password = urlstring1
                settings = New ConnectionStringSettings(Nothing, "Data Source=" + csb.DataSource + ";Initial Catalog=" + csb.InitialCatalog + ";Persist Security Info=True;User ID=" + csb.UserID + ";Password=" + csb.Password + ";", settings.ProviderName)
            End If

            Return settings
        End Function
        Public Shared Function CreateSettings1(ByVal connectionStringName As String) As ConnectionStringSettings
            Dim settings As New ConnectionStringSettings With {
                .Name = connectionStringName,
                .ProviderName = "System.Data.SqlClient",
                .ConnectionString = "Data Source=.;Initial Catalog=xxxx;Persist Security Info=True;User ID=xxx;Password=mos@2017;"
            }

            If IsNothing(ConfigurationManager.AppSettings("" & connectionStringName & "ProviderName")) Then
                settings.ProviderName = "System.Data.SqlClient"
            Else
                settings.ProviderName = ConfigurationManager.AppSettings("" & connectionStringName & "ProviderName").ToString()
            End If
            If IsNothing(ConfigurationManager.AppSettings("" & connectionStringName & "ConnectionString")) Then
                If IsNothing(ConfigurationManager.ConnectionStrings(connectionStringName)) Then
                    settings.ConnectionString = "Data Source=.;Initial Catalog=ALSADEQeZee;Persist Security Info=True;User ID=sa;Password=mos@2017;"
                Else
                    settings.ConnectionString = ConfigurationManager.ConnectionStrings(connectionStringName).ConnectionString
                End If
            Else
                    settings.ConnectionString = ConfigurationManager.AppSettings("" & connectionStringName & "ConnectionString").ToString()
            End If




            'If (HttpContext.Current.User) IsNot Nothing Then
            'If HttpContext.Current.User.Identity.IsAuthenticated Then
            'End If
            'End If

            Dim csb As New SqlConnectionStringBuilder(settings.ConnectionString)
            Dim urlstring As String
            If IsNothing(ConfigurationManager.AppSettings("imagepath")) Then

                If IsNothing(ConfigurationManager.AppSettings("ChartImageHandlerphras")) Then
                    urlstring = "sa"
                Else
                    urlstring = Right(ConfigurationManager.AppSettings("ChartImageHandlerphras").ToString(), Len(ConfigurationManager.AppSettings("ChartImageHandlerphras").ToString()) - 5)
                End If

                Dim urlstring1 As String
                If IsNothing(ConfigurationManager.AppSettings("ChartImageHandlerphras1")) Then
                    urlstring1 = "mos@2017"
                Else
                    urlstring1 = Right(ConfigurationManager.AppSettings("ChartImageHandlerphras1").ToString(), Len(ConfigurationManager.AppSettings("ChartImageHandlerphras1").ToString()) - 5)
                End If
                csb.UserID = urlstring
                csb.Password = urlstring1
                settings = New ConnectionStringSettings(Nothing, "Data Source=" + csb.DataSource + ";Initial Catalog=" + csb.InitialCatalog + ";Persist Security Info=True;User ID=" + csb.UserID + ";Password=" + csb.Password + ";", settings.ProviderName)
            End If

            Return settings
        End Function
        Public Shared Function getconnection() As ConnectionStringSettings
            Dim connectionStringName As String = "eZee"
            Dim settings As New ConnectionStringSettings With {
                .Name = connectionStringName,
                .ProviderName = "System.Data.SqlClient",
                .ConnectionString = "Data Source=.;Initial Catalog=xxxx;Persist Security Info=True;User ID=xxx;Password=mos@2017;"
            }

            If IsNothing(ConfigurationManager.AppSettings("" & connectionStringName & "ProviderName")) Then
                settings.ProviderName = "System.Data.SqlClient"
            Else
                settings.ProviderName = ConfigurationManager.AppSettings("" & connectionStringName & "ProviderName").ToString()
            End If
            If IsNothing(ConfigurationManager.AppSettings("" & connectionStringName & "ConnectionString")) Then
                If IsNothing(ConfigurationManager.ConnectionStrings(connectionStringName)) Then
                    settings.ConnectionString = "Data Source=.;Initial Catalog=ALSADEQeZee;Persist Security Info=True;User ID=sa;Password=mos@2017;"
                Else
                    settings.ConnectionString = ConfigurationManager.ConnectionStrings(connectionStringName).ConnectionString
                End If
            Else
                settings.ConnectionString = ConfigurationManager.AppSettings("" & connectionStringName & "ConnectionString").ToString()
            End If




            'If (HttpContext.Current.User) IsNot Nothing Then
            'If HttpContext.Current.User.Identity.IsAuthenticated Then
            'End If
            'End If

            Dim csb As New SqlConnectionStringBuilder(settings.ConnectionString)
            Dim urlstring As String
            If IsNothing(ConfigurationManager.AppSettings("imagepath")) Then

                If IsNothing(ConfigurationManager.AppSettings("ChartImageHandlerphras")) Then
                    urlstring = "sa"
                Else
                    urlstring = Right(ConfigurationManager.AppSettings("ChartImageHandlerphras").ToString(), Len(ConfigurationManager.AppSettings("ChartImageHandlerphras").ToString()) - 5)
                End If

                Dim urlstring1 As String
                If IsNothing(ConfigurationManager.AppSettings("ChartImageHandlerphras1")) Then
                    urlstring1 = "mos@2017"
                Else
                    urlstring1 = Right(ConfigurationManager.AppSettings("ChartImageHandlerphras1").ToString(), Len(ConfigurationManager.AppSettings("ChartImageHandlerphras1").ToString()) - 5)
                End If
                csb.UserID = urlstring
                csb.Password = urlstring1
                settings = New ConnectionStringSettings(Nothing, "Data Source=" + csb.DataSource + ";Initial Catalog=" + csb.InitialCatalog + ";Persist Security Info=True;User ID=" + csb.UserID + ";Password=" + csb.Password + ";", settings.ProviderName)
            End If

            Return settings
        End Function

    End Class

    Partial Public Class Controller
        Protected Overrides Function CreateCommand(connection As DbConnection) As DbCommand
            Dim command As DbCommand = MyBase.CreateCommand(connection)
            If IsNothing(command) Then
            Else
                command.CommandTimeout = 60 * 60
            End If


            Return command
        End Function

        Public Overrides Function GetDataControllerStream(controller As String) As Stream
            Dim fileorgpath As String = myvirtualpathfun() + "controllers"
            Dim fileimppath As String = MyMapPath("/Controllersimp")
            Dim filecompath As String = MyMapPath("/Controllerscom")
            If IsNothing(ConfigurationManager.AppSettings("controllerpathorg")) Then
            Else
                fileorgpath = ConfigurationManager.AppSettings("controllerpathorg").ToString()
            End If
            If IsNothing(ConfigurationManager.AppSettings("controllerpathimp")) Then
            Else
                fileimppath = ConfigurationManager.AppSettings("controllerpathimp").ToString()
            End If

            If IsNothing(ConfigurationManager.AppSettings("controllerpathcom")) Then
            Else
                filecompath = ConfigurationManager.AppSettings("controllerpathcom").ToString()
            End If
            '-----------------------------------------------------------------------------------------------
            Dim fileName As String = ""
            Dim fileNametest As String = ""
            '-----------------------------------------------------------------------------------------------
            '-from org
            fileNametest = String.Format(fileorgpath + "\" + controller + ".xml")
            If (File.Exists(fileNametest)) Then
                fileName = fileNametest
            End If
            '-----------------------------------------------------------------------------------------------
            '-from imp
            fileNametest = String.Format(fileimppath + "\" + controller + ".xml")
            If (File.Exists(fileNametest)) Then
                fileName = fileNametest
            End If
            '-----------------------------------------------------------------------------------------------
            '-from com
            fileNametest = String.Format(filecompath + "\" + controller + ".xml")
            If (File.Exists(fileNametest)) Then
                fileName = fileNametest
            End If

            If (File.Exists(fileName)) Then
                Return New MemoryStream(File.ReadAllBytes(fileName))
            End If
            Return DefaultDataControllerStream
        End Function
        Public Function GetDataControllerfileName(controller As String) As String
            Dim fileName1url As String = MyMapPath("/Controllersimp") + +"\" + controller + ".xml"
            Dim fileorgpath As String = myvirtualpathfun() + "controllers"
            Dim fileimppath As String = MyMapPath("/Controllersimp")
            Dim filecompath As String = MyMapPath("/Controllerscom")
            If IsNothing(ConfigurationManager.AppSettings("controllerpathorg")) Then
            Else
                fileorgpath = ConfigurationManager.AppSettings("controllerpathorg").ToString()
            End If
            If IsNothing(ConfigurationManager.AppSettings("controllerpathimp")) Then
            Else
                fileimppath = ConfigurationManager.AppSettings("controllerpathimp").ToString()
            End If

            If IsNothing(ConfigurationManager.AppSettings("controllerpathcom")) Then
            Else
                filecompath = ConfigurationManager.AppSettings("controllerpathcom").ToString()
            End If
            '-----------------------------------------------------------------------------------------------
            Dim fileName As String = ""
            Dim fileNametest As String = ""
            '-----------------------------------------------------------------------------------------------
            '-from org
            fileNametest = String.Format(fileorgpath + "\" + controller + ".xml")
            If (File.Exists(fileNametest)) Then
                fileName = fileNametest
            End If
            '-----------------------------------------------------------------------------------------------
            '-from imp
            fileNametest = String.Format(fileimppath + "\" + controller + ".xml")
            If (File.Exists(fileNametest)) Then
                fileName = fileNametest
            End If
            '-----------------------------------------------------------------------------------------------
            '-from com
            fileNametest = String.Format(filecompath + "\" + controller + ".xml")
            If (File.Exists(fileNametest)) Then
                fileName = fileNametest
            End If

            If (File.Exists(fileName)) Then
                Return fileName
            End If
            Return fileName1url
        End Function

        Public Shared Function MyMapPath(path As String) As String
            If HttpContext.Current.Request.ApplicationPath = "/" Then
            Else
                path = HttpContext.Current.Request.ApplicationPath + path

            End If
            Return HttpContext.Current.Server.MapPath(path)

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
    End Class
    'Partial Public Class ControllerUtilities
    '    Inherits ControllerUtilitiesBase
    '    Public Shared ReadOnly Property UtcOffsetInMinutes() As Double
    '        Get
    '            Return TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).TotalMinutes
    '        End Get
    '    End Property
    '    Public Overrides ReadOnly Property SupportsScrollingInDataSheet As Boolean
    '        Get
    '            Return False
    '        End Get
    '    End Property
    'End Class

End Namespace


