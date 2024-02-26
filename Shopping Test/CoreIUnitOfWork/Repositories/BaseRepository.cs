

namespace Shopping_Test.CoreIUnitOfWork
{

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _dbContext;
        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<T> FindByCriteria(Expression<Func<T, bool>>? criteria ) =>
            await _dbContext.Set<T>().SingleOrDefaultAsync(criteria);

        public async Task<T> FindByCriteriaInclude(Expression<Func<T, bool>> criteria = null, string[] includes = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (includes is not null)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }
            return await query.SingleOrDefaultAsync(criteria);
        }
        public async Task<bool> CheckAny(Expression<Func<T, bool>> criteria = null) => await _dbContext.Set<T>().AnyAsync(criteria);
        public async Task<bool> CheckAny() => await _dbContext.Set<T>().AnyAsync();

        public async Task<IEnumerable<T>> GetAll() => await _dbContext.Set<T>().ToListAsync();
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> criteria) => await _dbContext.Set<T>().Where(criteria).ToListAsync();
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> criteria, Expression<Func<T, object>>? order, string? DefualtOrder)
        {

            IQueryable<T> query = _dbContext.Set<T>().Where(criteria);

            if (order is not null)
            {
                if (DefualtOrder == OrderBy.Ascending)
                    query = query.OrderBy(order);
                else
                    query = query.OrderByDescending(order);

            }
            return await query.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, object>> order = null, string? DefualtOrder = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (order is not null)
            {
                if (DefualtOrder == OrderBy.Ascending)
                    query = query.OrderBy(order);
                else
                    query = query.OrderByDescending(order);

            }
            return await query.AsNoTracking().ToListAsync();
        }
      
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> criteria, string[] includes = null, Expression<Func<T, object>> order = null, string DefualtOrder = null)
        {
            IQueryable<T> query = _dbContext.Set<T>().Where(criteria);
            if (includes is not null)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }

            if (DefualtOrder == OrderBy.Ascending)
                query = query.OrderBy(order);
            else
                query = query.OrderByDescending(order);

            return await query.AsNoTracking().AsSplitQuery().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAll(string[] includes = null, Expression<Func<T, object>> order = null, string DefualtOrder = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (order is not null)
            {
                if (DefualtOrder == OrderBy.Ascending)
                    query = query.OrderBy(order);
                else
                    query = query.OrderByDescending(order);

            }

            if (includes is not null)
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

            return await query.AsNoTracking().ToListAsync();
        }
      
        public async Task<T> Add(T model)
        {
            await _dbContext.Set<T>().AddAsync(model);
            return model;
        }
        public async Task<IEnumerable<T>> AddRange(T[] models)
        {
            await _dbContext.Set<T>().AddRangeAsync(models);
            return models;
        }
        public T Update(T model)
        {
            _dbContext.Set<T>().Update(model);
            return model;
        }
        public IEnumerable<T> UpdateRange(T[] models)
        {
            _dbContext.Set<T>().UpdateRange(models);
            return models;
        }
        public async Task<int> Remove(Expression<Func<T, bool>> criterai = null)
        {
            T entity = await FindByCriteria(criterai);
            if (entity is null)
                return 0;
            _dbContext.Set<T>().Remove(entity);
            return 1;
        }

        public async Task<int> RemoveRange(Expression<Func<T, bool>> criterai = null)
        {
            IEnumerable<T> entity = await GetAll(criterai);
            if (entity is null)
                return 0;
            _dbContext.Set<T>().RemoveRange(entity);
            return 1;
        }
        public void Remove(T entity)
        {
            if (entity is not null)
                _dbContext.Set<T>().Remove(entity);
        }
        public async Task<int> Remove(string id)
        {
            T entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity is null)
                return 0;
            _dbContext.Set<T>().Remove(entity);
            return 1;
        }
        public async Task<int> Count(Expression<Func<T, bool>> criterai = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (criterai is not null)
            {
                return await query.CountAsync(criterai);
            }
            return await query.CountAsync();
        }
        public async Task<bool> CheckFound(Expression<Func<T, bool>> criteria = null) => await _dbContext.Set<T>().AnyAsync(criteria);
       


    }
}
