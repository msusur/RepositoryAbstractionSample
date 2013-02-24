using System;
using System.Linq;
using Contracts;
using Contracts.Models;
using RepositoryLibrary.Configuration;
using RepositoryLibrary.DbProviders.MongoDb;

namespace RepositoryLibrary.Repositories
{
    public class ConcreteDataRepository : BaseRepository<MongoDbProvider>, IDataRepository
    {
        public ConcreteDataRepository()
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