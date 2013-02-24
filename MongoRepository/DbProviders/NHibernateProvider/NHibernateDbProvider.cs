using System;
using System.Linq;
using Contracts.Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using RepositoryLibrary.DbProviders.MongoDb;

namespace RepositoryLibrary.DbProviders.NHibernateProvider
{
    public class NHibernateDbProvider : DbProviderBase
    {
        private static ISessionFactory _sessionFactory;

        public NHibernateDbProvider(string connectionString)
            : base(connectionString)
        {
            var configuration = new Configuration();
            //configuration.Configure();
         
            configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, connectionString);
            configuration.SetProperty(NHibernate.Cfg.Environment.Dialect,
                                      typeof (NHibernate.Dialect.MsSql2008Dialect).AssemblyQualifiedName);
            configuration.AddAssembly(typeof(DataModel).Assembly);
            _sessionFactory = configuration.BuildSessionFactory();
        }

        public override IQueryable<TModel> Query<TModel>()
        {
            return _sessionFactory.OpenSession().Query<TModel>();
        }

        public override TModel Insert<TModel>(TModel model)
        {
            TransactionalOperation((session, transaction) => session.Save(model));
            return model;
        }

        public override TModel Update<TModel>(TModel model)
        {
            TransactionalOperation((session, transaction) => session.Update(model));
            return model;
        }

        public override void Delete<TModel>(TModel model)
        {
            TransactionalOperation((session, transaction) => session.Delete(model));
        }

        private static void TransactionalOperation(Action<ISession, ITransaction> operation)
        {
            StartSessionOperation((session) =>
                                      {
                                          using (var transaction = session.BeginTransaction())
                                          {
                                              operation(session, transaction);
                                              transaction.Commit();
                                          }
                                      });

        }

        private static void StartSessionOperation(Action<ISession> operation)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                operation(session);
            }
        }
    }
}

