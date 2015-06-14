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
    public partial class ProductInformationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadProduct();
            LoadComments();
            if (Session["loggedIn"] is bool && (bool)Session["loggedIn"] == false)
            {
                btnReview.Visible = false;
            }
        }

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

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            Session["addedToCart"] = true;

        }

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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Kon geen producten laden.')</script>");

            }

        }

        /// <summary>
        /// Redirect to displayed website the login webpage.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Redirect_Login(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

    }
}