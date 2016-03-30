using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Dapper;
using Platform.Base;
using Platform.Core.Utilities;

namespace Platform.Data
{
    public class DbCareService : DBAccess
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(DbCareService));

        private ICoreConfigMan _config;

        string db_prefix;
        int fileVersion = 0;
        List<DbVersionInfo> listDbInfos;

        public DbCareService
        (
            ICoreConfigMan config
        )
        {
            _log.InfoFormat("DbCareService Constructing");

            _config = config;
            db_prefix = _config.DbPrefix;

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
            _log.InfoFormat("getDbVersionStatus");
            List<DbVersionInfo> listDbInfo = new List<DbVersionInfo>();

            using (var conn = GetOpenConnection())
            {
                string sql = string.Format(@"select module_name,max(version) as version_max,count(version) as version_count
                                from {0}tbl_version_info group by module_name", db_prefix);
                listDbInfo = conn.Query<DbVersionInfo>(sql).AsList();
            }

            return listDbInfo;
        }

        public bool deploy(bool mode = true)
        {
            _log.InfoFormat("Deploy {0}", mode);
            fileVersion = 0;

            string[] folders = _config.DbMigrationFolders;

            foreach(string folder in folders)
            {
                _log.InfoFormat("Deploy ; Loading files from {0}", folder);
                string[] files = Directory.GetFiles(string.Format(_config.DbMigrationBase,folder));

                ScriptInfo si = new ScriptInfo();

                foreach(string file in files)
                {
                    if (!si.VerifyFileNameStructure(file))
                    {
                        return false;
                    }
                }

                string sqlin = string.Empty;

                foreach (string file in files)
                {
                    _log.InfoFormat("Deploy : Loading file {0}", file);
                    int dbModuleVersion = getCurrentModuleDbVersion(folder);
                    si.LoadScriptFile(file);

                    _log.InfoFormat("Deploy : Compaire {0} x {2}", si.Version , dbModuleVersion);
                    if (si.Version > dbModuleVersion)
                    {
                        try
                        {
                            si.LoadScriptFile(file);
                            sqlin = si.Content.Replace(@"<prefix>", db_prefix) + "" + String.Format(@"INSERT INTO {0}tbl_version_info 
                                                    (`module_name`, `version`, descript) 
                                                    VALUES ('{1}', '{2}', '{3}');", db_prefix, si.Module, si.Version, si.Descript);

                            _log.InfoFormat("Deploy : SQl - {0}", sqlin);
                            ExecuteSQL(sqlin);
                        }
                        catch (Exception ex)
                        {
                            _log.ErrorFormat("Deploy - Running SQL > " + sqlin, ex.Message);
                            throw ex;
                        }
                    }
                }
            }

            return true;
        }

        public void ExecuteSQL(string sqlin)
        {
            _log.InfoFormat("Execute SQL : {0}", sqlin);
            using (SqlMapper.GridReader multi = GetConnection().QueryMultiple(sqlin))
            {
            }
        }

        public string basename(string fileName)
        {
            return _config.DbMigrationBase + fileName;
        }

        private int getCurrentModuleDbVersion(string fileModule)
        {
            _log.InfoFormat("getCurrentModuleDbVersion {0}", fileModule);
            int found = 0;

            try
            {
                int.TryParse(listDbInfos.Where(x => x.module_name == fileModule).FirstOrDefault().version_max, out found);
                return found;
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("getCurrentModuleDbVersion ; {0}", ex.Message);
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
        private const string REGEX_FILENAME = @"(\b[A-Z]\w*\b) - (\d{6}) - (\b[ a-zA-Z0-9]{10,90}\b).mysql";

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
            Regex regex = new Regex(REGEX_FILENAME);
            Match match = regex.Match(fileName);

            return match.Success;
        }

        public bool LoadScriptFile(string fileName)
        {
            ResetProperties();

            Regex regex = new Regex(REGEX_FILENAME);
            Match match = regex.Match(Path.GetFileName(fileName));

            Module = match.Groups[1].Value;
            Version = Int16.Parse(match.Groups[2].Value);
            Descript = match.Groups[3].Value;


            Content = File.ReadAllText(fileName);
            //Content = Content.Replace("<db_prefix>", db_prefix);
            //Content = Content.Replace("<prefix>", db_prefix);
            //Content = $this->minify($content);

            return true;
        }
    }
}

