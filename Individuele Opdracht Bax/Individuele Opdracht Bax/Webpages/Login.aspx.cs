﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuele_Opdracht_Bax
{
    public partial class Login : System.Web.UI.Page
    {
        /// <summary>
        /// Create a viewstate of the previously accessed webpage.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["RefUrl"] = Request.UrlReferrer.ToString();
            }
        }

        /// <summary>
        /// Checks whether the combination of username and password exists in the database.
        /// If the login is succesful, return to previously accessed webpage.
        /// If for any reason this cannot be done, a popup will appear.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                var username = tbUsername.Text;
                var password = tbPassword.Value;
                var con = DbProvider.GetOracleConnection();
                var com = con.CreateCommand();
                com.CommandText = "SELECT count(*) FROM ACCOUNT WHERE Gebruikersnaam = :usr AND Wachtwoord = :pass";


                var pUser = com.CreateParameter();
                pUser.DbType = DbType.String;
                pUser.Value = username;
                pUser.ParameterName = "usr";
                pUser.Direction = ParameterDirection.Input;

                var pPass = com.CreateParameter();
                pPass.DbType = DbType.String;
                pPass.Value = password;
                pPass.ParameterName = "pass";
                pPass.Direction = ParameterDirection.Input;

                com.Parameters.Add(pUser);
                com.Parameters.Add(pPass);

                Debug.WriteLine(pPass.Value);
                var cnt = (decimal)com.ExecuteScalar();
                Debug.WriteLine(cnt);
                if (cnt >= 1)
                {
                    //login
                    Session["loggedIn"] = true;
                    Session["username"] = username;

                    object refUrl = ViewState["RefUrl"];
                    if (refUrl != null)
                        Response.Redirect((string)refUrl);

                }
                else
                {
                    //error
                    
                    Session["loggedIn"] = false;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Gebruikersnaam / wachtwoord ongeldig.')</script>");

                }
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Kon geen gegevens controleren.')</script>");
            }



        }

        /// <summary>
        /// Return to the previously accessed webpage.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            object refUrl = ViewState["RefUrl"];
            if (refUrl != null)
                Response.Redirect((string)refUrl);
        }
    }
}
