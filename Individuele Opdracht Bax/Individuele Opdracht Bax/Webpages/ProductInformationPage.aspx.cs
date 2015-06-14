using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuele_Opdracht_Bax.Webpages
{
    /// <summary>
    /// This webpage contains all data about the currently selected product.
    /// </summary>
    public partial class ProductInformationPage : System.Web.UI.Page
    {
        /// <summary>
        /// Load productdata and reviews.
        /// Also, if there is no user currently logged in, the review-placement will be invisible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadProduct();
            LoadComments();
            if (Session["loggedIn"] is bool && (bool)Session["loggedIn"] == false)
            {
                btnReview.Visible = false;
                taReview.Visible = false;
                rblRating.Visible = false;
            }
        }

        /// <summary>
        /// Load all required productdata into the labels and images etc.
        /// </summary>
        private void LoadProduct()
        {
            try
            {
                var con = DbProvider.GetOracleConnection();
                var com = con.CreateCommand();
                var productId = Convert.ToInt32(Session["productId"]);

                com.CommandText =
                                    @"SELECT *
                                FROM PRODUCT
                                WHERE artikelnummer = :pid";


                var pProduct = com.CreateParameter();
                pProduct.DbType = DbType.String;
                pProduct.Value = productId;
                pProduct.ParameterName = "pid";
                pProduct.Direction = ParameterDirection.Input;

                com.Parameters.Add(pProduct);

                var r = com.ExecuteReader();

                while (r.Read())
                {
                    lblName.Text = (string)r["naam"];
                    lblBrand.Text = (string)r["merk"];
                    lblPrice.Text = Convert.ToString(r["prijs"]);
                    imgProductMain.ImageUrl = (string)r["standaardplaatje"];
                    imgProductSecond.ImageUrl = (string)r["extraplaatjes"];
                    taDescription.Value = (string)r["beschrijving"];


                }

            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Kon geen informatie laden.')</script>");

            }
        }

        /// <summary>
        /// Set the 'addedToCart' session to 'true'.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            Session["addedToCart"] = true;

        }

        /// <summary>
        /// Create a review object on the webpage for each review placed on this product.
        /// If for any reason this cannot be done, a popup will appear.
        /// </summary>
        private void LoadComments()
        {
            try
            {
                var con = DbProvider.GetOracleConnection();
                var com = con.CreateCommand();
                var productId = Convert.ToInt32(Session["productId"]);

                com.CommandText =
                                    @"SELECT gebruikersnaam,beoordeling,commentaar
                                FROM Review
                                WHERE artikelnummer = :pid";


                var pId = com.CreateParameter();
                pId.DbType = DbType.String;
                pId.Value = productId;
                pId.ParameterName = "pid";
                pId.Direction = ParameterDirection.Input;

                com.Parameters.Add(pId);

                var r = com.ExecuteReader();

                while (r.Read())
                {
                    var uc = (Review)Page.LoadControl("~/Review.ascx");

                    uc.Rating = Convert.ToInt32(r["beoordeling"]);
                    uc.Username = (string)r["gebruikersnaam"];
                    uc.Comment = (string)r["commentaar"];
                    reviews.Controls.Add(uc);
                    uc.LoadData();
                }
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Kon geen reviews laden.')</script>");

            }

        }

        /// <summary>
        /// Redirect to the login webpage.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Redirect_Login(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        /// <summary>
        /// When this button is clicked, it is supposed to insert a review into the database.
        /// If for some reason the insert cannot be done, a popup will show on the webpage.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReview_Click(object sender, EventArgs e)
        {
            try
            {
                var con = DbProvider.GetOracleConnection();
                var com = con.CreateCommand();
                var productId = Convert.ToInt32(Session["productId"]);
                var username = (string)Session["username"];
                var comment = (string)taReview.Value;
                var rating = 0;

                if(rblRating.SelectedIndex == 0)
                {
                    rating = 1;
                }
                else if (rblRating.SelectedIndex == 1)
                {
                    rating = 2;
                }
                else if (rblRating.SelectedIndex == 2)
                {
                    rating = 3;
                }
                else if (rblRating.SelectedIndex == 3)
                {
                    rating = 4;
                }
                else if (rblRating.SelectedIndex == 4)
                {
                    rating = 5;
                }

                com.CommandText =
                                    @"INSERT INTO REVIEW
                                      VALUES(sq_review.nextval,:pid,:usr,:rat,:rev,sysdate)";


                var pId = com.CreateParameter();
                pId.DbType = DbType.String;
                pId.Value = productId;
                pId.ParameterName = "pid";
                pId.Direction = ParameterDirection.Input;

                var pUsername = com.CreateParameter();
                pUsername.DbType = DbType.String;
                pUsername.Value = username;
                pUsername.ParameterName = "usr";
                pUsername.Direction = ParameterDirection.Input;

                var pReview = com.CreateParameter();
                pReview.DbType = DbType.String;
                pReview.Value = comment;
                pReview.ParameterName = "rev";
                pReview.Direction = ParameterDirection.Input;

                var pRating = com.CreateParameter();
                pRating.DbType = DbType.String;
                pRating.Value = rating;
                pRating.ParameterName = "rat";
                pRating.Direction = ParameterDirection.Input;

                com.Parameters.Add(pId);
                com.Parameters.Add(pUsername);
                com.Parameters.Add(pReview);
                com.Parameters.Add(pRating);

                com.ExecuteNonQuery();

                
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Kon geen review plaatsen.')</script>");
            }
        }

    }
}