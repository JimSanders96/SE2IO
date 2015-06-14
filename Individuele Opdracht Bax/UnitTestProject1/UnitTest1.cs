using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        
    }
}
