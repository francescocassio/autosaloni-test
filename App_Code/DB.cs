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
        DBConfig config = new DBConfig(); // Crea un'istanza di DBConfig
        conn.ConnectionString = config.GetConnectionString(); // Recupera la stringa di connessione
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