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
            
            LoadCategories();
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

        /// <summary>
        /// Test method. This method adds a test user control to the index webpage.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Add_UserControl(object sender, EventArgs e)
        {
            var uc = (WebUserControl1)Page.LoadControl("test.ascx");
            innerContent.Controls.Add(uc);
            
        }

        private void LoadCategories()
        {
            var con = DbProvider.GetOracleConnection();
            var com = con.CreateCommand();
            
            com.CommandText =
                                @"SELECT naam,plaatje
                                FROM CATEGORIE
                                WHERE BehoortTot = 'Gitaar'";
            
            var r = com.ExecuteReader();

            while (r.Read())
            {
                var uc = (Category)Page.LoadControl("Category.ascx");

                uc.Name = (string) r["naam"];
                uc.ImageLink = (string) r["plaatje"];
            
                innerContent.Controls.Add(uc);
                uc.LoadData();
            }
        }
    }
    }
