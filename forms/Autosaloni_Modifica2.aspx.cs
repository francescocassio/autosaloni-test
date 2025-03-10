using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    //dichiaro una variabile per storare il valore passato dll'altra pagina per k_salone
    static string chiave;
    int provaCAP;
    protected void Page_Load(object sender, EventArgs e)
    {
        //metto un !postback per eviatre che quando l'utente clicca aggiorna rimanga in memoria il valore caricato all'apertura
        //della pagina e non quello riscritto ex novo per la modifica
        if (!IsPostBack)
        {
            //chiave assumerà il valore c che ricevo dalla pagina Autosaloni_Modifica
            chiave = Request.QueryString["c"].ToString();

            //inserisco la marca selezionata nell'altra pagina (cioè in base a c) dentro il textbox

            //collegarmi al database
            DB database = new DB();
            //gli passo la query
            database.query = "SALONI_SelezionaChiave";
            database.cmd.Parameters.AddWithValue("@chiave", int.Parse(chiave));
            //creare la datatable
            DataTable DT = new DataTable();
            DT = database.SQLselect();
            //riempio il textbox
            txtSalone.Text = DT.Rows[0]["Nome_Salone"].ToString();
            txtIndirizzo.Text = DT.Rows[0]["Indirizzo"].ToString();
            txtCAP.Text = DT.Rows[0]["CAP"].ToString();
            txtCitta.Text = DT.Rows[0]["Citta"].ToString();
            txtProvincia.Text = DT.Rows[0]["Provincia"].ToString();


        }
    }

    protected void btnSalva_Click(object sender, EventArgs e)
    {
        //controllo che l'utente abbia effettivamente scritto qualcosa
        if (String.IsNullOrEmpty(txtSalone.Text) ||
            String.IsNullOrEmpty(txtIndirizzo.Text) ||
            String.IsNullOrEmpty(txtCAP.Text) ||
            String.IsNullOrEmpty(txtCitta.Text) ||
            String.IsNullOrEmpty(txtProvincia.Text))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Dati non validi');", true);
            return;
        }
        //Controllo il contenuto scritto dall'utente

        //dimensione CAP

        if (!int.TryParse(txtCAP.Text, out provaCAP))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('CAP non valido');", true);
            return;

        }
                
            if (txtCAP.Text.Length != 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('CAP non valido');", true);
            return;
        }
        //dimesione Provincia
        if (txtProvincia.Text.Length != 2)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('provincia non valida');", true);
            return;
        }
        //se Provincia o CAP presentano spazi
        if (txtCAP.Text.Contains(" ") || txtProvincia.Text.Contains(" "))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Dati alfanumerici non validi);", true);
            return;
        }

        //controllo che non ci sia un autosalone con nome uguale
        DB database = new DB();
        database.query = "SALONI_CheckRedundantRecords";
        database.cmd.Parameters.AddWithValue("@nome_salone", txtSalone.Text.Trim());
        //creare la datatable
        DataTable DT = new DataTable();
        DT = database.SQLselect();

        if ((int)DT.Rows[0]["QUANTI"] == 1) //ricordarsi di mettre (int) davanti
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Autosalone già presente');", true);
            return;
        }

        //collegamento al database
        DB x = new DB();
        //passare la query con il valore del parametro desiderato per indicargli dove fare la modifica (SQL where)
        x.query = "SALONI_Update";
        x.cmd.Parameters.AddWithValue("@chiave", int.Parse(chiave));
        x.cmd.Parameters.AddWithValue("@nome_salone", txtSalone.Text.Trim());
        x.cmd.Parameters.AddWithValue("@indirizzo", txtIndirizzo.Text.Trim());
        x.cmd.Parameters.AddWithValue("@cap", txtCAP.Text);
        x.cmd.Parameters.AddWithValue("@citta", txtCitta.Text);
        x.cmd.Parameters.AddWithValue("@provincia", txtProvincia.Text);
        x.SQLCommand();

        //ritorno a Marche_Modifica
        Response.Redirect("Autosaloni_Modifica.aspx");
    }
}