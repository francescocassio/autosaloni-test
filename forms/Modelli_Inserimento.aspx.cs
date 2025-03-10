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
    static string inserimentoModello;
    protected void Page_Load(object sender, EventArgs e)
    {
        CaricaDati();
        if (!IsPostBack)
        {
            //CARICAMENTO DROPDOWNLIST GENERALE
            //collagmento a DB
            DB db = new DB();
            //eseguo query
            db.query = "Marche_SelectAll";
            ddlMarca.DataSource = db.SQLselect();
            //indico come la ddl deve visualizzare i valori
            ddlMarca.DataValueField = "K_Marca";
            ddlMarca.DataTextField = "Marca";
            //aggiornamento ddl
            ddlMarca.DataBind();
        }
    }

    protected void btnSalva_Click(object sender, EventArgs e)
    {
        //dichairo variabile di strorage per la modello inserito
        string inserimentoModello = txtInserimento.Text.Trim();

        //controlo che l'utente abbia effettivamente scritto qualcosa
        if (String.IsNullOrEmpty(inserimentoModello))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Dati non validi');", true);
            return;
        }

        //controllo che non sia già presente lo stesso modello

        DB database = new DB();
        database.query = "MODELLI_ControllaModello";
        database.cmd.Parameters.AddWithValue("@marca", ddlMarca.SelectedValue);
        database.cmd.Parameters.AddWithValue("@modello", inserimentoModello);
        //creare la datatable
        DataTable DT = new DataTable();
        DT = database.SQLselect();

        if ((int)DT.Rows[0]["QUANTI"] == 1) //ricordarsi di mettre (int) davanti
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Modello già presente');", true);
            return;
        }



        //Inserimento

        //connesione al database
        DB x = new DB();
        //gli passo la query
        x.query = "Modelli_Inserimento";
        //gli passo la chiave e i valori dalla dropdownlist  e dalla textbox
        x.cmd.Parameters.AddWithValue("@marca", ddlMarca.SelectedValue);
        x.cmd.Parameters.AddWithValue("@modello", inserimentoModello);
        //update dati del modello
        x.SQLCommand();
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Modello aggiunto correttamente');", true);

        txtInserimento.Text = "";
        CaricaDati();
    }

    protected void griglia_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //tolgo visibiltà a k_modello e K_marca
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
    }

    protected void CaricaDati()
    {
        //Connessione al DB e selezione con la query dei dati con cui riempire la tabella

        //connetterci al database
        DB database = new DB();
        //popolare la griglia
        database.query = "MODELLI_SelectAll";
        griglia.DataSource = database.SQLselect();
        //aggiorno la griglia
        griglia.DataBind();

    }
}