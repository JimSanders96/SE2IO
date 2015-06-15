using System;
using System.Data.Common;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Individuele_Opdracht_Bax;
using Oracle.ManagedDataAccess.Client;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetOracleConnection()//controle of database connectie werkt
        {
            var con = Individuele_Opdracht_Bax.DbProvider.GetOracleConnection();
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM dual";
            var r = cmd.ExecuteReader();

            r.Read();
        }

        [TestMethod]
        public void TestGetCustomerId()
        {
            int id = 0;

            Individuele_Opdracht_Bax.ShoppingCart cart = new Individuele_Opdracht_Bax.ShoppingCart("Jimbolul");
            id = cart.GetCustomerId("Jimbolul");

            Assert.AreEqual(101, id);
        }
    }
}
