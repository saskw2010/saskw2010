Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports eZee.Data
Imports System.Web.Configuration

''' <summary>
''' Summary description for Class1
''' </summary>
Public NotInheritable Class DataLogic
    Private Sub New()
    End Sub


    Public Shared Function GetConnectionString() As String
        Return ConnectionStringSettingsFactory.getconnection().ConnectionString
    End Function

    Public Shared Function GetData(ByVal ssql As String) As DataTable

        Using cnn As New SqlConnection(GetConnectionString())
            cnn.Open()

            Using da As New SqlDataAdapter(ssql, cnn)
                Dim dt As New DataTable()
                da.Fill(dt)
                Return dt
            End Using
        End Using
        'Catch ex As Exception
        '    If TypeOf ex Is System.Reflection.TargetInvocationException Then
        '        ex = ex.InnerException
        '    End If

        'End Try



    End Function
    Public Shared Function GetConnectionStringworkstation() As String
        Try
            Using cnn As New SqlConnection(GetConnectionString())
                cnn.Open()
                Return DirectCast(cnn, System.Data.SqlClient.SqlConnection).WorkstationId()

            End Using
        Catch ex As Exception
            If TypeOf ex Is System.Reflection.TargetInvocationException Then
                ex = ex.InnerException
            End If

        End Try
    End Function
    Public Shared Function GetValue(ByVal ssql As String) As Object
        Try
            Using cnn As New SqlConnection(GetConnectionString())
                cnn.Open()

                Using dc As New SqlCommand(ssql, cnn)
                    Return dc.ExecuteScalar()
                End Using
            End Using
        Catch ex As Exception
            If TypeOf ex Is System.Reflection.TargetInvocationException Then
                ex = ex.InnerException
            End If

        End Try
    End Function
    Public Shared Function setVowelsCount(ByVal valueforencrypt As String) As String
        Dim decryptedvaluemosso As String = "--"
        Using cnn As New SqlConnection(GetConnectionString())
            cnn.Open()
            Dim cmd As New SqlCommand()
            cmd.Connection = cnn
            cmd.CommandText = "insertschinformation"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@test", SqlDbType.NVarChar, 50)
            cmd.Parameters("@test").Value = "17SomeHiddenPassword!76"
            cmd.Parameters.Add("@valueforencrypt", SqlDbType.NVarChar, 4000)
            cmd.Parameters("@valueforencrypt").Value = valueforencrypt
            cmd.Parameters.Add("@encryptvale", SqlDbType.NVarChar, 4000)
            cmd.Parameters("@encryptvale").Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()
            decryptedvaluemosso = cmd.Parameters("@encryptvale").Value
            Return decryptedvaluemosso.ToString()

        End Using
    End Function
    Public Shared Function logintrack(ByVal usernamestr As String, ByVal logintimedate As DateTime, ByVal workstationiddesc As String) As Integer
        Try
            Using cnn As New SqlConnection(GetConnectionString())
                cnn.Open()
                Dim cmd As New SqlCommand()
                cmd.Connection = cnn
                cmd.CommandText = "insertlogintrack"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@usernamestr", SqlDbType.NVarChar, 50)
                cmd.Parameters("@usernamestr").Value = usernamestr
                cmd.Parameters.Add("@logintimedate", SqlDbType.DateTime)
                cmd.Parameters("@logintimedate").Value = logintimedate
                cmd.Parameters.Add("@workstationiddesc", SqlDbType.NVarChar, 4000)
                cmd.Parameters("@workstationiddesc").Value = workstationiddesc
                cmd.ExecuteNonQuery()

                Return 1

            End Using
        Catch ex As Exception
            If TypeOf ex Is System.Reflection.TargetInvocationException Then
                ex = ex.InnerException
            End If

        End Try
    End Function
    Public Shared Function excuteupdateencode(ByVal tablenamestr As String, ByVal fieldnamestring As String, ByVal keyfieldstring As String, ByVal keyfieldstringvale As String) As Integer
        Using calc As SqlText = New SqlText(
                   " OPEN SYMMETRIC KEY SymKey DECRYPTION BY ASYMMETRIC KEY AsymKeyPwd WITH PASSWORD = '17SomeHiddenPassword!76';" & _
                    " UPDATE dbo." + tablenamestr + " SET " + fieldnamestring + "=ENCRYPTBYKEY(KEY_GUID('SymKey'),CONVERT(nvarchar(MAX)," + fieldnamestring + ")) where " + keyfieldstring + "=" + keyfieldstringvale + ";" & _
                    " CLOSE SYMMETRIC KEY SymKey;")

            calc.ExecuteNonQuery()
            Return 1
        End Using
        'If SelectFieldValueObject("code_nm").NewValue = SelectFieldValueObject("code_nm").OldValue Then
        ' Else
        'Dim encodkey As Integer = DataLogic.excuteupdateencode("ACCODE", "code_nm", "code_no", code_no)
        'End If

    End Function
End Class