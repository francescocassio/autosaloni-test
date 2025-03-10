using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;


public class DB
{

    SqlConnection conn = new SqlConnection();
    SqlDataAdapter DA = new SqlDataAdapter();
    public SqlCommand cmd = new SqlCommand();
    public string query;
    public DB()
    {
        conn.ConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING", EnvironmentVariableTarget.Machine);
        string connStr = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING", EnvironmentVariableTarget.Machine);
        System.Diagnostics.Debug.WriteLine("Il valore della variabile è: " + connStr);



        if (string.IsNullOrEmpty(conn.ConnectionString))
        {
            throw new Exception("La variabile d'ambiente DB_CONNECTION_STRING non è impostata. Configurala prima di eseguire l'applicazione.");
        }
        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;
    }
    public DataTable SQLselect()
    {
        DataTable DT = new DataTable();
        cmd.CommandText = query;
        DA.SelectCommand = cmd;
        DA.Fill(DT);
        return DT;
    }
    public void SQLCommand()
    {
        cmd.CommandText = query;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
}