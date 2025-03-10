using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class forms_Registrati : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSalva_Click(object sender, EventArgs e)
    {
        //dichiarazione tante variabili quanti sono i texbox che leggiamo

        string wUSR = txtUSR.Text.Trim();
        string wPWD = txtPWD.Text;
        string wPWD2 = txtPWD2.Text;
        string wCOGNOME = txtCognome.Text.Trim();
        string wNOME = txtNome.Text.Trim();
        string wCITTA = txtCittà.Text.Trim();

        //controllo che tutti i campi siano pieni

        if (String.IsNullOrEmpty(wUSR) ||
            String.IsNullOrEmpty(wPWD) ||
            String.IsNullOrEmpty(wPWD2) ||
            String.IsNullOrEmpty(wCOGNOME) ||
            String.IsNullOrEmpty(wNOME) ||
            String.IsNullOrEmpty(wCITTA))
        {
            lblMessaggio.Text = "Dati non validi";
            return;
        }

        //controllo che le password coincidano

        if (wPWD != wPWD2)
        {
            lblMessaggio.Text = "Password non coincidenti";
            return;
        }

        //apro connessione
        DB db = new DB();
        db.query = "ControlloUtenti";
        db.cmd.Parameters.AddWithValue("@USR", wUSR);


        //cmd.CommandText = "Select count(*) as [QUANTI] from UTENTI where USR='" + wUSR + "'";

        DataTable DT = new DataTable();
        DT = db.SQLselect();

        //controllo utente non registrato (si ci basa su USR)

        if ((int)DT.Rows[0]["QUANTI"] == 1)
        {
            lblMessaggio.Text = "Utente già registrato";
            return;
        }

        //salvo i dati

        //inserimento dati in un database

        DB x = new DB();
        x.query = "InserimentoUtenti";
        x.cmd.Parameters.AddWithValue("@USR", wUSR);
        x.cmd.Parameters.AddWithValue("@PWD", wPWD);
        x.cmd.Parameters.AddWithValue("@COGNOME", wCOGNOME);
        x.cmd.Parameters.AddWithValue("@NOME", wNOME);
        x.cmd.Parameters.AddWithValue("@CITTA", wCITTA);
        x.SQLCommand();
        
        //cmd.CommandText = "insert into UTENTI values ('" + wUSR + "','" + wPWD + "','" + wCOGNOME + "','" + wNOME + "','" + wCITTA + "')";
     
        lblMessaggio.Text = "Utente registrato";
        return;
    }
}