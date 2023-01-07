using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

/// <summary>
/// Summary description for dbLayer
/// </summary>

public class dblayer
{
    public SqlConnection cn = new SqlConnection(global::eZee.Data.ConnectionStringSettingsFactory.getconnection().ConnectionString);
    public SqlCommand cmd = new SqlCommand();
    public SqlDataAdapter adpt = new SqlDataAdapter();

    // 
    // TODO: Add constructor logic here
    // 
    public dblayer()
    {
    }

    private void OpenCon()
    {
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }

        cmd.Connection = cn;
    }

    private void CloseCon()
    {
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
    }

    public bool Insert(SqlParameter[] ParaList, string ProcName)
    {
        OpenCon();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = ProcName;
        cmd.Parameters.Clear();
        cmd.Parameters.AddRange(ParaList);
        int x = cmd.ExecuteNonQuery();
        CloseCon();
        return x > 0 ? true : false;
    }

    public bool Update(SqlParameter[] ParaList, string ProcName)
    {
        return Insert(ParaList, ProcName);
    }

    public bool Delete(SqlParameter[] ParaList, string ProcName)
    {
        return Insert(ParaList, ProcName);
    }

    public DataTable Select(SqlParameter[] ParaList, string ProcName)
    {
        try
        {
            var dt = new DataTable();
            OpenCon();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = ProcName;
            cmd.Parameters.Clear();
            cmd.Parameters.AddRange(ParaList);
            adpt.SelectCommand = cmd;
            adpt.Fill(dt);
            CloseCon();
            return dt;
        }
        catch (Exception generatedExceptionName)
        {
            var nu = new DataTable();
            return nu;
        }
    }

    public DataTable Select(string ProcName)
    {
        try
        {
            var dt = new DataTable();
            OpenCon();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = ProcName;
            cmd.Parameters.Clear();
            adpt.SelectCommand = cmd;
            adpt.Fill(dt);
            CloseCon();
            return dt;
        }
        catch (Exception generatedExceptionName)
        {
            var nu = new DataTable();
            return nu;
        }
    }

    public bool Insert(string CmdText)
    {
        OpenCon();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = CmdText;
        int x = cmd.ExecuteNonQuery();
        CloseCon();
        return x > 0 ? true : false;
    }

    public bool Update(string CmdText)
    {
        return Insert(CmdText);
    }

    public bool Delete(string CmdText)
    {
        return Insert(CmdText);
    }

    public DataTable SelectCmdText(string CmdText)
    {
        var dt = new DataTable();
        OpenCon();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = CmdText;
        adpt.SelectCommand = cmd;
        adpt.Fill(dt);
        CloseCon();
        return dt;
    }
    // public bool CmdSqlBulkCopy(DataTable DT, string TableName)
    // {
    // try
    // {
    // OpenCon();
    // SqlBulkCopy b = new SqlBulkCopy(cn);
    // b.DestinationTableName = TableName;
    // b.WriteToServer(DT);
    // CloseCon();
    // return true;
    // }
    // catch
    // {
    // CloseCon();
    // return false;
    // }
    // }



    public string RandomStrings(int size, bool lowercase)
    {
        var builder = new StringBuilder();
        var random = new Random();
        char tempchar;
        for (int i = 0, loopTo = size - 1; i <= loopTo; i++)
        {
            tempchar = Convert.ToChar(Convert.ToInt32(26 * random.NextDouble() + 65));
            builder.Append(tempchar);
        }

        if (lowercase)
        {
            return builder.ToString().ToLower();
        }
        else
        {
            return builder.ToString();
        }
    }

    /// <summary>
    /// Generate string.
    /// </summary>
    /// <returns></returns>
    public string GeneratedString()
    {
        var builder = new StringBuilder();
        var random = new Random();
        builder.Append(RandomStrings(4, false));
        int num = random.Next(10, 1000);
        builder.Append(num.ToString());
        builder.Append(RandomStrings(3, true));
        return builder.ToString();
    }
}