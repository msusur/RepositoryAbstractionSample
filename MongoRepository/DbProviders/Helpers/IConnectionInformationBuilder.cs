using RepositoryLibrary.DbProviders.MongoDb;

namespace RepositoryLibrary.DbProviders.Helpers
{
    internal interface IConnectionInformationBuilder
    {
        IConnectionInformation Build();
    }
}