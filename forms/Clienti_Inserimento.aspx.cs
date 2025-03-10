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
        CaricaDati();
    }

    protected void btnInserimento_Click(object sender, EventArgs e)
    {
        //dichiaro le variabili di storahe per l'inserimento dei dati del cliente
        string cognome_cliente = txtCognome.Text.Trim();
        string nome_cliente = txtNome.Text.Trim();
        string citta_cliente = txtCitta.Text.Trim();
        string codice_fiscale_cliente = txtCodiceFiscale.Text;
        string indirizzo_cliente = txtIndirizzo.Text.Trim();
        string CAP_cliente = txtCAP.Text;
        string provincia = txtProvincia.Text;
        string codice_patente_cliente = txtPatente.Text;
        string giorno_di_nascita = txtDataNascita.Text;
        int provaCAP;



     
        //dichiaro una variabile di tipo data (concetto temporale)

        DateTime bornDay;



        //controlo che l'utente abbia effettivamente scritto qualcosa
        if (String.IsNullOrEmpty(cognome_cliente) ||
            String.IsNullOrEmpty(nome_cliente) ||
            String.IsNullOrEmpty(citta_cliente) ||
            String.IsNullOrEmpty(codice_fiscale_cliente) ||
            String.IsNullOrEmpty(CAP_cliente) ||
            String.IsNullOrEmpty(provincia) ||
            String.IsNullOrEmpty(codice_patente_cliente) ||
            String.IsNullOrEmpty(giorno_di_nascita)
            )
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Dati Mancanti');", true);
            return;
        }

        //controllo che la data inserita sia valida come formato e la converto nel formato senza orario come in sql server (yyyy-mm-dd)
        if (DateTime.TryParse(giorno_di_nascita, out bornDay) && !String.IsNullOrEmpty(giorno_di_nascita))
        {
            bornDay = bornDay.Date;
           
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data non valida');", true);
            return;
        }

        //controllo che il codice fiscale e la patente siano completi (16 e 10 simboli alfanumerici)
        if (codice_fiscale_cliente.Length != 16)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Codice Fiscale non valido');", true);
            return;
        }
        if (codice_patente_cliente.Length != 10)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Codice Patente non valido');", true);
            return;
        }
        if (!int.TryParse(txtCAP.Text, out provaCAP))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('CAP non valido');", true);
            return;

        }

        if (CAP_cliente.Length != 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('CAP non valido');", true);
            return;
        }
        if (provincia.Length != 2)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('provincia non valida');", true);
            return;
        }


        if (codice_fiscale_cliente.Contains(" ") || codice_patente_cliente.Contains(" ") || CAP_cliente.Contains(" ") || provincia.Contains(" "))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Dati alfanumerici non validi);", true);
            return;
        }

        //controllo che il cliente non sia già presente

        //controllo che non ci siano clienti già registrati
        DB database = new DB();
        database.query = "CLIENTI_CheckRedundantRecords";
        database.cmd.Parameters.AddWithValue("@cognome", cognome_cliente);
        database.cmd.Parameters.AddWithValue("@nome", nome_cliente);
        database.cmd.Parameters.AddWithValue("@codice_fiscale", codice_fiscale_cliente);
        database.cmd.Parameters.AddWithValue("@citta", citta_cliente);
        database.cmd.Parameters.AddWithValue("@provincia", provincia);
        database.cmd.Parameters.AddWithValue("@indirizzo", indirizzo_cliente);
        database.cmd.Parameters.AddWithValue("@data_nascita", giorno_di_nascita);

        //creare la datatable
        DataTable DT = new DataTable();
        DT = database.SQLselect();

        if ((int)DT.Rows[0]["QUANTI"] == 1) //ricordarsi di mettre (int) davanti
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Cliente già registrato');", true);
            return;
        }

        //controllo che non ci sia un codice_patente registrato 2 volte 
        DB patenteDB = new DB();
        patenteDB.query = "CLIENTI_CheckRedundantLicenses";
        patenteDB.cmd.Parameters.AddWithValue("@codice_patente", codice_patente_cliente);
        patenteDB.cmd.Parameters.AddWithValue("@codice_fiscale", codice_fiscale_cliente);
        patenteDB.cmd.Parameters.AddWithValue("@cognome", cognome_cliente);
        //creare la datatable
        DataTable DTpatente = new DataTable();
        DTpatente = patenteDB.SQLselect();

        if ((int)DTpatente.Rows[0]["QUANTI"] == 1) //ricordarsi di mettre (int) davanti
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Patente già registrata');", true);
            return;
        }

        //registro il cliente

        //collegamento al database
        DB x = new DB();
        //passare la query con il valore del parametro desiderato per indicargli dove fare la modifica (SQL where)
        x.query = "CLIENTI_Inserimento";
        x.cmd.Parameters.AddWithValue("@cognome", txtCognome.Text.Trim());
        x.cmd.Parameters.AddWithValue("@nome", txtNome.Text.Trim());
        x.cmd.Parameters.AddWithValue("@codice_fiscale", txtCodiceFiscale.Text);
        x.cmd.Parameters.AddWithValue("@citta", txtCitta.Text.Trim());
        x.cmd.Parameters.AddWithValue("@provincia", txtProvincia.Text);
        x.cmd.Parameters.AddWithValue("@indirizzo", txtIndirizzo.Text.Trim());
        x.cmd.Parameters.AddWithValue("@cap", txtCAP.Text);
        x.cmd.Parameters.AddWithValue("@codice_patente", txtPatente.Text);
        x.cmd.Parameters.AddWithValue("@data_nascita", txtDataNascita.Text);
        x.SQLCommand();


        //messaggio di conferma registrazione

        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Cliente registarto correttamente');", true);


        //svuoto campi di inserimento

        txtCognome.Text = "";
        txtNome.Text = "";
        txtCitta.Text = "";
        txtCodiceFiscale.Text = "";
        txtIndirizzo.Text = "";
        txtCAP.Text = "";
        txtProvincia.Text = "";
        txtPatente.Text = "";
        txtDataNascita.Text = "";

        //ricarico la tabella
        CaricaDati();
    }

    protected void griglia_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //tolgo visibiltà a K_Cliente
        e.Row.Cells[0].Visible = false;
    }

    protected void CaricaDati()
    {
        DB database = new DB();
        database.query = "CLIENTI_SelectAll";
        griglia.DataSource = database.SQLselect();
        griglia.DataBind();
    }
}