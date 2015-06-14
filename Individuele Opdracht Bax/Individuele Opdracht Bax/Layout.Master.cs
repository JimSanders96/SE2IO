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
        /// <summary>
        /// If there is no session for login yet, create one with value 'false'.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateLoginLabel();
            if (Session["loggedIn"] == null)
            {
                Session["loggedIn"] = false;
            }
        }

        /// <summary>
        /// Unfinished code.
        /// </summary>
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

        /// <summary>
        /// Changes the username display according to whether a user is logged in or not.
        /// Also includes unfinished shopping cart stuff.
        /// </summary>
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