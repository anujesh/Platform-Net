using Dapper;
using Platform.Base;
using Platform.Core;
using Platform.Core.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using Platform.Data.Settings;

namespace Platform.Data
{


    //_config.BackupPath

    public class DBHandler : DBAccess
    {
        string DataExtension = ".csv";
        string ScriptExtension = ".sql";
        string databaseName = "";
        string backupName;

        private IDBConfig _config;

        public DBHandler(IDBConfig config)
        {
            _config = config;

            backupName = DateTime.Now.ToString("Ymd-his-D");
        }

    /*---------------------------------------------------------------------------------------------*/

        private IEnumerable<string> getDataFiles()
        {
            String[] files = Directory.GetFiles(_config.DataPath);

            foreach(string file in files)
            {
                yield return file;
            }
        }

        private IEnumerable<string> getBackupFiles()
        {
            String[] files = Directory.GetFiles(_config.BackupBasePath);

            foreach(string file in files)
            {
                yield return file;
            }
        }

        private IEnumerable<string> getSchemaFiles()
        {
            String[] files = Directory.GetFiles(_config.SchemaPath);

            foreach(string file in files)
            {
                yield return file;
            }
        }

        public string prepairForBackup()
        {
            Directory.CreateDirectory(_config.BackupBasePath + backupName);

            string backupPath = _config.BackupBasePath + backupName + "/";
            Directory.CreateDirectory(backupPath + "schema");
            Directory.CreateDirectory(backupPath + "data");

            return backupPath;
        }


        private List<string> getAllTable()
        {
            List<string> listTables = new List<string>();

            using (var conn = GetOpenConnection())
            {
                var query = string.Format(
                @"SELECT TABLE_NAME 
                        FROM INFORMATION_SCHEMA.TABLES 
                        WHERE TABLE_TYPE='BASE TABLE' 
                            and TABLE_SCHEMA='{0}'", databaseName);
                listTables = conn.Query<string>(query).AsList();
            }
            return listTables;
        }

        private List<string> getAllViews()
        {
            List<string> listViews = new List<string>();

            using (var conn = GetOpenConnection())
            {
                var query = string.Format(
                @"SELECT TABLE_NAME 
                        FROM INFORMATION_SCHEMA.VIEWS 
                        WHERE TABLE_SCHEMA='{0}'", databaseName);
                listViews = conn.Query<string>(query).AsList();
            }
            return listViews;
        }

        /*---------------------------------------------------------------------------------------------*/

        protected void deleteAllTables()
        {
            List<string> tables = getAllTable();
            foreach(string t in tables)
            {
                deleteOneTable(t);
            }
        }

        protected void deleteOneTable(string lTableName)
        {
            string query = string.Format("DROP TABLE {0}", lTableName);
            //this.conn.Execute(sqlQuery);
        }

        /*---------------------------------------------------------------------------------------------*/

        protected void deleteAllViews()
        {
            List<string> views = getAllTable();
            foreach(string v in views)
            {
                deleteOneView(v);
            }
        }

        protected void deleteOneView(string lViewName)
        {
            string query = string.Format("DROP VIEW {0}", lViewName);
            //this.conn.Execute(sqlQuery);
        }

        /*---------------------------------------------------------------------------------------------*/


        public void backupAllTables() 
        {
            List<string>  tables = getAllTable();
            foreach(string t in tables)
            {
                backupOneTable(t);
            }
        }

        public string backupOneTable(string lTableName) 
        {
            string outFile = string.Format("{0}data/{1}{2}", lTableName, lTableName, DataExtension) ;

            if (File.Exists(outFile))
                File.Delete(outFile);


            string sql = string.Format("SELECT * INTO OUTFILE '{0}' FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '~' LINES TERMINATED BY '\n' FROM {1}", 
                                        outFile, lTableName);
            using (var conn = GetOpenConnection())
            {
                conn.Execute(sql);
            }

            return outFile;
        }

        /*---------------------------------------------------------------------------------------------*/

        protected void getAllSchemas()
        {
            List<string> tables = getAllTable();
            foreach(string t in tables)
            {
                //getOneTableSchema(t);
            }

            List<string> views = getAllViews();
            foreach(string v in views)
            {
                //getOneViewSchema(v);
            }
        }

        //protected void getOneTableSchema(string lTableName)
        //{
        //    object[] listViews = null;
        //    using (var conn = GetOpenConnection())
        //    {
        //        listViews = conn.Query<object>("SHOW CREATE TABLE " +  lTableName);
        //    }

        //    var ob = (Array)listViews[0];

        //    File.WriteAllText(string.Format("{0}/schema/", "backupPath", lTableName, ScriptExtension, ob["Create Table"]);
        //}

        //protected void getOneViewSchema(string lViewName)
        //{
        //    $ss = DB::select("SHOW CREATE VIEW " .  $lViewName);
        //    $ob = (array)$ss[0];
        //    $this->log[] = "Get Schema View - " . $lViewName;

        //    $temp1 = explode(" VIEW ", $ob["Create View"]);
        //    $temp2 = "CREATE VIEW " . $temp1[1];

        //    $result = file_put_contents($this->backupPath . "/schema/" . $lViewName .  $this->ScriptExtension, $temp2);

        //}

        //protected function runSQLSchemaScript($fileName)
        //{
        //    $temp1 = explode("/", $fileName);
        //    $objectName = $temp1[count($temp1)-1];
        //    $objectName = str_replace($this->ScriptExtension , "", $objectName);

        //    DB::Statement("DROP TABLE IF EXISTS ". $objectName);
        //    DB::Statement("DROP VIEW IF EXISTS ". $objectName);

        //    $contents = File::get($fileName);	
        //    DB::Statement($contents);
        //    $this->log('Schema Load - ' . $fileName);

        //}
        /*---------------------------------------------------------------------------------------------*/
        //    public function godaddy_backup()
        //    {
        //        $backup = $this->backupPath .   $this->backupName . $this->ScriptExtension; //$this->backupPath.'/'.$this->database.'_backup_'.date('Y').'_'.date('m').'_'.date('d').'.sql';
        //        $cmd = "mysqldump --opt -h $this->dbHost -p" . "$this->dbPassword -u" . "$this->dbUsername $this->database > $backup";
        //        try {
        //            system($cmd);
        //            return 'Backup Successfuly Complete ' . $this->backupName;
        //        } catch(PDOException $error) {
        //            return $error->getMessage();
        //        } 
        //        echo "ED";
        //    }

        //    public function godaddy_restore($backup="") 
        //    {

        //        //$backup = $this->backupPath . $backup;
        //        $mysqlImportFilename = 'file-to-restore.sql';
        //        if (file_exists($mysqlImportFilename))
        //        {
        //            echo "TES";
        //        }
        //        $cmd = "mysql -h" . "$this->dbHost -p" . "$this->dbPassword -u" . "$this->dbUsername $this->database < $mysqlImportFilename";
        //        $cmd = "mysqlimport -u $this->dbUsername -p $this->dbPassword $this->database $mysqlImportFilename";

        //        echo '<br>';
        //        echo $cmd;
        //        try {
        //            exec($cmd);
        //            return 'Restore successfuly complete';
        //        } catch(PDOException $error) {
        //            return $error->getMessage();
        //        } 
        //        echo __DIR__;
        //    }

    }
}





///*---------------------------------------------------------------------------------------------*/

//    protected function restoreAllTables()
//    {
//        $tables = $this->getAllTable();
//        foreach($tables as $t)
//        {
//            $this->restoreOneTable($t);
//        }
//    }

//    protected function restoreOneTable($lTableName)
//    {
//        //? $outFile
		
//        $outFile = $this->backupPath . 'data/' .  $lTableName . $this->DataExtension;
		
//        /*
//        $this->log[] = "Restore Data - " . $lTableName . " - " . $outFile;
//        $results = DB::Statement("LOAD DATA INFILE '" . $outFile . "' INTO TABLE " . $lTableName . "
//                FIELDS TERMINATED BY ',' ENCLOSED BY '~'
//                LINES TERMINATED BY '\\\\n'");
		
//        DD();
//        */

//        //$pdo = DB::connection()->pdo;

//        $pdo = DB::connection();
//        $format = "LOAD DATA INFILE '%s' INTO TABLE %s FIELDS TERMINATED BY ',' ENCLOSED BY '~' LINES TERMINATED BY '\\n'";
//        $query = sprintf($format, $outFile, $lTableName);
////		DD($query);
//        $imported = DB::connection()->getpdo()->exec($query);
//        $this->log($outFile);

//    }





//    protected function runSQLDataScript($fileName)
//    {


//    }

//    public function getDataSchemaBackup()
//    {
		
//        $this->prepairForBackup();
//        $this->getAllSchemas();
//        $this->backupAllTables();
//        return $this->log;
//    }



//    public function RestoreDataSchema()
//    {
//        $fNames = $this->getSchemaFileNames();
//        foreach($fNames as $f)
//        {
//            $this->runSQLSchemaScript($f);
//        }


//        //$fNames = $this->getDataFileNames();
//        $fNames = $this->getAllTable();

//        //DD($fNames);
		
//        foreach($fNames as $f)
//        {
//            echo $f;
//            $this->restoreOneTable($f);
//        }

//        //$this->backupAllTables();
//        DD($this->log);
//    }




//    protected function log($msg)
//    {
//        //echo $msg . "<br>";
//        $this->log[] = $msg;
//    }










////http://help.1and1.com/hosting-c37630/linux-c85098/php-c37728/importing-and-exporting-mysql-databases-using-php-a595887.html
//// PHP Export Script for Managed Servers

//    public function DBExportManagedServer()
//    {
//                //ENTER THE RELEVANT INFO BELOW
//        $mysqlDatabaseName =$this->database;
//        $mysqlUserName =$this->dbUsername;
//        $mysqlPassword =$this->dbPassword;
//        $mysqlExportPath ='chooseFilenameForBackup.sql';

//        //DO NOT EDIT BELOW THIS LINE
//        $mysqlHostName = $this->dbHost;
//        //Export the database and output the status to the page
//        $command='mysqldump -u' .$mysqlUserName .' -S /kunden/tmp/mysql5.sock -p' .$mysqlPassword .' ' .$mysqlDatabaseName .' > ~/' .$mysqlExportPath;
//        $output = array();
//        exec($command,$output,$worked);
//        switch($worked){
//            case 0:
//                echo 'Database <b>' .$mysqlDatabaseName .'</b> successfully exported to <b>~/' .$mysqlExportPath .'</b>';
//                break;
//            case 1:
//                echo 'There was a warning during the export of <b>' .$mysqlDatabaseName .'</b> to <b>~/' .$mysqlExportPath .'</b>';
//                break;
//            case 2:
//                echo 'There was an error during export. Please check your values:<br/><br/><table><tr><td>MySQL Database Name:</td><td><b>' .$mysqlDatabaseName .'</b></td></tr><tr><td>MySQL User Name:</td><td><b>' .$mysqlUserName .'</b></td></tr><tr><td>MySQL Password:</td><td><b>NOTSHOWN</b></td></tr><tr><td>MySQL Host Name:</td><td><b>' .$mysqlHostName .'</b></td></tr></table>';
//                break;
//        }
//    }



//    //http://help.1and1.com/hosting-c37630/linux-c85098/php-c37728/importing-and-exporting-mysql-databases-using-php-a595887.html
//    //PHP Export Script for Linux Hosting
//    public function DBExportLinux()
//    {
//        /*
//        $worked = 0;
//        //DO NOT EDIT BELOW THIS LINE
//        //Export the database and output the status to the page
//        $command='mysqldump --opt -h' .  $this->dbHost  .' -u' . $this->dbUsername .' -p' . $this->dbPassword .' ' . $this->database .' > ~/' . $this->backupPath . ".txt" ;
//        echo exec($command);
//        switch($worked){
//        case 0:
//        echo 'Database <b>' .$this->database .'</b> successfully exported to <b>~/' .$this->backupName .'</b>';
//        break;
//        case 1:
//        echo 'There was a warning during the export of <b>' .$this->database .'</b> to <b>~/' .$this->backupPath .'</b>';
//        break;
//        case 2:
//        echo 'There was an error during export. Please check your values:<br/><br/><table><tr><td>MySQL Database Name:</td><td><b>' .$this->database .'</b></td></tr><tr><td>MySQL User Name:</td><td><b>' .$this->dbUsername .'</b></td></tr><tr><td>MySQL Password:</td><td><b>NOTSHOWN</b></td></tr><tr><td>MySQL Host Name:</td><td><b>' .$this->dbHost .'</b></td></tr></table>';
//        break;
//        }*/


//                //ENTER THE RELEVANT INFO BELOW
//        $mysqlDatabaseName = $this->database;
//        $mysqlUserName = $this->dbUsername;
//        $mysqlPassword = $this->dbPassword;
//        $mysqlHostName = $this->dbHost;
//        $mysqlExportPath = $this->backupPath . $this->backupName . ".sql";

//        //DO NOT EDIT BELOW THIS LINE
//        //Export the database and output the status to the page
//        $command='mysqldump --opt -h' .$mysqlHostName .' -u' .$mysqlUserName .' -p' .$mysqlPassword .' ' .$mysqlDatabaseName .' > ~/' .$mysqlExportPath;
//        $output=array();
//        exec($command,$output,$worked);
//        switch($worked){
//        case 0:
//        echo 'Database <b>' .$mysqlDatabaseName .'</b> successfully exported to <b>~/' .$mysqlExportPath .'</b>';
//        break;
//        case 1:
//        echo 'There was a warning during the export of <b>' .$mysqlDatabaseName .'</b> to <b>~/' .$mysqlExportPath .'</b>';
//        break;
//        case 2:
//        echo 'There was an error during export. Please check your values:<br/><br/><table><tr><td>MySQL Database Name:</td><td><b>' .$mysqlDatabaseName .'</b></td></tr><tr><td>MySQL User Name:</td><td><b>' .$mysqlUserName .'</b></td></tr><tr><td>MySQL Password:</td><td><b>NOTSHOWN</b></td></tr><tr><td>MySQL Host Name:</td><td><b>' .$mysqlHostName .'</b></td></tr></table>';
//        break;
//        }

//    }
//}