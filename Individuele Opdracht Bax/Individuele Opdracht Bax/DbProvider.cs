using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace Individuele_Opdracht_Bax
{
    /// <summary>
    /// This class serves as a connection to the database.
    /// </summary>
    public static class DbProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DbConnection GetOracleConnection()
        {
            var con = OracleClientFactory.Instance.CreateConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
            con.Open();
            return con;
        }
    }
}