using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class forms_ModificaProfilo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Session["USR"] as string))
        {
            Response.Redirect("Login.aspx");
        }
        // carico i dati dell'utente dal DB

        // guarda che se per caso l'ho già caricata non lo rifare

        if (!IsPostBack)
        {





            // query di selezione

            //cmd.CommandText = "Select * from UTENTI where USR ='" + Session["USR"] + "'";

            DB db = new DB();
            db.query = "SelezionaUtente";
            db.cmd.Parameters.AddWithValue("@USR", Session["USR"]);


            DataTable DT = new DataTable();
            DT = db.SQLselect();

            txtUSR.Text = DT.Rows[0]["USR"].ToString();
            txtCognome.Text = DT.Rows[0]["COGNOME"].ToString();
            txtNome.Text = DT.Rows[0]["NOME"].ToString();
            txtCitta.Text = DT.Rows[0]["CITTA"].ToString();
        }
    }

    protected void btnSalva_Click(object sender, EventArgs e)
    {
        // cotrolli formali
        string USR = txtUSR.Text;
        string PWD = txtPWD.Text;
        string PWD2 = txtPWD2.Text;
        string COGNOME = txtCognome.Text.Trim();
        string NOME = txtNome.Text.Trim();
        string CITTA = txtCitta.Text.Trim();


        // controllo che tutti i campi sono pieni

        if (
            String.IsNullOrEmpty(COGNOME) ||
            String.IsNullOrEmpty(NOME) ||
            String.IsNullOrEmpty(CITTA))
        {
            lblMessaggio.Text = "Dati non validi";
            return;
        }

        // se c'è qualcosa nelle due password, se si controllare se coincidono



        if (PWD != PWD2)
        {
            lblMessaggio.Text = "Password non coincidenti";
            return;
        }


        // la connessione
        DB x = new DB();

        // query di selezione
        if (!String.IsNullOrEmpty(PWD) && !String.IsNullOrEmpty(PWD2))
        {
            x.query = "ModificaUtente_Password";
            x.cmd.Parameters.AddWithValue("@PWD", PWD);
            x.cmd.Parameters.AddWithValue("@COGNOME", COGNOME);
            x.cmd.Parameters.AddWithValue("@NOME", NOME);
            x.cmd.Parameters.AddWithValue("@CITTA", CITTA);
            x.cmd.Parameters.AddWithValue("@USR", USR);
            x.SQLCommand();
        }
        else
        {

            x.query = "ModificaUtente_NoPassword";
            x.cmd.Parameters.AddWithValue("@COGNOME", COGNOME);
            x.cmd.Parameters.AddWithValue("@NOME", NOME);
            x.cmd.Parameters.AddWithValue("@CITTA", CITTA);
            x.cmd.Parameters.AddWithValue("@USR", USR);
            x.SQLCommand();
        }

   

        // modifico i dati
        // confermo la modifica

        lblMessaggio.Text = "Dati modificati";
    }
}