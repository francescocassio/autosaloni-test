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



    protected void btnSalva_Click(object sender, EventArgs e)
    {
        //dichairo variabile di strorage per la marca inserita
        string inserimentoMarca = txtInserimento.Text.Trim();
        //controlo che l'utente abbia effettivamente scritto qualcosa
        if (String.IsNullOrEmpty(inserimentoMarca))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Dati non validi');", true);
            return;
        }

        //creo la connessione al database
        DB database = new DB();
        database.query = "MARCHE_ControlloMarca";
        database.cmd.Parameters.AddWithValue("@marca", inserimentoMarca);
        DataTable DT = new DataTable();
        DT = database.SQLselect();

        //controllo che non sia già presente la marca
        if ((int)DT.Rows[0]["QUANTI"] == 1) //ricordarsi di mettre (int) davanti
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Marca già presente');", true);
            return;
        }

        //se non è presente inserimento
        
        //creo connessione al db
        DB x = new DB();
        //procedo all'inserimento
        x.query = "MARCHE_InserimentoMarca";
        x.cmd.Parameters.AddWithValue("@marca", inserimentoMarca);
        x.SQLCommand();

        //aggiorna i valori della griglia
        //forzo il ricaricamento della griglia in questo caso (vedasi Marche_Modifica)
        CaricaDati();
        //avviso l'utente che la registrazione è avvenuta correttamente
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Marca inserita correttamente');", true);

        //svuot il textbox per procedere ad un nuvo inserimento
        txtInserimento.Text = "";

    }


    protected void CaricaDati()
    {
        //polpolo la griglia
        DB database = new DB();
        database.query = "Marche_SelectAll";
        // gli si va ad indicare che il DataSource è uguale alla DataTable
        grigliaMarche.DataSource = database.SQLselect();
        //aggiorno la griglia
        grigliaMarche.DataBind();
    }

    protected void grigliaMarche_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //tolgo visibilità a k_marca
        e.Row.Cells[0].Visible = false;
    }
}
