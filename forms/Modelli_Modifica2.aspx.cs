using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    //dichiarazione della variabile contente la chiave
    static string chiave;
    protected void Page_Load(object sender, EventArgs e)
    {
        //metto un !postback per evitare che quando l'utente clicca aggiorna rimanga in memoria il valore caricato all'apertura
        //della pagina e non quello riscritto ex novo per la modifica


        //aggiorno la pagina solo al primo caricamento
        if (!IsPostBack)
        {
            //chiave assumerà il valore c che ricevo dalla pagina Modelli_Modifica
            chiave = Request.QueryString["c"].ToString();

            //CARICAMENTO DROPDOWNLIST GENERALE
            //collagmento a DB
            DB database = new DB();
            //eseguo query
            database.query = "Marche_SelectAll";
            ddlMarche.DataSource = database.SQLselect();
            //indico come la ddl deve visualizzare i valori
            ddlMarche.DataValueField = "K_Marca";
            ddlMarche.DataTextField = "Marca";
            //aggiornamento ddl
            ddlMarche.DataBind();

            //CARICO VALORI SELEZIONATI NELLA DDL(marca) e nel TEXTBOX(modello) in base ai valori scelti nella pagina di partenza
            //collegamento database
            DB stampdatabase = new DB();
            //gli passo la query che stampera i valori dalla tabella MODELLI in base alla chiave
            stampdatabase.query = "Modello_SelezionaChiave";
            stampdatabase.cmd.Parameters.AddWithValue("@chiave", int.Parse(chiave));
            DataTable DT = new DataTable();
            DT = stampdatabase.SQLselect();
            //valore dddl (marca)
            ddlMarche.SelectedValue = DT.Rows[0]["K_Marca"].ToString();
            //valore in textbox (modello)
            txtModello.Text = DT.Rows[0]["Modello"].ToString();
        }
    }

    protected void btnSalva_Click(object sender, EventArgs e)
    {
        //controlli formali

        //controllo che l'utente abbia inserito un dato nei modelli
        if (String.IsNullOrEmpty(txtModello.Text))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Dati non validi');", true);
            return;
        }

        //controllo che il modello non sia già presente nel database 
        DB database = new DB();
        database.query = "MODELLI_CheckRedundantRecords";
        database.cmd.Parameters.AddWithValue("@chiave", int.Parse(chiave));
        database.cmd.Parameters.AddWithValue("@marca", ddlMarche.SelectedValue);
        //creare la datatable
        DataTable DT = new DataTable();
        DT = database.SQLselect();

        if ((int)DT.Rows[0]["QUANTI"] == 1) //ricordarsi di mettre (int) davanti
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Marca già presente');", true);
            return;
        }

        //UPDATE

        //connesione al database
        DB x = new DB();
        //gli passo la query
        x.query = "Modelli_Update";
        //gli passo la chiave e i valori dalla dropdownlist  e dalla textbox
        x.cmd.Parameters.AddWithValue("@marca", ddlMarche.SelectedValue);
        x.cmd.Parameters.AddWithValue("@modello", txtModello.Text.Trim());
        x.cmd.Parameters.AddWithValue("@chiave", int.Parse(chiave));
        //update dati del modello
        x.SQLCommand();
        //ritorno alla pagina Modelli_Modifica
        Response.Redirect("Modelli_Modifica.aspx");
    }
}