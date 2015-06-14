using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuele_Opdracht_Bax
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateLoginLabel();
        }



        public void UpdateLoginLabel()
        {
            if (Session["loggedin"] is bool && (bool)Session["loggedIn"]==true)
            {
                lblLoggedInUser.Text = (string)Session["username"];
            }
            else
            {
                lblLoggedInUser.Text = "Geen gebruiker ingelogd.";
            }
        }
    }
}