using Microsoft.VisualStudio.TestTools.UnitTesting;
using Platform.Data;
using Platform.Data.Settings;
using MySql;

namespace Platform.Test
{
    [TestClass]
    public class UnitTest1
    {
        private dbCareService dbCareService;
        private DBConfig _config = new DBConfig();


        [TestMethod]
        public void TestMethod1()
        {
            dbCareService = new dbCareService(_config);
            dbCareService.deploy();
        }
    }
}
