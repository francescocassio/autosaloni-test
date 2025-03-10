using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Caricadati();
    }

    protected void btnInserimento_Click(object sender, EventArgs e)
    {
        //dichiaro le variabili di storage per i campi da inserire manualmente
        string cognomeDipendente = txtCognome.Text.Trim();
        string nomeDipendente = txtNome.Text.Trim();
        string codiceFiscale = txtCodiceFiscale.Text;


        //controlo che l'utente abbia effettivamente scritto qualcosa
        if (String.IsNullOrEmpty(cognomeDipendente) || 
            String.IsNullOrEmpty(nomeDipendente) ||
            String.IsNullOrEmpty(codiceFiscale)
            )
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Dati non validi');", true);
            return;
        }

        //controllo che il codice fiscale sia stato inserito correttamente
        if (txtCodiceFiscale.Text.Length != 16)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Codice Fiscale non valido');", true);
            return;
        }
        if (txtCodiceFiscale.Text.Contains(" "))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Dati alfanumerici non validi);", true);
            return;
        }




        //controllo che non ci siano dipendenti già registrati
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

        //Inserimento dipendente con autosalone associato
        //collegamento al database
        DB x = new DB();
        //passare la query con il valore del parametro desiderato per indicargli dove fare la modifica (SQL where)
        x.query = "DIPENDENTI_Inserimento";
        x.cmd.Parameters.AddWithValue("@cognome", txtCognome.Text.Trim());
        x.cmd.Parameters.AddWithValue("@nome", txtNome.Text.Trim());
        x.cmd.Parameters.AddWithValue("@ruolo", ddlRuoli.SelectedValue);
        x.cmd.Parameters.AddWithValue("@salone", ddlSaloni.SelectedValue);
        x.cmd.Parameters.AddWithValue("@codice_fiscale", txtCodiceFiscale.Text.Trim());

        //eseguo il comando di update
        x.SQLCommand();

        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Dipendente registrato correttamente');", true);

        //svuoto campi di inserimento
        txtNome.Text = "";
        txtCognome.Text = "";
        txtCodiceFiscale.Text = "";
        //ricarico la griglia
        Caricadati();


    }

    protected void Caricadati()
    {
        DB database = new DB();
        database.query = "DIPENDENTI_SelectAll";
        griglia.DataSource = database.SQLselect();
        griglia.DataBind();

        if (!IsPostBack)
        {
            // Popola la dropdown solo al primo caricamento della pagina
            // Aggiungi la voce "V"
            ddlRuoli.Items.Add(new ListItem("Venditore", "V")); // Testo visualizzato, Valore effettivo
            // Aggiungi la voce "R"
            ddlRuoli.Items.Add(new ListItem("Responsabile", "R")); // Testo visualizzato, Valore effettivo

            //CARICAMENTO DROPDOWNLIST GENERALE

            //saloni
            //collagmento a DB
            DB db = new DB();
            //eseguo query
            db.query = "SALONI_SelectAll";
            ddlSaloni.DataSource = db.SQLselect();
            ddlSaloni.DataValueField = "K_Salone";
            ddlSaloni.DataTextField = "Nome_Salone";
            ddlSaloni.DataBind();
            
        }
    }

    protected void griglia_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //tolgo visibiltà a K_Dipendente
        e.Row.Cells[0].Visible = false;
        //tolgo la visibilità a K_Salone
        e.Row.Cells[1].Visible = false;
    }
}