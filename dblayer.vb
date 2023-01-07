Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.Text
Imports eZee.Data
Imports System.Web.Configuration

''' <summary>
''' Summary description for dbLayer
''' </summary>

Public Class dblayer

    Public cn As New SqlConnection(ConnectionStringSettingsFactory.getconnection().ConnectionString)
    Public cmd As New SqlCommand()

    Public adpt As New SqlDataAdapter()

    '
    ' TODO: Add constructor logic here
    '
    Public Sub New()
    End Sub

    Private Sub OpenCon()

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        cmd.Connection = cn
    End Sub

    Private Sub CloseCon()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Public Function Insert(ByVal ParaList As SqlParameter(), ByVal ProcName As String) As Boolean
        OpenCon()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = ProcName
        cmd.Parameters.Clear()
        cmd.Parameters.AddRange(ParaList)
        Dim x As Integer = cmd.ExecuteNonQuery()
        CloseCon()
        Return If(x > 0, True, False)
    End Function

    Public Function Update(ByVal ParaList As SqlParameter(), ByVal ProcName As String) As Boolean
        Return Insert(ParaList, ProcName)
    End Function

    Public Function Delete(ByVal ParaList As SqlParameter(), ByVal ProcName As String) As Boolean
        Return Insert(ParaList, ProcName)
    End Function

    Public Function [Select](ByVal ParaList As SqlParameter(), ByVal ProcName As String) As DataTable
        Try
            Dim dt As New DataTable()
            OpenCon()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = ProcName
            cmd.Parameters.Clear()
            cmd.Parameters.AddRange(ParaList)
            adpt.SelectCommand = cmd
            adpt.Fill(dt)
            CloseCon()
            Return dt
        Catch generatedExceptionName As Exception
            Dim nu As New DataTable()
            Return nu
        End Try

    End Function

    Public Function [Select](ByVal ProcName As String) As DataTable
        Try
            Dim dt As New DataTable()
            OpenCon()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = ProcName
            cmd.Parameters.Clear()
            adpt.SelectCommand = cmd
            adpt.Fill(dt)
            CloseCon()
            Return dt
        Catch generatedExceptionName As Exception

            Dim nu As New DataTable()
            Return nu
        End Try

    End Function

    Public Function Insert(ByVal CmdText As String) As Boolean
        OpenCon()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = CmdText
        Dim x As Integer = cmd.ExecuteNonQuery()
        CloseCon()
        Return If(x > 0, True, False)
    End Function
    Public Function Update(ByVal CmdText As String) As Boolean
        Return Insert(CmdText)
    End Function

    Public Function Delete(ByVal CmdText As String) As Boolean
        Return Insert(CmdText)
    End Function

    Public Function SelectCmdText(ByVal CmdText As String) As DataTable
        Dim dt As New DataTable()
        OpenCon()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = CmdText
        adpt.SelectCommand = cmd
        adpt.Fill(dt)
        CloseCon()
        Return dt
    End Function
    'public bool CmdSqlBulkCopy(DataTable DT, string TableName)
    '{
    '    try
    '    {
    '        OpenCon();
    '        SqlBulkCopy b = new SqlBulkCopy(cn);
    '        b.DestinationTableName = TableName;
    '        b.WriteToServer(DT);
    '        CloseCon();
    '        return true;
    '    }
    '    catch
    '    {
    '        CloseCon();
    '        return false;
    '    }
    '}



    Public Function RandomStrings(ByVal size As Integer, ByVal lowercase As Boolean) As String
        Dim builder As New StringBuilder()
        Dim random As New Random()
        Dim tempchar As Char
        For i As Integer = 0 To size - 1
            tempchar = Convert.ToChar(Convert.ToInt32(26 * random.NextDouble() + 65))
            builder.Append(tempchar)
        Next
        If lowercase Then
            Return builder.ToString().ToLower()
        Else
            Return builder.ToString()
        End If

    End Function

    ''' <summary>
    ''' Generate string.
    ''' </summary>
    ''' <returns></returns>
    Public Function GeneratedString() As String
        Dim builder As New StringBuilder()
        Dim random As New Random()
        builder.Append(RandomStrings(4, False))
        Dim num As Integer = random.[Next](10, 1000)
        builder.Append(num.ToString())
        builder.Append(RandomStrings(3, True))

        Return builder.ToString()


    End Function

End Class

