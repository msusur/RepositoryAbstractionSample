using RepositoryLibrary.DbProviders.MongoDb;

namespace RepositoryLibrary.DbProviders.Helpers
{
    internal class SqlInformationBuilder : IConnectionInformationBuilder
    {
        private readonly IConnectionInformation _connectionInformation;

        public SqlInformationBuilder(string connectionString)
        {
            var parser = Parser.Parse(connectionString);
            _connectionInformation = new ConnectionInformation(connectionString)
                                         {
                                             ServerName = parser.Get("Data Source"),
                                             Username = parser.Get("User Id"),
                                             Password = parser.Get("Password"),
                                             DatabaseName = parser.Get("Initial Catalog"),
                                         };
        }

        public IConnectionInformation Build()
        {
            return _connectionInformation;
        }
    }
}