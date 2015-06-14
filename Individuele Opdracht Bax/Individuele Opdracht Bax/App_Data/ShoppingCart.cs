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
    /// <summary>
    /// This class was supposed to be a way of storing product ID's for later insertion into the database.
    /// However, there was no time to correctly implement this.
    /// </summary>
    public class ShoppingCart
    {
        public List<int> ProductIds { get; set; }
        public int CustomerId { get; set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sessionUsername"></param>
        public ShoppingCart(string sessionUsername)
        {
            ProductIds = new List<int>();
            CustomerId = GetCustomerId(sessionUsername);
            
        }

        /// <summary>
        /// Return the customerId from a given username.
        /// </summary>
        /// <param name="sessionUsername"></param>
        /// <returns></returns>
        public int GetCustomerId(string sessionUsername)
        {
            int customerId = -1;

            var con = DbProvider.GetOracleConnection();
            var com = con.CreateCommand();
            var username = sessionUsername;

            com.CommandText =
                                @"SELECT klantId
                                FROM ACCOUNT
                                WHERE gebruikersnaam = :usr";


            var pUsername = com.CreateParameter();
            pUsername.DbType = DbType.String;
            pUsername.Value = sessionUsername;
            pUsername.ParameterName = "usr";
            pUsername.Direction = ParameterDirection.Input;

            com.Parameters.Add(pUsername);

            var r = com.ExecuteReader();

            while (r.Read())
            {
                customerId = Convert.ToInt32(r["klantId"]);
            }

            return customerId;
        }



        public void AddProductId(int productId)
        {
            ProductIds.Add(productId);
        }

        
    
    }
}