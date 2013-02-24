using RepositoryLibrary.DbProviders.MongoDb;

namespace RepositoryLibrary.DbProviders.Helpers
{
    internal class MongoDbInformationBuilder : IConnectionInformationBuilder
    {
        private readonly IConnectionInformation _connectionInformation;

        public MongoDbInformationBuilder(string connectionString)
        {
            var parser = Parser.Parse(connectionString);
            _connectionInformation = new ConnectionInformation(connectionString)
                                         {
                                             ServerName = parser.Get("host"),
                                             DatabaseName = parser.Get("database")
                                         };
        }

        public IConnectionInformation Build()
        {
            return _connectionInformation;
        }
    }
}