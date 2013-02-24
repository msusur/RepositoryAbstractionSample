using Contracts;
using Contracts.Models;
using RepositoryLibrary.Configuration;
using RepositoryLibrary.Repositories;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationHelper.SetKey("ConnectionString:DataRepo", "host=mongodb://localhost;database=test1;");

            IDataRepository dataDataRepository = new ConcreteDataRepository();

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
