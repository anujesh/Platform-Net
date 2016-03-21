using Microsoft.VisualStudio.TestTools.UnitTesting;
using Platform.Data;
using Platform.Data.Settings;
using MySql;

namespace Platform.Test
{
    [TestClass]
    public class UnitTest1
    {
        private DbCareService dbCareServ;
        private DBConfig _config = new DBConfig();

        // integration test
        [TestMethod]
        public void TestMethod1()
        {
            TestDbAccess testDbAccess = new TestDbAccess();
            testDbAccess.ExecuteSQL("DROP DATABASE IF EXISTS `test-builder`;");
            testDbAccess.ExecuteSQL("CREATE DATABASE `test-builder`;");
            testDbAccess.ExecuteSQL("USE `test-builder`;");

            dbCareServ = new DbCareService(_config);
            dbCareServ.deploy();
        }
    }
}
