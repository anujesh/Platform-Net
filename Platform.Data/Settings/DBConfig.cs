using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Platform.Core.Utilities;

namespace Platform.Data.Settings
{
    public interface IDBConfig : ICoreConfigMan
    {
        string DataPath { get; }
        string BackupBasePath { get; }
        string SchemaPath { get; }
    }

    public class DBConfig : CoreConfigMan, IDBConfig
    {
        public string DataPath
        {
            get { return GetStringConfig(configSection.AppConfig, "DB_Data_Path"); }
        }

        public string BackupBasePath
        {
            get { return GetStringConfig(configSection.AppConfig, "DB_Backup_Path"); }
        }

        public string SchemaPath
        {
            get { return GetStringConfig(configSection.AppConfig, "DB_Schema_Path"); }
        }

    }
}
