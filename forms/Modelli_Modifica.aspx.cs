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
        //riempimento della griglia
        CaricaDati();
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

    protected void griglia_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //tolgo visibiltà a k_marca
        e.Row.Cells[1].Visible = false; 
        //tolgo visibiltà a k_modello
        e.Row.Cells[2].Visible = false;
    }

    protected void btnModifica_Click(object sender, EventArgs e)
    {
        //Prendiamo il valore dalla selezione della tabella
        if (griglia.SelectedIndex == -1)
        {
            //in caso gli si rilascia un alert di erro
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Non hai selezionato nulla');", true);
            return;
        }

        //dichiaro una variabile per storare il valore di K_Modello
        // e gli dico che selezionando un record la variabile chiave assume il valore di k_Modello del recor selezionato
        string chiave = griglia.SelectedValue.ToString();
        //passare il dato chiave alla pagina per la modifica
        //inviare l'utente alla pagina di modifica
        Response.Redirect("Modelli_Modifica2.aspx" + "?c=" + chiave);
    }
}