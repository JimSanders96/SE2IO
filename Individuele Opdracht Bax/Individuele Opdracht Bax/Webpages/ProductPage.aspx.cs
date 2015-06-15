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

namespace Individuele_Opdracht_Bax
{
    public partial class ProductPage : System.Web.UI.Page
    {
        /// <summary>
        /// Load all products.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        /// <summary>
        /// Creates an object for every product within the selected category.
        /// If for any reason this cannot be done, a popup will appear.
        /// </summary>
        private void LoadProducts()
        {
            try
            {
                var con = DbProvider.GetOracleConnection();
                var com = con.CreateCommand();
                var categoryName = (string)Session["categoryName"];

                com.CommandText =
                                    @"SELECT p.naam,p.standaardplaatje,p.prijs,p.beschrijving,p.artikelnummer
                                FROM PRODUCT p, CATEGORIE_PRODUCT c
                                WHERE p.artikelnummer = c.artikelnummer
                                AND c.categorieId = :cid";


                var pCategory = com.CreateParameter();
                pCategory.DbType = DbType.String;
                pCategory.Value = categoryName;
                pCategory.ParameterName = "cid";
                pCategory.Direction = ParameterDirection.Input;

                com.Parameters.Add(pCategory);

                var r = com.ExecuteReader();

                while (r.Read())
                {
                    var uc = (Product)Page.LoadControl("~/UserControls/Product.ascx");

                    uc.Name = (string)r["naam"];
                    uc.ImageLink = (string)r["standaardplaatje"];
                    uc.Price = (double)r["prijs"];
                    uc.Description = (string)r["beschrijving"];
                    uc.ProductId = Convert.ToInt32(r["artikelnummer"]);

                    innerContent.Controls.Add(uc);
                    uc.LoadData();
                }
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Kon geen producten laden.')</script>");

            }

        }
    }
}