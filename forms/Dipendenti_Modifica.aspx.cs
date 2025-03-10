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
        //carico la griglia
        Caricadati();
    }

    protected void btnModifica_Click(object sender, EventArgs e)
    {
        //controllo se l'utente non ha selezionato nulla
        if (griglia.SelectedIndex == -1)
        {
            //in caso gli si rilascia un alert di errore
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Non hai selezionato nulla');", true);
            return;
        }

        //dichiaro una variabile per storare il valore di K_Salone
        // e gli dico che selezionando un record la variabile chiave assume il valore di k_Salone del record selezionato
        string chiave = griglia.SelectedValue.ToString();
        //passare il dato chaive alla pagina per la modifica
        //inviare l'utente alla pagina di modifica
        Response.Redirect("Dipendenti_Modifica2.aspx" + "?c=" + chiave);
    }

    protected void Caricadati()
    {
        DB database = new DB();
        database.query = "DIPENDENTI_SelectAll";
        griglia.DataSource = database.SQLselect();
        griglia.DataBind();
    }
    protected void griglia_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //tolgo visibiltà a K_Dipendente
        e.Row.Cells[1].Visible = false;
        //tolgo visibiltà a K_Salone
        e.Row.Cells[2].Visible = false;
    }
}