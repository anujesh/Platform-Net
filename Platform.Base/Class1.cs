
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using Newtonsoft.Json;
//using System.Data;
//using MySql.Data.MySqlClient;

//using Booolean.Core;
//using Dapper;

//using Booolean.Core.Utilities;

//namespace Platform.Base
//{
//    public class dbCareService
//    {
//        const string DELIMETER = ";";

//        string file_module    = "";
//        int file_version        = 0;
//        string file_descrip   = "";
//        int dbModuleVersion = 0;

//        private IConfigManager _confi;
//        private IDbConnection _db;
          
//        private string db_prefix { get; set; }

//        public dbCareService(IConfigManager confi)
//        {
//            _confi = confi;
//            _db = new MySqlConnection(_confi.ConnectionString);
//        }

//        private string[] getFileNamesInFolder(string folder)
//        {
//            string dir = string.Format("{0}{1}{2}", _confi.App_Path_Root, folder, "/");

//            string[] sqlFiles = Directory.GetFiles(dir, "*.sql")
//                                            .Select(path => Path.GetFileName(path))
//                                            .ToArray();
//            return sqlFiles;
//        }

//        private void resetFileProperties()
//        {
//            file_module = "";
//            file_version = 0;
//            file_descrip = "";
//        }

//        private void setFileProperties(string fileName)
//        {
//            try
//            {
//                resetFileProperties();
//                string[] a = fileName.Split('-');

//                file_module = a[0].Trim();
//                file_version = int.Parse(a[1].Trim());
//                file_descrip = a[2].Trim();
//            }
//            catch(Exception ex)
//            {
//                // error on the file name structure
//            }
//        }

//        private void verifyFileNameStructure(string fileName)
//        {
//            if ( file_version <= 0)
//            {
//                failWithMessage(string.Format("Invalid script name +- {0}", fileName));    
//            }
//        }

//        protected string[] getMigrationFolders()
//        {
//            string[] df = "Migrations".Split('|');
//            return df;
//        }

//        private void showMessage(string msg)
//        {
        
//        }

//        private void failWithMessage(string msg)
//        {
        
//        }

//        public string getDbVersionStatus()
//        {
//            /*
//            string sql = string.Format("select module_name,max(version),count(version) from {0}tbl_version_info group by module_name", _confi.DbPrefix);
//            string dt = json_encode(DB::SELECT(sql));
//            return dt;
//            */

//            return "";
//        }

//        private int getCurrentModuleDbVersion(string file_module)
//        {
//            try
//            {
//                string sql = string.Format( @"SELECT max(version) as version 
//                                                    FROM {0}tbl_version_info 
//                                                    WHERE module_name='{1}'", _confi.DbPrefix, file_module);
            
//               return _db.Query<int>(sql).Single();
//            }
//            catch (Exception e)
//            {
//                //DIE("Unable to access the version infomation table, please check the Configs and make sure you run the setup first.");
//                return 0;
//            }
//        }

//    /*
//        private function minify($buffer)
//        {
        
//            $search = array(
//                '',  // strip whitespaces after tags, except space
//                '/[^\S ]+\</s',  // strip whitespaces before tags, except space
//                '/(\s)+/s',       // shorten multiple whitespace sequences
//                '/[\n\r]/',
//                '/;/'
//            );

//            $replace = array(
//                '',
//                '<',
//                '\\1',
//                ' ',
//                '$$'
//            );

//            $buffer = preg_replace($search, $replace, $buffer);
//            return $buffer;

//        static IDictionary<string,string> map = new Dictionary<string,string>()
//            {
//            {"/\>[^\S ]+/s",">"},
//            {"/[^\S ]+\</s","<"},
//            {"1","5"},
//            {"5","6"},
//            };
//        public static void Main(string[] args)
//        {
//            var str = "a1asda&fj#ahdk5adfls";
//            var regex = new Regex(String.Join("|",map.Keys));
//            var newStr = regex.Replace(str, m => map[m.Value]);
//            Console.WriteLine(newStr);

//        }
      
//        }
//     */
    

//        private string getFileContentMinified(string file)
//        {
//            string content = File.ReadAllText(file);
//            content = content.Replace("<db_prefix>", db_prefix);
//            content = content.Replace("<prefix>", db_prefix);
//            //content = minify(content);
        
//            return content;
//        }

//        public void showFiles()
//        {
//            string[] folders = getMigrationFolders();
//            //showMessage(sprintf("ShowFiles - Startup"));

//            foreach(string folder in folders )
//            {
//                //showMessage(sprintf("Getting files name from  - %s", $folder));
//                string[] files = getFileNamesInFolder(folder);
//                if (files != null)
//                {
//                    foreach(string file in files)
//                    {
//                        //showMessage($file);
//                    }
//                }
//            }        
//            //showMessage(sprintf("ShowFiles - End"));
//        }

//        public void deploy(bool mode = true)
//        {
//            setup();

//            //Log::info('Start > Deploy');
//            int _fileVersion = 0;
//            string[] folders = getMigrationFolders();

//            foreach(string folder in folders)
//            {
//                //Log::info('Folder ' . $folder);
//                //showMessage(sprintf("Starting Migration from - %s", $folder));
//                string[] files = getFileNamesInFolder(folder);

//                if (files != null)
//                {
//                    foreach(string file in files)
//                    {
//                        setFileProperties(file);
//                        verifyFileNameStructure(file);    
//                    }

//                    foreach(string file in files)
//                    {
//                        dbModuleVersion = getCurrentModuleDbVersion("");
//                        setFileProperties(file);

//                        if (file_version > dbModuleVersion)
//                        {
//                            string fileContent = getFileContentMinified(file);

//                            string[] sqls = fileContent.Split('$'); // $$
//                            try
//                            {
//                                foreach(string sql in sqls)
//                                {
//                                    if (!string.IsNullOrEmpty(sql))
//                                    {
//                                        if (mode)
//                                        {
//                                            //DB::connection()->getPdo()->exec($sql);
//                                        }
//                                        else
//                                        {
//                                            //showMessage($sql);
//                                        }
//                                    }
//                                }

//                                string sqlv = string.Format(@"INSERT INTO {0}tbl_version_info 
//                                            (`module_name`, `version`, descript) VALUES 
//                                            ('{1}', '{2}', '{3}');", db_prefix, file_module, file_version, file_descrip);
//                                if (mode)
//                                {
//                                    //DB::connection()->getPdo()->exec(sqlv);
//                                }
//                                else
//                                {
//                                    //showMessage(sqlv);
//                                }
//                            }
//                            catch(Exception ex)
//                            {
//                               // DD($e);
//                            }
//                        }
//                    }
//                }
//                else
//                {//
//                   // showMessage(sprintf("No migration scripts found on - %s", $folder));
//                }
//            }
//        }

//        private void setup()
//        {
//            string sql = string.Format("CREATE TABLE IF NOT EXISTS `{0}tbl_version_info` (`id` bigint(20) NOT NULL AUTO_INCREMENT, `module_name` varchar(15) NOT NULL, `version` int(11) DEFAULT NULL, `descript` varchar(150) DEFAULT NULL, PRIMARY KEY (`id`) ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1", db_prefix);
//            _db.Execute(sql);
//            //DB::connection()->getPdo()->exec($sql);
//        }
//    }



//}