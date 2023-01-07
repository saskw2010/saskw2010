using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

/// <summary>
/// Summary description for Class1
/// </summary>
public sealed class DataLogic
{
    private DataLogic()
    {
    }

    public static string GetConnectionString()
    {
        return global::eZee.Data.ConnectionStringSettingsFactory.getconnection().ConnectionString;
    }

    public static DataTable GetData(string ssql)
    {
        using (var cnn = new SqlConnection(GetConnectionString()))
        {
            cnn.Open();
            using (var da = new SqlDataAdapter(ssql, cnn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        // Catch ex As Exception
        // If TypeOf ex Is System.Reflection.TargetInvocationException Then
        // ex = ex.InnerException
        // End If

        // End Try



    }

    public static string GetConnectionStringworkstation()
    {
        try
        {
            using (var cnn = new SqlConnection(GetConnectionString()))
            {
                cnn.Open();
                return cnn.WorkstationId;
            }
        }
        catch (Exception ex)
        {
            if (ex is System.Reflection.TargetInvocationException)
            {
                ex = ex.InnerException;
            }
        }

        return default;
    }

    public static object GetValue(string ssql)
    {
        try
        {
            using (var cnn = new SqlConnection(GetConnectionString()))
            {
                cnn.Open();
                using (var dc = new SqlCommand(ssql, cnn))
                {
                    return dc.ExecuteScalar();
                }
            }
        }
        catch (Exception ex)
        {
            if (ex is System.Reflection.TargetInvocationException)
            {
                ex = ex.InnerException;
            }
        }

        return default;
    }

    public static string setVowelsCount(string valueforencrypt)
    {
        string decryptedvaluemosso = "--";
        using (var cnn = new SqlConnection(GetConnectionString()))
        {
            cnn.Open();
            var cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "insertschinformation";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@test", SqlDbType.NVarChar, 50);
            cmd.Parameters["@test"].Value = "17SomeHiddenPassword!76";
            cmd.Parameters.Add("@valueforencrypt", SqlDbType.NVarChar, 4000);
            cmd.Parameters["@valueforencrypt"].Value = valueforencrypt;
            cmd.Parameters.Add("@encryptvale", SqlDbType.NVarChar, 4000);
            cmd.Parameters["@encryptvale"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            decryptedvaluemosso = Conversions.ToString(cmd.Parameters["@encryptvale"].Value);
            return decryptedvaluemosso.ToString();
        }
    }

    public static int logintrack(string usernamestr, DateTime logintimedate, string workstationiddesc)
    {
        try
        {
            using (var cnn = new SqlConnection(GetConnectionString()))
            {
                cnn.Open();
                var cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "insertlogintrack";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@usernamestr", SqlDbType.NVarChar, 50);
                cmd.Parameters["@usernamestr"].Value = usernamestr;
                cmd.Parameters.Add("@logintimedate", SqlDbType.DateTime);
                cmd.Parameters["@logintimedate"].Value = logintimedate;
                cmd.Parameters.Add("@workstationiddesc", SqlDbType.NVarChar, 4000);
                cmd.Parameters["@workstationiddesc"].Value = workstationiddesc;
                cmd.ExecuteNonQuery();
                return 1;
            }
        }
        catch (Exception ex)
        {
            if (ex is System.Reflection.TargetInvocationException)
            {
                ex = ex.InnerException;
            }
        }

        return default;
    }

    public static int excuteupdateencode(string tablenamestr, string fieldnamestring, string keyfieldstring, string keyfieldstringvale)
    {
        using (var calc = new global::eZee.Data.SqlText(" OPEN SYMMETRIC KEY SymKey DECRYPTION BY ASYMMETRIC KEY AsymKeyPwd WITH PASSWORD = '17SomeHiddenPassword!76';" + " UPDATE dbo." + tablenamestr + " SET " + fieldnamestring + "=ENCRYPTBYKEY(KEY_GUID('SymKey'),CONVERT(nvarchar(MAX)," + fieldnamestring + ")) where " + keyfieldstring + "=" + keyfieldstringvale + ";" + " CLOSE SYMMETRIC KEY SymKey;"))

        {
            calc.ExecuteNonQuery();
            return 1;
        }
        // If SelectFieldValueObject("code_nm").NewValue = SelectFieldValueObject("code_nm").OldValue Then
        // Else
        // Dim encodkey As Integer = DataLogic.excuteupdateencode("ACCODE", "code_nm", "code_no", code_no)
        // End If

    }
}