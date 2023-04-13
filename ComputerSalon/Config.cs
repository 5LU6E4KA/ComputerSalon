using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSalon
{
    public static class Config
    {
        private static readonly Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public static string Theme
        {
            get => config.AppSettings.Settings["Theme"].Value;
            set => SaveProperty("Theme", value);
        }
        private static void SaveProperty(string name, string value)
        {
            config.AppSettings.Settings[name].Value = value;
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
