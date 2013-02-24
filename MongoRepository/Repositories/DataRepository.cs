using System;
using System.Linq;
using Contracts;
using Contracts.Models;
using RepositoryLibrary.Configurations;
using RepositoryLibrary.DbProviders;
using RepositoryLibrary.DbProviders.NHibernateProvider;

namespace RepositoryLibrary.Repositories
{
    public class DataRepository<TProvider> : BaseRepository<TProvider>, IDataRepository
        where TProvider : DbProviderBase
    {
        public DataRepository()
            : base(ConfigurationHelper.GetKey("ConnectionString:DataRepo"))
        {
        }

        public DataModel GetDataById(Guid i)
        {
            return Provider.Query<DataModel>().FirstOrDefault(t => t.Id == i);
        }

        public DataModel InsertData(DataModel dataModel)
        {
            return Provider.Insert(dataModel);
        }
    }
}