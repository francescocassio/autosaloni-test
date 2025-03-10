using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    //dichiaro una variabile per storare il valore passato dll'altra pagina per k_cliente
    static string chiave;
    int provaCAP;
    protected void Page_Load(object sender, EventArgs e)
    {
        //metto un !postback per eviatre che quando l'utente clicca aggiorna rimanga in memoria il valore caricato all'apertura
        //della pagina e non quello riscritto ex novo per la modifica
        if (!IsPostBack)
        {
            //chiave assumerà il valore c che ricevo dalla pagina Clienti_Modifica
            chiave = Request.QueryString["c"].ToString();

            //inserisco la marca selezionata nell'altra pagina (cioè in base a c) dentro il textbox

            //collegarmi al database
            DB database = new DB();
            //gli passo la query
            database.query = "CLIENTI_SelezionaChiave";
            database.cmd.Parameters.AddWithValue("@chiave", int.Parse(chiave));
            //creare la datatable
            DataTable DT = new DataTable();
            DT = database.SQLselect();
            //riempio il textbox
            txtCognome.Text = DT.Rows[0]["Cognome"].ToString();
            txtNome.Text = DT.Rows[0]["Nome"].ToString();
            txtCodiceFiscale.Text = DT.Rows[0]["Codice_Fiscale"].ToString();
            txtCitta.Text = DT.Rows[0]["Citta"].ToString();
            txtProvincia.Text = DT.Rows[0]["Provincia"].ToString();
            txtIndirizzo.Text = DT.Rows[0]["Indirizzo"].ToString();
            txtCAP.Text = DT.Rows[0]["CAP"].ToString();
            txtPatente.Text = DT.Rows[0]["Codice_Patente"].ToString();
            txtDataNascita.Text = DT.Rows[0]["Data_di_Nascita"].ToString();
        }
    }

    protected void btnSalva_Click(object sender, EventArgs e)
    {
        //variabile di controllo formato data
        DateTime bornDay;

        //controlli formali

        //controlo che l'utente abbia effettivamente scritto qualcosa
        if (String.IsNullOrEmpty(txtCognome.Text) ||
            String.IsNullOrEmpty(txtNome.Text) ||
            String.IsNullOrEmpty(txtCodiceFiscale.Text) ||
            String.IsNullOrEmpty(txtPatente.Text) ||
            String.IsNullOrEmpty(txtDataNascita.Text)
            )
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Dati Mancanti');", true);
            return;
        }

        //controllo che la data inserita sia valida come formato e la converto nel formato senza orario come in sql server (yyyy-mm-dd)
        if (DateTime.TryParse(txtDataNascita.Text, out bornDay) && !String.IsNullOrEmpty(txtDataNascita.Text))
        {
            bornDay = bornDay.Date;

        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data non valida');", true);
            return;
        }

        //controllo che il codice fiscale e la patente siano completi (16 e 10 simboli alfanumerici)
        if (txtCodiceFiscale.Text.Length != 16)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Codice Fiscale non valido');", true);
            return;
        }
        if (txtPatente.Text.Length != 10)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Codice Patente non valido');", true);
            return;
        }

        //controllo che il CAP o la provincia siano scritti correttamente come formato nel caso non li si aggiorni a vuoto
        if (!int.TryParse(txtCAP.Text, out provaCAP))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('CAP non valido');", true);
            return;

        }


        if (txtCAP.Text.Length != 5 && !String.IsNullOrEmpty(txtCAP.Text))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('CAP non valido');", true);
            return;
        }
        if (txtProvincia.Text.Length != 2 && !String.IsNullOrEmpty(txtProvincia.Text))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('provincia non valida');", true);
            return;
        }

        //controllo che non ci siano dentro sapzi nei campi alfanumerici
        if (
            txtCodiceFiscale.Text.Contains(" ") ||
            txtPatente.Text.Contains(" ") ||
            (txtCAP.Text.Contains(" ") && !String.IsNullOrEmpty(txtCAP.Text)) ||
            (txtProvincia.Text.Contains(" ") && !String.IsNullOrEmpty(txtProvincia.Text))
           )
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Dati alfanumerici non validi);", true);
            return;
        }

        //controllo che non ci siano codici fiscali doppi
        DB database = new DB();
        database.query = "CLIENTI_CheckRedundantRecords";
        database.cmd.Parameters.AddWithValue("@cognome", txtCognome.Text);
        database.cmd.Parameters.AddWithValue("@nome", txtNome.Text);
        database.cmd.Parameters.AddWithValue("@codice_fiscale", txtCodiceFiscale.Text);
        database.cmd.Parameters.AddWithValue("@citta", txtCitta.Text.Trim());
        database.cmd.Parameters.AddWithValue("@provincia", txtProvincia.Text);
        database.cmd.Parameters.AddWithValue("@indirizzo", txtIndirizzo.Text.Trim());
        database.cmd.Parameters.AddWithValue("@data_nascita", txtDataNascita.Text);

        //creare la datatable
        DataTable DT = new DataTable();
        DT = database.SQLselect();

        if ((int)DT.Rows[0]["QUANTI"] == 1) //ricordarsi di mettre (int) davanti
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Codice fiscale già presente');", true);
            return;
        }

        //controllo che non ci sia un codice_patente registrato 2 volte 
        DB patenteDB = new DB();
        patenteDB.query = "CLIENTI_CheckRedundantLicenses";
        patenteDB.cmd.Parameters.AddWithValue("@codice_patente", txtPatente.Text);
        patenteDB.cmd.Parameters.AddWithValue("@codice_fiscale", txtCodiceFiscale.Text);
        patenteDB.cmd.Parameters.AddWithValue("@cognome", txtCognome.Text);
        //creare la datatable
        DataTable DTpatente = new DataTable();
        DTpatente = patenteDB.SQLselect();

        if ((int)DTpatente.Rows[0]["QUANTI"] == 1) //ricordarsi di mettre (int) davanti
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Patente già registrata');", true);
            return;
        }



        //Update

        //collegamento al database
        DB x = new DB();
        //passare la query con il valore del parametro desiderato per indicargli dove fare la modifica (SQL where)
        x.query = "CLIENTI_Update";
        x.cmd.Parameters.AddWithValue("@chiave", int.Parse(chiave));
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

        //ritorno a Marche_Modifica
        Response.Redirect("Clienti_Modifica.aspx");
    }
}