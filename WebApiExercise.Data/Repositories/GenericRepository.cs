using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApiExercise.Core.Contracts;
using WebApiExercise.Core.Models;
using WebApiExercise.Persistence;

namespace WebApiExercise.Core.Repositories
{
    /// <summary>
    /// Implements the basic operations of <see cref="T"/> storage functionality
    /// </summary>
    /// <typeparam name="T">Represents the type that be management for the repository.</typeparam>
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class, new()
    {
        public readonly AppDbContext _context;
        public readonly DbSet<T> _set;

        /// <summary>
        /// Creates an instance of <see cref="BaseRepositoryAsync{T}"/>
        /// </summary>
        /// <param name="context">An instance of <see cref="EmployeesSalesDbContext"/></param>
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        /// <summary>
        /// Gets all the <see cref="T"/> existing.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>.</returns>
        public IEnumerable<T> Get() => _set.AsEnumerable();

        /// <summary>
        /// Gets an instance of <see cref="T"/> according with the given expression parameter.
        /// </summary>
        /// <param name="condition">Contains the filter that will be used for the search in the database.</param>
        /// <param name="includes">Contains all entities related to the <see cref="T"/> that are to be included in the query.</param>
        /// <returns>An instance of <see cref="T"/>.</returns>
        public T Find(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = _set.AsQueryable();

            foreach (Expression<Func<T, object>> include in includes)
            {
                queryable = queryable.Include(include);
            }

            return queryable.FirstOrDefault(condition);
        }

        /// <summary>
        /// Gets an instance of <see cref="T"/> according with the given expression parameter.
        /// </summary>
        /// <param name="predicate">Contains the filter that will be used for the search in the database.</param>
        /// <param name="includes">Contains all entities related to the <see cref="T"/> that are to be included in the query.</param>
        /// <returns>An instance of <see cref="Task{T}"/>.</returns>
        public Task<T> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = _set.AsQueryable();

            foreach (Expression<Func<T, object>> include in includes)
            {
                queryable = queryable.Include(include);
            }

            return queryable.FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Gets a collection of <see cref="T"/> according with the given expression parameter.
        /// </summary>
        /// <param name="condition">Contains the filter that will be used for the search in the database.</param>
        /// <param name="includes">Contains all entities related to the <see cref="T"/> that are to be included in the query.</param>
        /// <returns>An <see cref="List{T}"/>.</returns>
        public List<T> FindAll(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = _set.AsQueryable();

            foreach (Expression<Func<T, object>> include in includes)
            {
                queryable = queryable.Include(include);
            }

            return queryable.Where(condition).ToList();
        }

        /// <summary>
        /// Gets a collection of <see cref="T"/> according with the given expression parameter
        /// </summary>
        /// <param name="includes">Contains all entities related to the <see cref="T"/> that are to be included in the query.</param>
        /// <returns>An implementation of <see cref="IEnumerable{T}"/></returns>
        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = _set.AsQueryable();

            foreach (Expression<Func<T, object>> include in includes)
            {
                queryable = queryable.Include(include);
            }

            return queryable.ToList();
        }

        /// <summary>
        /// Gets a collection of <see cref="T"/> according with the given expression parameter.
        /// </summary>
        /// <param name="condition">Contains the filter that will be used for the search in the database.</param>
        /// <param name="includes">Contains all entities related to the <see cref="T"/> that are to be included in the query.</param>
        /// <returns>An <see cref="Task{List{T}}"/>.</returns>
        public Task<List<T>> FindAllAsync(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = _set.AsQueryable();

            foreach (Expression<Func<T, object>> include in includes)
            {
                queryable = queryable.Include(include);
            }

            return queryable.Where(condition).ToListAsync();
        }

        /// <summary>
        /// Stores a given <see cref="T"/>
        /// </summary>
        /// <param name="entity">An instance of <see cref="T"/></param>
        /// <returns>An implementation of <see cref="IOperationResult{T}"/></returns>
        public IOperationResult<T> Create(T entity)
        {
            _context.Set<T>().Add(entity);

            return BasicOperationResult<T>.Ok(entity);
        }

        /// <summary>
        /// Updates a given <see cref="T"/>.
        /// </summary>
        /// <param name="entity">An instance of <see cref="T"/>.</param>
        /// <returns>An implementation of <see cref="IOperationResult{T}"/>.</returns>
        public IOperationResult<T> Update(T entity)
        {
            DbEntityEntry entityEntry = _context.Entry(entity);
            entityEntry.State = EntityState.Modified;

            return BasicOperationResult<T>.Ok();
        }

        /// <summary>
        /// Removes a given <see cref="T"/>.
        /// </summary>
        /// <param name="entity">An instance of <see cref="T"/>.</param>
        /// <returns>An implementation of <see cref="IOperationResult{T}"/>.</returns>
        public IOperationResult<T> Remove(T entity)
        {
            _context.Set<T>().Remove(entity);

            return BasicOperationResult<T>.Ok();
        }

        /// <summary>
        /// Checks the existence of any <see cref="T"/> that match the filter parameter.
        /// </summary>
        /// <param name="condition">Contains the filter that will be used for the search in the database.</param>
        /// <param name="includes">Contains all entities related to the <see cref="T"/> that are to be included in the query.</param>
        /// <returns>A <see cref="bool"/> value representing if <see cref="T"/> exists</returns>
        public bool Exists(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = _set.AsQueryable();

            foreach (Expression<Func<T, object>> include in includes)
            {
                queryable = queryable.Include(include);
            }

            return queryable.Any(condition);
        }

        /// <summary>
        /// Checks the existence of any <see cref="T"/> that match the filter parameter.
        /// </summary>
        /// <param name="condition">Contains the filter that will be used for the search in the database.</param>
        /// <returns>A <see cref="bool"/> value representing if <see cref="T"/> exists</returns>
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> queryable = _set.AsQueryable();

            return await queryable.AnyAsync(condition);
        }

        /// <summary>
        /// Checks the existence of any <see cref="T"/> that match the filter parameter.
        /// </summary>
        /// <param name="condition">Contains the filter that will be used for the search in the database.</param>
        /// <param name="includes">Contains all entities related to the <see cref="T"/> that are to be included in the query.</param>
        /// <returns>A <see cref="Task{bool}"/> value representing if <see cref="T"/> exists</returns>
        public Task<bool> ExistsAsync(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = _set.AsQueryable();

            foreach (Expression<Func<T, object>> include in includes)
            {
                queryable = queryable.Include(include);
            }

            return queryable.AnyAsync(condition);
        }

        /// <summary>
        /// Performs the saving of the changes that have been executed on <see cref="T"/>.
        /// </summary>
        public void Save() => _context.SaveChanges();

        /// <summary>
        /// Performs the saving of the changes that have been executed on <see cref="Task{T}"/>.
        /// </summary>
        public Task SaveAsync() => _context.SaveChangesAsync();

        /// <summary>
        /// Gets a collection of <see cref="T"/> according with the given expression parameter
        /// </summary>
        /// <param name="includes">Contains all entities related to the <see cref="T"/> that are to be included in the query.</param>
        public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = _set.AsQueryable();

            foreach (Expression<Func<T, object>> include in includes)
            {
                queryable = queryable.Include(include);
            }

            return await queryable.ToListAsync();
        }
    }
}
