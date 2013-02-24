using System.Linq;
using Contracts;
using RepositoryLibrary.DbProviders.Helpers;

namespace RepositoryLibrary.DbProviders.MongoDb
{
    public abstract class DbProviderBase : IDbProvider
    {
        protected IConnectionInformation ConnectionInfo { get; private set; }

        public DbProviderBase(string connectionString)
        {
            ConnectionInfo = ConnectionInformationSelector.Select(connectionString).Build();
        }

        public abstract IQueryable<TModel> Query<TModel>();
        public abstract TModel Insert<TModel>(TModel model);
        public abstract TModel Update<TModel>(TModel model);
        public abstract void Delete<TModel>(TModel model);
    }
}