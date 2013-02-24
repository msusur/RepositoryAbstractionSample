using System.Collections.Generic;

namespace RepositoryLibrary.Configuration
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

        public static string SetKey(string key,string value)
        {
            Dictionary[key] = value;
        }
    }
}
