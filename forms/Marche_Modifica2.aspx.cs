using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    //dichiaro una variabile per storare il valore passato dll'altra pagina per k_marca
    static string chiave;
    protected void Page_Load(object sender, EventArgs e)
    {
        //metto un !postback per eviatre che quando l'utente clicca aggiorna rimanga in memoria il vlaore caricato all'apertura
        //della pagina e non quello riscritto ex novo per la modifica
        if (!IsPostBack)
        {
            //chiave assumerà il valore c che ricevo dalla pagina Marche_Modifica
            chiave = Request.QueryString["c"].ToString();

            //inserisco la marca selezionata nell'altra pagina (cioè in base a c) dentro il textbox

            //collegarmi al database
            DB database = new DB();
            //gli passo la query
            database.query = "MARCHE_SelezioneChiave";
            database.cmd.Parameters.AddWithValue("@chiave", int.Parse(chiave));
            //creare la datatable
            DataTable DT = new DataTable();
            DT = database.SQLselect();
            //riempio il textbox
            txtAggiorna.Text = DT.Rows[0]["Marca"].ToString();

        }

    }

    protected void btnAggiorna_Click(object sender, EventArgs e)
    {
        //CONTROLLI FORMALI

        //controllo che l'utente abbia inserito un dato
        if (String.IsNullOrEmpty(txtAggiorna.Text))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Dati non validi');", true);
            return;
        }
        
        //controllo che la marca inserita non sia già presente nel database
        DB database = new DB();
        database.query = "MARCHE_CheckRedundantRecords";
        database.cmd.Parameters.AddWithValue("@chiave", int.Parse(chiave));
        database.cmd.Parameters.AddWithValue("@marca", txtAggiorna.Text.Trim());

        //creare la datatable
        DataTable DT = new DataTable();
        DT = database.SQLselect();

        if ((int)DT.Rows[0]["QUANTI"] == 1) //ricordarsi di mettre (int) davanti
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Marca già presente');", true);
            return;
        }







        //collegamento al database
        DB x = new DB();
        //passare la query con il valore del parametro desiderato per indicargli dove fare la modifica (SQL where)
        x.query = "Marche_Update";
        x.cmd.Parameters.AddWithValue("@chiave", int.Parse(chiave));
        x.cmd.Parameters.AddWithValue("@marca", txtAggiorna.Text.Trim());
        x.SQLCommand();

        //ritorno a Marche_Modifica
        Response.Redirect("Marche_Modifica.aspx");
    }
}