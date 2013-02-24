using System.Text.RegularExpressions;

namespace RepositoryLibrary.DbProviders.Helpers
{
    internal class Parser
    {
        private readonly string _connectionString;

        private Parser(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static Parser Parse(string connectionString)
        {
            return new Parser(connectionString);
        }

        public string Get(string tagName)
        {
            var regex = new Regex(string.Format("{0}=[A-Za-z0-9:/]*?;", tagName));
            var match = regex.Match(_connectionString);
            return match.Value.Trim(';').Replace(string.Format("{0}=", tagName), "");
        }
    }
}