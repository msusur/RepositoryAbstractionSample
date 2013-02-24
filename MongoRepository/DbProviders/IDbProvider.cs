using System.Linq;

namespace RepositoryLibrary.DbProviders
{
    public interface IDbProvider
    {
        IQueryable<TModel> Query<TModel>();

        TModel Insert<TModel>(TModel model);
        
        TModel Update<TModel>(TModel model);
        
        void Delete<TModel>(TModel model);
    }
}