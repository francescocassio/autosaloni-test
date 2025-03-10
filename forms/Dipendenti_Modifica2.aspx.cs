using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    //dichiaro una variabile per storare il valore passato dll'altra pagina per k_dipendente
    static string chiave;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            // Popola la dropdown solo al primo caricamento della pagina
            // Aggiungi la voce "V"
            ddlRuoli.Items.Add(new ListItem("Venditore", "V")); // Testo visualizzato, Valore effettivo
            // Aggiungi la voce "R"
            ddlRuoli.Items.Add(new ListItem("Responsabile", "R")); // Testo visualizzato, Valore effettivo

            //chiave assumerà il valore c che ricevo dalla pagina Dipendenti_Modifica
            chiave = Request.QueryString["c"].ToString();

            //CARICAMENTO DROPDOWNLIST GENERALE
            //collagmento a DB
            DB database = new DB();
            //eseguo query
            database.query = "SALONI_SelectAll";
            ddlSaloni.DataSource = database.SQLselect();
            ddlSaloni.DataValueField = "K_Salone";
            ddlSaloni.DataTextField = "Nome_Salone";
            //indico come la ddl deve visualizzare i valori

            //aggiornamento ddl
            ddlSaloni.DataBind();

            //CARICO VALORI SELEZIONATI NELLA DDL(saloni) e nel TEXTBOX(Nome,Cognome) in base ai valori scelti nella pagina di partenza
            //collegamento database
            DB stampdatabase = new DB();
            //gli passo la query che stampera i valori dalla tabella MODELLI in base alla chiave
            stampdatabase.query = "DIPENDENTI_SelezionaChiave";
            stampdatabase.cmd.Parameters.AddWithValue("@chiave", int.Parse(chiave));
            DataTable DT = new DataTable();
            DT = stampdatabase.SQLselect();
            //valore ddl (saloni)
            ddlSaloni.SelectedValue = DT.Rows[0]["K_Salone"].ToString();
            //valore ddl (ruoli)
            ddlRuoli.SelectedValue = DT.Rows[0]["Ruolo"].ToString();
            //valore in textbox (cognome)
            txtCognome.Text = DT.Rows[0]["Cognome"].ToString();
            //valore in textbox (nome)
            txtNome.Text = DT.Rows[0]["Nome"].ToString();
            //valore in textbox (codice fiscale)
            txtCodiceFiscale.Text = DT.Rows[0]["Codice_Fiscale"].ToString();

        }
    }

    protected void btnSalva_Click(object sender, EventArgs e)
    {
        //controlli formali

        //controllo che l'utente abbia effettivamante scritto qualcosa
        if (String.IsNullOrEmpty(txtCognome.Text) ||
            String.IsNullOrEmpty(txtNome.Text) ||
            String.IsNullOrEmpty(txtCodiceFiscale.Text))

        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Dati non validi');", true);
            return;
        }

        //Controllo il contenuto scritto dall'utente

        //dimensione Codice Fiscale corretta
        if (txtCodiceFiscale.Text.Length != 16)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('CAP non valido');", true);
            return;
        }
       
        //se il codice fiscale contiene spzai
        if (txtCodiceFiscale.Text.Contains(" "))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Dati alfanumerici non validi);", true);
            return;
        }

        //controllo che non ci siano codici fiscali doppi
        DB database = new DB();
        database.query = "DIPENDENTI_CheckRedundantRecords";
        database.cmd.Parameters.AddWithValue("@codice_fiscale", txtCodiceFiscale.Text);
        database.cmd.Parameters.AddWithValue("@cognome", txtCognome.Text);
        database.cmd.Parameters.AddWithValue("@salone", ddlSaloni.SelectedValue);
        database.cmd.Parameters.AddWithValue("@ruolo", ddlRuoli.SelectedValue);

        //creare la datatable
        DataTable DT = new DataTable();
        DT = database.SQLselect();

        if ((int)DT.Rows[0]["QUANTI"] == 1) //ricordarsi di mettre (int) davanti
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Codice fiscale già presente');", true);
            return;
        }

        //collegamento al database
        DB x = new DB();
        //passare la query con il valore del parametro desiderato per indicargli dove fare la modifica (SQL where)
        x.query = "DIPENDENTI_Update";
        x.cmd.Parameters.AddWithValue("@chiave", int.Parse(chiave));
        x.cmd.Parameters.AddWithValue("@cognome", txtCognome.Text.Trim());
        x.cmd.Parameters.AddWithValue("@nome", txtNome.Text.Trim());
        x.cmd.Parameters.AddWithValue("@ruolo", ddlRuoli.SelectedValue);
        x.cmd.Parameters.AddWithValue("@salone", ddlSaloni.SelectedValue);
        x.cmd.Parameters.AddWithValue("@codice_fiscale", txtCodiceFiscale.Text.Trim());

        //eseguo il comando di update
        x.SQLCommand();

        //ritorno a Marche_Modifica
        Response.Redirect("Dipendenti_Modifica.aspx");
    }
}