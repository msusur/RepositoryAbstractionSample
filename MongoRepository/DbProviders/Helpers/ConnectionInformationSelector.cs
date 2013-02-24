using System;

namespace RepositoryLibrary.DbProviders.Helpers
{
    internal class ConnectionInformationSelector
    {
        public static IConnectionInformationBuilder Select(string connectionString)
        {
            if (connectionString.Contains("mongodb://"))
            {
                return new MongoDbInformationBuilder(connectionString);
            }
            return new SqlInformationBuilder(connectionString);
        }
    }
}
