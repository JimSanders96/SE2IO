using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuele_Opdracht_Bax
{
    public partial class Category : System.Web.UI.UserControl
    {
        public String Name { get; set; }
        public String ImageLink { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Set values for information objects.
        /// </summary>
        public void LoadData()
        {
            ibCategory.ImageUrl = ImageLink;
            lblCategoryName.Text = Name;
        }

        /// <summary>
        /// Redirect to 'productpage' and create a session for the categoryname.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibCategory_Click(object sender, ImageClickEventArgs e)
        {
            Session["categoryName"] = Name;
            Response.Redirect("ProductPage.aspx");
        }
    }
}