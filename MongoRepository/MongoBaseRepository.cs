using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace RepositoryLibrary
{
    internal class MongoBaseRepository<TModelType>
    {
        private readonly MongoServer _server;
        private readonly MongoDatabase _database;
        private readonly MongoCollection _mongoCollection;

        public MongoBaseRepository(string server, string database)
        {
            var client = new MongoClient(string.Format("mongodb://{0}", server));
            _server = client.GetServer();
            _database = _server.GetDatabase(database);
            _mongoCollection = _database.GetCollection(typeof(TModelType).Name);
        }

        public IQueryable<TModelType> FindAll()
        {
            return _mongoCollection.AsQueryable<TModelType>();
        }
    }
}
