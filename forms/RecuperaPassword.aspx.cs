using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class forms_RecuperaPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnRecupera_Click(object sender, EventArgs e)
    {
        //Controlli formali

        if (txtUSR.Text.Trim() == "") // Trim impedisce di mettere spazi all'inizio e al fondo
        {
            lblMessaggio.Text = "Dati non validi!";

            return;
        }

        string wUSR = txtUSR.Text.Trim(); //dichiaro le variabili

        //Riempio la DataTable
       
        DB database = new DB();
        database.query = "RecuperaPassword";
        database.cmd.Parameters.AddWithValue("@USR", wUSR);


        DataTable DT = new DataTable();
        //DA.Fill(DT);
        DT = database.SQLselect();

        // se DT.Rows.Count == 0, l'utente non esiste
        //oppure se DT.Rows.Count != l'utente non è univoco è non esiste
        if (DT.Rows.Count == 0)
        {
            lblMessaggio.Text = "Dati non validi";
            return; //è più efficente a volte di un else
        }

        //Altrimenti, leggo la PWD e la scrivo nella Lbl --> DT.Rows[0]["PWD"].ToString()
        lblMessaggio.Text = "La tua password è " + DT.Rows[0]["PWD"].ToString();

        //E' necessario ritornare alla schermata precedente
    }
}