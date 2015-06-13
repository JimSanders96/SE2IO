using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuele_Opdracht_Bax
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Redirect_Login(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Add_UserControl(object sender, EventArgs e)
        {
            var uc = (WebUserControl1)Page.LoadControl("test.ascx");


            

            innerContent.Controls.Add(uc);
            
        }
    }
}