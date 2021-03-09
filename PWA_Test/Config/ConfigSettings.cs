using System.Configuration;

namespace PWA_Test.Config
{
    public static class ConfigSettings
    {
        public static string LoginToRM
        {
            get { return ConfigurationManager.AppSettings["loginToRM"]; }
        }
    }
}