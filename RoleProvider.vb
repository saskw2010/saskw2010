Imports eZee.Data
Imports System
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Configuration.Provider
Imports System.Data.Common
Imports System.Diagnostics
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Web.Security
Imports System.Xml.XPath

Namespace eZee.Security
    
    Partial Public Class ApplicationRoleProvider
        Inherits ApplicationRoleProviderBase
    End Class
    
    Public Enum RoleProviderSqlStatement
        
        AddUserToRole
        
        CreateRole
        
        DeleteRole
        
        DeleteRoleUsers
        
        GetAllRoles
        
        GetRolesForUser
        
        GetUsersInRole
        
        IsUserInRole
        
        RemoveUserFromRole
        
        RoleExists
        
        FindUsersInRole
    End Enum
    
    Public Class ApplicationRoleProviderBase
        Inherits RoleProvider
        
        Protected Shared Statements As SortedDictionary(Of RoleProviderSqlStatement, String) = New SortedDictionary(Of RoleProviderSqlStatement, String)()
        
        Private m_ConnectionStringSettings As ConnectionStringSettings
        
        Private m_WriteExceptionsToEventLog As Boolean
        
        <System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)>  _
        Private m_ApplicationName As String
        
        Shared Sub New()
            Statements(RoleProviderSqlStatement.AddUserToRole) = "" & ControlChars.CrLf &"insert into AspNetUserRoles(UserID, RoleID) " & ControlChars.CrLf &"values (" & ControlChars.CrLf &"     (select Id from As"& _ 
                "pNetUsers where UserName=@UserName) " & ControlChars.CrLf &"    ,(select ID from AspNetRoles where Nam"& _ 
                "e=@RoleName)" & ControlChars.CrLf &"    " & ControlChars.CrLf &")"
            Statements(RoleProviderSqlStatement.CreateRole) = "insert into AspNetRoles (Name) values (@RoleName)"
            Statements(RoleProviderSqlStatement.DeleteRole) = "delete from AspNetRoles where Name = @RoleName"
            Statements(RoleProviderSqlStatement.DeleteRoleUsers) = "delete from AspNetUserRoles where RoleID in (select ID from AspNetRoles where Nam"& _ 
                "e = @RoleName)"
            Statements(RoleProviderSqlStatement.GetAllRoles) = "select Name RoleName from AspNetRoles"
            Statements(RoleProviderSqlStatement.GetRolesForUser) = "" & ControlChars.CrLf &"select Roles.Name RoleName from AspNetRoles Roles " & ControlChars.CrLf &"inner join AspNetUserRoles "& _ 
                "UserRoles on Roles.ID = UserRoles.RoleID " & ControlChars.CrLf &"inner join AspNetUsers Users on Users"& _ 
                ".Id = UserRoles.UserID" & ControlChars.CrLf &"where Users.UserName = @UserName"
            Statements(RoleProviderSqlStatement.GetUsersInRole) = "select UserName UserName from AspNetUsers where Id in (select UserID from AspNetU"& _ 
                "serRoles where RoleID in (select ID from AspNetRoles where Name = @RoleName))"
            Statements(RoleProviderSqlStatement.IsUserInRole) = "" & ControlChars.CrLf &"select count(*) from AspNetUserRoles" & ControlChars.CrLf &"where" & ControlChars.CrLf &"    UserID in (select Id from AspN"& _ 
                "etUsers where UserName = @UserName) and " & ControlChars.CrLf &"    RoleID in (select ID from AspNetRo"& _ 
                "les where Name = @RoleName)"
            Statements(RoleProviderSqlStatement.RemoveUserFromRole) = "" & ControlChars.CrLf &"delete from AspNetUserRoles" & ControlChars.CrLf &"where" & ControlChars.CrLf &"   UserID in (select Id from AspNetUsers wh"& _ 
                "ere UserName = @UserName) and" & ControlChars.CrLf &"   RoleID in (select ID from AspNetRoles where Na"& _ 
                "me = @RoleName)"
            Statements(RoleProviderSqlStatement.RoleExists) = "select count(*) from AspNetRoles where Name = @RoleName"
            Statements(RoleProviderSqlStatement.FindUsersInRole) = "" & ControlChars.CrLf &"select Users.UserName UserName from AspNetUsers Users" & ControlChars.CrLf &"inner join AspNetUserRol"& _ 
                "es UserRoles on Users.Id= UserRoles.UserID " & ControlChars.CrLf &"inner join AspNetRoles Roles on Use"& _ 
                "rRoles.RoleID = Roles.ID" & ControlChars.CrLf &"where " & ControlChars.CrLf &Global.Microsoft.VisualBasic.ChrW(9)&"Users.UserName like @UserName and " & ControlChars.CrLf &Global.Microsoft.VisualBasic.ChrW(9)&"Roles.Na"& _ 
                "me = @RoleName"
        End Sub
        
        Public Overridable ReadOnly Property ConnectionStringSettings() As ConnectionStringSettings
            Get
                Return m_ConnectionStringSettings
            End Get
        End Property
        
        Public ReadOnly Property WriteExceptionsToEventLog() As Boolean
            Get
                Return m_WriteExceptionsToEventLog
            End Get
        End Property
        
        Public Overrides Property ApplicationName() As String
            Get
                Return m_ApplicationName
            End Get
            Set
                m_ApplicationName = value
            End Set
        End Property
        
        Protected Overridable Function CreateSqlStatement(ByVal command As RoleProviderSqlStatement) As SqlStatement
            Dim sql = New SqlText(Statements(command), ConnectionStringSettings.Name)
            sql.Command.CommandText = sql.Command.CommandText.Replace("@", sql.ParameterMarker)
            If sql.Command.CommandText.Contains((sql.ParameterMarker + "ApplicationName")) Then
                sql.AssignParameter("ApplicationName", ApplicationName)
            End If
            sql.Name = ("eZee Application Role Provider - " + command.ToString())
            sql.WriteExceptionsToEventLog = WriteExceptionsToEventLog
            Return sql
        End Function
        
        Public Overrides Sub Initialize(ByVal name As String, ByVal config As NameValueCollection)
            If (config Is Nothing) Then
                Throw New ArgumentNullException("config")
            End If
            If String.IsNullOrEmpty(name) Then
                name = "eZeeApplicationRoleProvider"
            End If
            If String.IsNullOrEmpty(config("description")) Then
                config.Remove("description")
                config.Add("description", "eZee application role provider")
            End If
            MyBase.Initialize(name, config)
            m_ApplicationName = config("applicationName")
            If String.IsNullOrEmpty(m_ApplicationName) Then
                m_ApplicationName = System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath
            End If
            m_WriteExceptionsToEventLog = "true".Equals(config("writeExceptionsToEventLog"), StringComparison.CurrentCulture)
            m_ConnectionStringSettings = ConnectionStringSettingsFactory.CreateSettings1(config("connectionStringName"))
            'ConfigurationManager.ConnectionStrings(config("connectionStringName"))
            If ((m_ConnectionStringSettings Is Nothing) OrElse String.IsNullOrEmpty(m_ConnectionStringSettings.ConnectionString)) Then
                Throw New ProviderException("Connection string cannot be blank.")
            End If
        End Sub
        
        Public Overrides Sub AddUsersToRoles(ByVal usernames() As String, ByVal rolenames() As String)
            For Each rolename in rolenames
                If Not (RoleExists(rolename)) Then
                    Throw New ProviderException(String.Format("Role name '{0}' not found.", rolename))
                End If
            Next
            For Each username in usernames
                If username.Contains(",") Then
                    Throw New ArgumentException("User names cannot contain commas.")
                End If
                For Each rolename in rolenames
                    If IsUserInRole(username, rolename) Then
                        Throw New ProviderException(String.Format("User '{0}' is already in role '{1}'.", username, rolename))
                    End If
                Next
            Next
            Using sql = CreateSqlStatement(RoleProviderSqlStatement.AddUserToRole)
                For Each username in usernames
                    ForgetUserRoles(username)
                    For Each rolename in rolenames
                        sql.AssignParameter("UserName", username)
                        sql.AssignParameter("RoleName", rolename)
                        sql.ExecuteNonQuery()
                    Next
                Next
            End Using
        End Sub
        
        Public Overrides Sub CreateRole(ByVal rolename As String)
            If rolename.Contains(",") Then
                Throw New ArgumentException("Role names cannot contain commas.")
            End If
            If RoleExists(rolename) Then
                Throw New ProviderException("Role already exists.")
            End If
            Using sql = CreateSqlStatement(RoleProviderSqlStatement.CreateRole)
                sql.AssignParameter("RoleName", rolename)
                sql.ExecuteNonQuery()
            End Using
        End Sub
        
        Public Overrides Function DeleteRole(ByVal rolename As String, ByVal throwOnPopulatedRole As Boolean) As Boolean
            If Not (RoleExists(rolename)) Then
                Throw New ProviderException("Role does not exist.")
            End If
            If (throwOnPopulatedRole AndAlso (GetUsersInRole(rolename).Length > 0)) Then
                Throw New ProviderException("Cannot delete a pouplated role.")
            End If
            Using sql = CreateSqlStatement(RoleProviderSqlStatement.DeleteRole)
                Using sql2 = CreateSqlStatement(RoleProviderSqlStatement.DeleteRoleUsers)
                    sql2.AssignParameter("RoleName", rolename)
                    sql2.ExecuteNonQuery()
                End Using
                sql.AssignParameter("RoleName", rolename)
                sql.ExecuteNonQuery()
            End Using
            Return true
        End Function
        
        Public Overrides Function GetAllRoles() As String()
            Dim roles = New List(Of String)()
            Using sql = CreateSqlStatement(RoleProviderSqlStatement.GetAllRoles)
                Do While sql.Read()
                    roles.Add(Convert.ToString(sql("RoleName")))
                Loop
            End Using
            Return roles.ToArray()
        End Function
        
        Public Overrides Function GetRolesForUser(ByVal username As String) As String()
            Dim roles As List(Of String) = Nothing
            Dim userRolesKey = String.Format("ApplicationRoleProvider_{0}_Roles", username)
            Dim contextIsAvailable = (Not (HttpContext.Current) Is Nothing)
            If contextIsAvailable Then
                roles = CType(HttpContext.Current.Items(userRolesKey),List(Of String))
            End If
            If (roles Is Nothing) Then
                roles = New List(Of String)()
                Using sql = CreateSqlStatement(RoleProviderSqlStatement.GetRolesForUser)
                    sql.AssignParameter("UserName", username)
                    Do While sql.Read()
                        roles.Add(Convert.ToString(sql("RoleName")))
                    Loop
                    If contextIsAvailable Then
                        HttpContext.Current.Items(userRolesKey) = roles
                    End If
                End Using
            End If
            Return roles.ToArray()
        End Function
        
        Public Overridable Sub ForgetUserRoles(ByVal username As String)
            If (Not (HttpContext.Current) Is Nothing) Then
                HttpContext.Current.Items.Remove(String.Format("ApplicationRoleProvider_{0}_Roles", username))
            End If
        End Sub
        
        Public Overrides Function GetUsersInRole(ByVal rolename As String) As String()
            Dim users = New List(Of String)()
            Using sql = CreateSqlStatement(RoleProviderSqlStatement.GetUsersInRole)
                sql.AssignParameter("RoleName", rolename)
                Do While sql.Read()
                    users.Add(Convert.ToString(sql("UserName")))
                Loop
            End Using
            Return users.ToArray()
        End Function
        
        Public Overrides Function IsUserInRole(ByVal username As String, ByVal rolename As String) As Boolean
            Using sql = CreateSqlStatement(RoleProviderSqlStatement.IsUserInRole)
                sql.AssignParameter("UserName", username)
                sql.AssignParameter("RoleName", rolename)
                Return (Convert.ToInt32(sql.ExecuteScalar()) > 0)
            End Using
        End Function
        
        Public Overrides Sub RemoveUsersFromRoles(ByVal usernames() As String, ByVal rolenames() As String)
            For Each rolename in rolenames
                If Not (RoleExists(rolename)) Then
                    Throw New ProviderException(String.Format("Role '{0}' not found.", rolename))
                End If
            Next
            For Each username in usernames
                For Each rolename in rolenames
                    If Not (IsUserInRole(username, rolename)) Then
                        Throw New ProviderException(String.Format("User '{0}' is not in role '{1}'.", username, rolename))
                    End If
                Next
            Next
            For Each username in usernames
                ForgetUserRoles(username)
                For Each rolename in rolenames
                    Using sql = CreateSqlStatement(RoleProviderSqlStatement.RemoveUserFromRole)
                        sql.AssignParameter("UserName", username)
                        sql.AssignParameter("RoleName", rolename)
                        sql.ExecuteNonQuery()
                    End Using
                Next
            Next
        End Sub
        
        Public Overrides Function RoleExists(ByVal rolename As String) As Boolean
            Using sql = CreateSqlStatement(RoleProviderSqlStatement.RoleExists)
                sql.AssignParameter("RoleName", rolename)
                Return (Convert.ToInt32(sql.ExecuteScalar()) > 0)
            End Using
        End Function
        
        Public Overrides Function FindUsersInRole(ByVal rolename As String, ByVal usernameToMatch As String) As String()
            Dim users = New List(Of String)()
            Using sql = CreateSqlStatement(RoleProviderSqlStatement.FindUsersInRole)
                sql.AssignParameter("UserName", usernameToMatch)
                sql.AssignParameter("RoleName", rolename)
                Do While sql.Read()
                    users.Add(Convert.ToString(sql("UserName")))
                Loop
            End Using
            Return users.ToArray()
        End Function
    End Class
End Namespace
