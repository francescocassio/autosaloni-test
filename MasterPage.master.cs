using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //controllo su utente in session
        if (String.IsNullOrEmpty(Session["USR"] as string))
        {
            Response.Redirect("Login.aspx");
        }
    }
}
