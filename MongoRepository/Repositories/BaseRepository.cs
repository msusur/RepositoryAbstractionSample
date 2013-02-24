using System;
using RepositoryLibrary.DbProviders;
using RepositoryLibrary.DbProviders.MongoDb;

namespace RepositoryLibrary.Repositories
{
    public class BaseRepository<TProviderType>
        where TProviderType : DbProviderBase
    {
        private readonly TProviderType _provider;

        public BaseRepository(string connectionString)
        {
            _provider = (TProviderType) Activator.CreateInstance(typeof(TProviderType), connectionString);
        }

        protected TProviderType Provider
        {
            get { return _provider; }
        }

    }
}