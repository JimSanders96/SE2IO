using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuele_Opdracht_Bax
{
    public partial class Review : System.Web.UI.UserControl
    {
        public string Username { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Set values for information objects.
        /// </summary>
        public void LoadData()
        {
            lblRating.Text = "Beoordeling: " + Convert.ToString(Rating);
            lblUser.Text = Username;
            taComment.Value = Comment;
        }
    }
}