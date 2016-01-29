using System;
using System.Collections.Generic;


namespace Platform.Core.Utilities
{
    using System.Configuration;
    using System.Linq;

    public interface ICoreConfigMan
    {
        //string App_Path_Root { get; }
        string DbPrefix { get; }
        string ConnectionString { get; }
        string[] DbMigrationFolders { get;  }
        string DbMigrationBase { get; }
    }

    public enum configSection
    {
        ConnectionConfig,
        AppConfig,
        Platform,
        DbConfig,
        Custom,
        UserSetting
    }

    public static class ConnectConfig
    {
        public static string MySqlDB
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString;
            }
        }
    }

    abstract public class CoreConfigMan : ICoreConfigMan
    {
        public string[] DbMigrationFolders
        {
            get { return GetPipedStringConfig(configSection.AppConfig, "DbMigrationFolders"); }
        }

        public string ConnectionString
        {
            get { return GetStringConfig(configSection.ConnectionConfig, "ConnectionString"); }
        }

        public string DbPrefix
        {
            get { return GetStringConfig(configSection.AppConfig, "DB_Object_Prefix"); }
        }

        public string DbMigrationBase
        {
            get { return GetStringConfig(configSection.AppConfig, "DB_Migration_Base"); }
        }

        #region "Core_Functions"
        protected virtual List<Config> GetConfigsFromCache()
        {
            return new List<Config>();
        }
        
        protected string GetStringConfig(configSection section, string configKey)
        {
            try
            {
                if (section == configSection.AppConfig)
                {
                    return ConfigurationManager.AppSettings[configKey].ToString();
                }
                else if (section == configSection.ConnectionConfig)
                {
                    return ConfigurationManager.ConnectionStrings[configKey].ConnectionString;
                }
                else
                {
                    List<Config> configs = GetConfigsFromCache();

                    Config config = new Config();
                    config = configs.Where(c => c.ConfigKey == section.ToString() && c.ConfigKey == configKey).SingleOrDefault();
                    return String.IsNullOrEmpty(config.ConfigValue) ? string.Empty : config.ConfigValue;
                }
            }
            catch (Exception ex)
            {
                //ex.Message()
                return string.Empty;
            }
        }

        protected string[] GetPipedStringConfig(configSection section, string configKey)
        {
            return GetStringConfig(section, configKey).Split('|');
        }

        protected bool GetBoolConfig(configSection section, string configKey)
        {
            bool config = false;

            string value = GetStringConfig(section, configKey);
            bool.TryParse(value, out config);

            return config;
        }

        protected int GetIntConfig(configSection section, string configKey)
        {
            int config = -1;

            string value = GetStringConfig(section, configKey);
            int.TryParse(value, out config);

            return config;
        }
        #endregion Core_Functions
    }

    public class Config
    {
        public string Section { get; set; }

        public string ConfigKey { get; set; }

        public string ConfigValue { get; set; }

        public string Descript { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}

//Parent object should be listed with only namespace number of child objects}