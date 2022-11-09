using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using WpfApp1;


namespace UnitTestBorder
{
    [TestClass]
    public class sqlCheck
    {
        [TestMethod]
        public void SqlCheckReturn()
        {
            string sqlTsql = "Select Count(*) as 'Counts' From INFORMATION_SCHEMA.TABLES Where TABLE_TYPE = 'BASE TABLE'";
            string result = "10";
            DataTable dt = sqlCon.sqlServer(sqlTsql);
            string sqlMB = dt.Rows[0][0].ToString();

            Assert.AreEqual(result, sqlMB);
        }

        [TestMethod]
        public void SqlCatchReturn()
        {
            string sqlTsql = "Select";
            string result = null;
            DataTable sqlMB = sqlCon.sqlServer(sqlTsql);
            Assert.AreEqual(result, sqlMB);
        }
    }
}
