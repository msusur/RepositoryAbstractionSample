#define USEMONGO
using Contracts;
using Contracts.Models;
using RepositoryLibrary.Configurations;
using RepositoryLibrary.DbProviders.MongoDb;
using RepositoryLibrary.DbProviders.NHibernateProvider;
using RepositoryLibrary.Repositories;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
#if USEMONGO
            ConfigurationHelper.SetKey("ConnectionString:DataRepo", "host=mongodb://localhost;database=test1;");
            IDataRepository dataDataRepository = new DataRepository<MongoDbProvider>();
#else
            ConfigurationHelper.SetKey("ConnectionString:DataRepo", "Data Source=.;Initial Catalog=Test;User Id=sa;Password=Aa123456;");
            IDataRepository dataDataRepository = new DataRepository<NHibernateDbProvider>();
#endif
            var data = dataDataRepository.InsertData(new DataModel
                                                         {
                                                             Owner = new UserModel
                                                             {
                                                                 Name = "Mert",
                                                                 Surname = "Susur"
                                                             },
                                                             DataDescription = "Test"
                                                         });

            data = dataDataRepository.GetDataById(data.Id);
        }
    }
}
