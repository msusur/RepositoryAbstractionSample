using RepositoryLibrary.DbProviders.MongoDb;

namespace RepositoryLibrary.DbProviders.Helpers
{
    internal class ConnectionInformation : IConnectionInformation
    {
        public string ConnectionString { get; private set; }

        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }

        public ConnectionInformation(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}