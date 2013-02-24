using System;
using System.Linq;
using Contracts;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace RepositoryLibrary.DbProviders.MongoDb
{
    public class MongoDbProvider : DbProviderBase
    {
        private readonly MongoServer _server;
        private readonly MongoDatabase _database;
        

        public MongoDbProvider(string connectionString)
            : base(connectionString)
        {
            var client = new MongoClient(ConnectionInfo.ServerName);
            _server = client.GetServer();
            _database = _server.GetDatabase(ConnectionInfo.DatabaseName);
        }

        public override IQueryable<TModel> Query<TModel>()
        {
            return _database.GetCollection(typeof(TModel).Name).AsQueryable<TModel>();
        }

        public override TModel Insert<TModel>(TModel model)
        {
            _database.GetCollection(typeof(TModel).Name).Save(model);
            return model;
        }
        
        public override TModel Update<TModel>(TModel model)
        {
            _database.GetCollection(typeof(TModel).Name).Save(model);
            return model;
        }
        
        public override void Delete<TModel>(TModel model)
        {

        }
    }
}