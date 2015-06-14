using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuele_Opdracht_Bax
{

    public partial class Product : System.Web.UI.UserControl
    {

        public String Name { get; set; }
        public String Description { get; set; }
        public double Price { get; set; }
        public String ImageLink { get; set; }
        public int ProductId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadData()
        {
            ibProduct.ImageUrl = ImageLink;
            taDescription.Value = Description;
            lblProductName.Text = Name;
            lblProductPrice.Text = Convert.ToString(Price); 
        }

        protected void ibProduct_Click(object sender, EventArgs e)
        {
            Session["productId"] = ProductId;
            Response.Redirect("~/Webpages/ProductInformationPage.aspx");
        }
    }
}