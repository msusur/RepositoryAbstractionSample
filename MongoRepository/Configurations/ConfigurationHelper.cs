using System.Collections.Generic;

namespace RepositoryLibrary.Configurations
{
    public class ConfigurationHelper
    {
        private static readonly Dictionary<string, string> Dictionary = new Dictionary<string, string>
                                                                      {

                                                                      };

        public static string GetKey(string key)
        {
            return Dictionary[key];
        }

        public static void SetKey(string key,string value)
        {
            Dictionary[key] = value;
        }
    }
}
