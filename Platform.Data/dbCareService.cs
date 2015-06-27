using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Platform.Core;
using Platform.Core.Utilities;
using Dapper;
using System.IO;

namespace Platform.Data
{
    public class dbCareService : DBAccess
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(dbCareService));

        private IConfigManager _config;

        string db_prefix = "";
        int fileVersion = 0;
        List<DbVersionInfo> listDbInfos;

        public dbCareService
        (
            IConfigManager config
        )
        {
            _config = config;

            

            string sql = String.Format(@"CREATE TABLE IF NOT EXISTS {0}tbl_version_info
                            (id bigint(20) NOT NULL AUTO_INCREMENT, 
                            module_name varchar(15) NOT NULL, 
                            version int(11) DEFAULT NULL, 
                            descript varchar(150) DEFAULT NULL, 
                            PRIMARY KEY (id) ) 
                            ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1", db_prefix);

            using (var conn = GetOpenConnection())
            {
                conn.Execute(sql);
            }

            listDbInfos = getDbVersionStatus();
        }

        private List<DbVersionInfo> getDbVersionStatus()
        {
            List<DbVersionInfo> listDbInfo = new List<DbVersionInfo>();

            using (var conn = GetOpenConnection())
            {
                string sql = @"select module_name,max(version) as version_max,count(version) as version_count
                                from " + db_prefix + "tbl_version_info group by module_name";
                listDbInfo = conn.Query<DbVersionInfo>(sql).AsList();
            }

            return listDbInfo;
        }

        public void deploy(bool mode = true)
        {
            fileVersion = 0;

            String[] folders = _config.DbMigrationFolders.Split('|'); // "BASIC|PLATFORM|CUSTOM|APPLICATION".Split('|');

            foreach(String folder in folders)
            {
                String[] files = Directory.GetFiles(_config.DbMigrationBase + folder);

                ScriptInfo si = new ScriptInfo();

                foreach(String file in files)
                {
                    si.VerifyFileNameStructure(file);
                }

                foreach(String file in files)
                {
                    int dbModuleVersion = getCurrentModuleDbVersion(folder);
                    si.LoadScriptFile(basename(file));

                    if (si.Version > dbModuleVersion)
                    {
                        try
                        {
                            si.LoadScriptFile(file);
                            string sqlin = si.Content + ";" + String.Format(@"INSERT INTO {0}tbl_version_info 
                                                    (`module_name`, `version`, descript) 
                                                    VALUES ('{1}', '{2}', '{3}');", db_prefix, si.Module, si.Version, si.Descript);

                            using (SqlMapper.GridReader multi = GetConnection().QueryMultiple(sqlin))
                            {
                            }
                        }
                        catch(Exception ex)
                        {
                            log.ErrorFormat("Deploy - Running SQL Scripts" , ex.Message);
                        }
                    }
                }
            }
        }

        public string basename(string fileName)
        {
            return _config.DbMigrationBase + fileName;
        }

        private int getCurrentModuleDbVersion(string fileModule)
        {
            int found = 0;

            try
            {
                int.TryParse(listDbInfos.Where(x => x.module_name == fileModule).FirstOrDefault().version_max, out found);
                return found;
            }
            catch (Exception ex)
            {
                //DIE("Unable to access the version infomation table, please check the Configs and make sure you run the setup first.");
            }

            return found;
        }
    }


    public class DbVersionInfo
    {
        public string module_name {get; set;}
        public string version_max {get; set;}
        public string version_count {get; set;}
    }

    public class ScriptInfo
    {
        public ScriptInfo()
        {
            ResetProperties();
        }

        public void ResetProperties()
        {
            Module = "";
            Version = 0;
            Descript = "";
            ErrorNo = 1;
            ErrorMsg = "";

            Content = "";
        }

        public string Module {get; set;}
        public int Version {get; set;}
        public string Descript {get; set;}

        public int ErrorNo {get; set;}
        public string ErrorMsg {get; set;}
        public string Content {get; set;}
        public string db_prefix {get; set;}

        public bool VerifyFileNameStructure(string fileName)
        {
            return true;
        }

        public bool LoadScriptFile(string fileName)
        {
            ResetProperties();

            Content = File.ReadAllText(fileName);
            Content = Content.Replace("<db_prefix>", db_prefix);
            Content = Content.Replace("<prefix>", db_prefix);
            //Content = $this->minify($content);

            return true;
        }
    }
}

