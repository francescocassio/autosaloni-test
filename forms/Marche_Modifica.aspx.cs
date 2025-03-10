using System;
using System.Collections.Generic;
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
    protected void btnModifica_Click(object sender, EventArgs e)
    {
        //controllo se l'utente non ha selezionato nulla
        if (grigliaMarche.SelectedIndex == -1)
        {
            //in caso gli si rilascia un alert di erro
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Non hai selezionato nulla');", true);
            return;
        }

        //dichiaro una variabile per storare il valore di K_Marca
        // e gli dico che selezionando un record la variabile chiave assume il valore di k_Marca del recor selezionato
        string chiave = grigliaMarche.SelectedValue.ToString();
        //passare il dato chaive alla pagina per la modifica
        //inviare l'utente alla pagina di modifica
        Response.Redirect("Marche_Modifica2.aspx" + "?c=" + chiave);

    }

    protected void CaricaDati()
    {
        //connetterci al database
        DB database = new DB();
        //popolare la griglia
        database.query = "Marche_SelectAll";
        grigliaMarche.DataSource = database.SQLselect();
        //aggiorno la griglia
        grigliaMarche.DataBind();
    }



    protected void grigliaMarche_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //tolgo visibiltà a k_marca
        e.Row.Cells[1].Visible = false;
    }
}