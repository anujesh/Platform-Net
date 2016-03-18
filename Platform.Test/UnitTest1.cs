using Microsoft.VisualStudio.TestTools.UnitTesting;
using Platform.Data;
using Platform.Data.Settings;
using MySql;
using Platform.Core.Interface;
using Platform.Base.Repository;
using Booolean.Core.Models;
using Booolean.Base.Repository;

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

        [TestMethod]
        public void TestMethod1u()
        {
           // ICoreRepository<Stage> repoStage = new StageRepository();
           // Assert.AreEqual(repoStage.Table, "~");

        }
    }
}
