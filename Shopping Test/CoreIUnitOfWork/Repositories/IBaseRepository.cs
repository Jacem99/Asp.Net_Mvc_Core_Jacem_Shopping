
namespace Shopping_Test.CoreIUnitOfWork
{
    public interface IBaseRepository<T> where T : class
    {
        //Task<T> FindById(int Id);
        Task<T> FindByCriteria(Expression<Func<T, bool>> criteria = null);
        Task<T> FindByCriteriaInclude(Expression<Func<T, bool>> criteria = null, string[] includes = null);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> criteria);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> order =null, string DefualtOrder=null);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, object>> order = null, string DefualtOrder = null);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> criteria, string[] includes = null, Expression<Func<T, object>> order = null, string DefualtOrder = null);
        Task<IEnumerable<T>> GetAll(string[] includes = null, Expression<Func<T, object>> order = null, string DefualtOrder = null);

        Task<T> Add(T model);
        Task<IEnumerable<T>> AddRange(T[] models);

        T Update(T model);
        IEnumerable<T> UpdateRange(T[] models);

        void Remove(T entity);
        Task<int> Remove(string id);
        Task<int> Remove(Expression<Func<T, bool>> criterai = null);
        Task<int> RemoveRange(Expression<Func<T, bool>> criterai = null);

        Task<bool> CheckAny();
        Task<bool> CheckAny(Expression<Func<T, bool>> criteria = null);
        Task<bool> CheckFound(Expression<Func<T, bool>> criteria = null);

        Task<int> Count(Expression<Func<T, bool>> criterai = null);

    }
}
