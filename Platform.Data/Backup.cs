using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Data
{
    class Backup
    {
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booolean.Data
{
    class Backup
    {
    }
}


//<?php namespace platform\Utility;
////platform\Utility\dbHandler

//use Config;
//use DB;
//use File;

//class dbHandler 
//{

//    protected $backupName;
//    protected $backupFile;
//    protected $backupPath;
//    protected $itemPrefix;
//    protected $database;
//    protected $dbHost;
//    protected $dbUsername;
//    protected $dbPassword;

//    protected $DataExtension;
//    protected $ScriptExtension;
//    protected $log;


//    public function __construct()
//    {
//        $this->backupPath  	= Config::get('app.app_path_backup');
//        $this->itemPrefix	= Config::get('database.connections.mysql.prefix');
//        $this->database 	= Config::get('database.connections.mysql.database');
//        $this->dbHost	 	= Config::get('database.connections.mysql.host');
//        $this->dbUsername	=  Config::get('database.connections.mysql.username');
//        $this->dbPassword	=  Config::get('database.connections.mysql.password');

//        $this->DataExtension = ".csv";
//        $this->ScriptExtension = ".sql";
//        $this->backupName 	= date("Ymd-his-D");

//    }

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

//    public function prepairForBackup()
//    {
//        mkdir($this->backupPath . $this->backupName);
//        $this->backupPath = $this->backupPath . "/" . $this->backupName . "/";
//        mkdir($this->backupPath . 'schema' );
//        mkdir($this->backupPath . 'data' );
//        $this->log('Prepair for backup - ' .  $this->backupName);
//        return $this->backupPath;
//    }

//    public function prepairForRestore($backupName, $database = "")
//    {
//        $this->backupName = $backupName;
//        if ($database<>"")
//        {
//            $this->database   =	$database;
//        }
		
//        $this->backupPath = $this->backupPath . "/" . $this->backupName . "/";
//        // TODO check or the path exists
//        $this->log('Prepair for Restore - ' .  $this->backupName);
//        return $this->backupPath;
//    }

//    public function GetbackupNames()
//    {

//        $names = array();
//        //DD(opendir('C:\wamp\www\v\ulavi\database\backup'));
//        //DD($this->backupPath);

////echo $_SERVER['DOCUMENT_ROOT'];
//        //DD(__DIR__);

//        if ($handle = opendir($this->backupPath))
//        {

//            /* This is the correct way to loop over the directory. */
//            while (false !== ($entry = readdir($handle)))
//            {
//                if ($entry != "." && $entry != "..")
//                {
//                    $names[]  = "$entry";
//                }
//                //echo $entry;
//            }
//            closedir($handle);
//        }
//        return $names;
//    }

///*---------------------------------------------------------------------------------------------*/

//    public function getAllTable()
//    {
//        $return = array();
//        $listTables = DB::select("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' and TABLE_SCHEMA='" . $this->database . "'");
//        //DD($listTables);
//        foreach($listTables as $lV)
//        {
//            $return[] = $lV->TABLE_NAME;
//        }
//        return $return;
//    }

//    public function getAllViews()
//    {
//        $return = array();
//        $listViews = DB::select("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA='" . $this->database . "'");
//        foreach($listViews as $lV)
//        {
//            $return[] = $lV->TABLE_NAME;
//        }
//        return $return;
//    }

///*---------------------------------------------------------------------------------------------*/

//    protected function deleteAllTables()
//    {
//        $tables = $this->getAllTable();
//        foreach($tables as $t)
//        {
//            $this->deleteOneTables($t);
//        }
//    }

//    protected function deleteOneTable($lTableName)
//    {
//        $this->log("Dropping table - " . $lTableName);
//        DB::Statement("DROP TABLE " . $lTableName);
//    }

///*---------------------------------------------------------------------------------------------*/

//    protected function deleteAllViews()
//    {
//        $views = $this->getAllTable();
//        foreach($views as $v)
//        {
//            $this->deleteOneViews($v);
//        }
//    }

//    protected function deleteOneView($lViewName)
//    {
//        $this->log("Dropping view - " . $lViewName);
//        DB::Statement("DROP VIEW " . $lViewName);
//    }

///*---------------------------------------------------------------------------------------------*/

//    public function backupAllTables() 
//    {
//        $tables = $this->getAllTable();
//        foreach($tables as $t)
//        {
//            $this->backupOneTable($t);
//        }
//    }

//    public function backupOneTable($lTableName) 
//    {
//        $outFile = $this->backupPath . 'data/' . $lTableName . $this->DataExtension ;
//        //$outFile = $this->backupPath . 'data/' . $lTableName . $this->ScriptExtension ;
//        if (file_exists($outFile))
//        {
//            unlink($outFile);
//        }
		
//        $this->log("Backup data - " . $lTableName);
//        $sql = "SELECT * INTO OUTFILE '$outFile' FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '~' LINES TERMINATED BY '\n' FROM $lTableName";
  		
//        //DD($sql);
//        $results 	= DB::Statement($sql);
//        //return $results;
//        return $outFile;
//    }

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

///*---------------------------------------------------------------------------------------------*/

//    protected function getDataFileNames()
//    {
//        foreach(glob($this->backupPath . 'data/*' . $this->DataExtension) as $f)
//        {
//            $filename[] = $f;
//        }
//        return $filename;
//    }

//    protected function getSchemaFileNames()
//    {
//        foreach(glob($this->backupPath . 'schema/*' . $this->ScriptExtension) as $f)
//        {
//            $filename[] = $f;
//        }
//        return $filename;
//    }

///*---------------------------------------------------------------------------------------------*/

//    protected function getAllSchemas()
//    {
//        $tables = $this->getAllTable();
//        foreach($tables as $t)
//        {
//            $this->getOneTableSchema($t);
//        }

//        $views = $this->getAllViews();
//        foreach($views as $v)
//        {
//            $this->getOneViewSchema($v);
//        }
//    }

//    protected function getOneTableSchema($lTableName)
//    {
//        $ss = DB::select("SHOW CREATE TABLE " .  $lTableName);
//        $ob = (array)$ss[0];
//        $this->log[] = "Get Schema Table - " . $lTableName;
//        $result = file_put_contents($this->backupPath . "/schema/" . $lTableName .  $this->ScriptExtension, $ob["Create Table"]);
//        return $result; 
//    }

//    protected function getOneViewSchema($lViewName)
//    {
//        $ss = DB::select("SHOW CREATE VIEW " .  $lViewName);
//        $ob = (array)$ss[0];
//        $this->log[] = "Get Schema View - " . $lViewName;

//        $temp1 = explode(" VIEW ", $ob["Create View"]);
//        $temp2 = "CREATE VIEW " . $temp1[1];

//        $result = file_put_contents($this->backupPath . "/schema/" . $lViewName .  $this->ScriptExtension, $temp2);
//        return $result; 
//    }

//    protected function runSQLSchemaScript($fileName)
//    {
//        $temp1 = explode("/", $fileName);
//        $objectName = $temp1[count($temp1)-1];
//        $objectName = str_replace($this->ScriptExtension , "", $objectName);

//        DB::Statement("DROP TABLE IF EXISTS ". $objectName);
//        DB::Statement("DROP VIEW IF EXISTS ". $objectName);

//        $contents = File::get($fileName);	
//        DB::Statement($contents);
//        $this->log('Schema Load - ' . $fileName);

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