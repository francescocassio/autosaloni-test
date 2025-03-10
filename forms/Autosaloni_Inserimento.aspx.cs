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
        //dichairo variabile di strorage per la modello inserito
        string inserimentoNome = txtNome.Text.Trim();
        string inserimentoIndirizzo = txtIndirizzo.Text.Trim();
        string inserimentoCitta = txtCittà.Text.Trim();
        string inserimentoCAP = txtCAP.Text;
        string inserimentoProvincia = txtProvincia.Text;
        int provaCAP;





        //controlo che l'utente abbia effettivamente scritto qualcosa
        if (String.IsNullOrEmpty(inserimentoNome) ||
            String.IsNullOrEmpty(inserimentoIndirizzo) ||
            String.IsNullOrEmpty(inserimentoCitta) ||
            String.IsNullOrEmpty(inserimentoCAP) ||
            String.IsNullOrEmpty(inserimentoProvincia))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Dati non validi');", true);
            return;
        }

        if (inserimentoCAP.Length != 5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('CAP non valido');", true);
            return;
        }
        if (inserimentoProvincia.Length != 2)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('provincia non valida');", true);
            return;
        }
       

        if (!int.TryParse(txtCAP.Text, out provaCAP))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('CAP non valido');", true);
            return;

        }

        if ( inserimentoCAP.Contains(" ") || inserimentoProvincia.Contains(" "))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Dati alfanumerici non validi);", true);
            return;
        }

        //controllo che non sia già presente un autosalone uguale
        DB database = new DB();
        database.query = "SALONI_CheckRedundantRecords";
        database.cmd.Parameters.AddWithValue("@nome_salone", inserimentoNome);
        //creare la datatable
        DataTable DT = new DataTable();
        DT = database.SQLselect();

        if ((int)DT.Rows[0]["QUANTI"] == 1) //ricordarsi di mettre (int) davanti
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Autosalone già presente allo stesso indirizzo in questa città');", true);
            return;
        }

        //INSERIMENTO 
        //collegamento al database
        DB x = new DB();
        //passare la query con il valore del parametro desiderato per indicargli dove fare la modifica (SQL where)
        x.query = "SALONI_Inserimento";
        x.cmd.Parameters.AddWithValue("@nome_salone", inserimentoNome);
        x.cmd.Parameters.AddWithValue("@indirizzo", inserimentoIndirizzo);
        x.cmd.Parameters.AddWithValue("@cap", inserimentoCAP);
        x.cmd.Parameters.AddWithValue("@citta", inserimentoCitta);
        x.cmd.Parameters.AddWithValue("@provincia", inserimentoProvincia);
        x.SQLCommand();

        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Autosaloni Inserito Correttamente');", true);

        //svuoto i campi per un nuovo inserimento
        txtNome.Text = "";
        txtIndirizzo.Text = "";
        txtCittà.Text = "";
        txtCAP.Text = "";
        txtProvincia.Text = "";
        //rcarico la griglia aggiornata
        Caricadati();
    }

    protected void griglia_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //tolgo visibiltà a K_Salone
        e.Row.Cells[0].Visible = false;
    }

    protected void Caricadati()
    {
        DB database = new DB();
        database.query = "SALONI_SelectAll";
        griglia.DataSource = database.SQLselect();
        griglia.DataBind();
    }
}