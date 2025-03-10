using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SqlServer.Server;

public partial class forms_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnAccedi_Click(object sender, EventArgs e)
    {
        // controlli formali
        if (txtUSR.Text.Trim() == "" || txtPWD.Text == "") // Trim impedisce di mettere spazi all'inizio e al fondo
        {
            lblMessaggio.Text = "Dati non validi!";

            return;
        }

        string wUSR = txtUSR.Text.Trim(); //dichiaro le variabili
        string wPWD = txtPWD.Text.Trim();

        //// connessione al DB
        DB db = new DB();
        db.query = "LoginAutosaloni";
        db.cmd.Parameters.AddWithValue("@USR", wUSR);
        db.cmd.Parameters.AddWithValue("@PWD", wPWD);

        DataTable DT = new DataTable();
        //DA.Fill(DT);
        DT = db.SQLselect();

        // controllo login

        int trovati = (int)DT.Rows[0]["QUANTI"];

        if (trovati == 0)
        {
            lblMessaggio.Text = "Dati non validi"; // se i dati inseriti non sono validi

            return;
        }

        // se l'utente è loggato vado a Default.aspx

        Session["USR"] = wUSR;
        //la session è una parte del server che accompagnia l'utente dal suo ingresso fino alla sua uscita.
        //Ci psso scrivere stringhe

        Response.Redirect("Index.aspx");
    }
}