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
        public ShoppingCart ShoppingCart { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateLoginLabel();
        }

        public void UpdateShoppingCart()
        {
            if (Session["addToCart"] is bool && (bool)Session["loggedIn"])
            {
                lblItemsInCart.Text = "Producten in winkelwagen: " + Convert.ToString(ShoppingCart.ProductIds.Count);
            }
            else
            {
                
            }
        }

        public void UpdateLoginLabel()
        {
            string user = "test";

            if (Session["loggedin"] is bool && (bool)Session["loggedIn"]==true)
            {
                user = (string)Session["username"];
                lblLoggedInUser.Text = user;

                if (Session["addToCart"] is bool && (bool)Session["loggedIn"])
                {
                    lblItemsInCart.Text = "Producten in winkelwagen: " + Convert.ToString(ShoppingCart.ProductIds.Count);
                }
                else
                {
                    ShoppingCart = new ShoppingCart(user);
                }

                }
                else
                {
                    lblLoggedInUser.Text = "Geen gebruiker ingelogd.";
                }
            }
    }
}