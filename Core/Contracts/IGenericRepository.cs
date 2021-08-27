using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Contracts
{
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// Gets all the <see cref="T"/> existing.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>.</returns>
        IEnumerable<T> Get();

        /// <summary>
        /// Gets an instance of <see cref="T"/> according with the given expression parameter.
        /// </summary>
        /// <param name="condition">Contains the filter that will be used for the search in the database.</param>
        /// <param name="includes">Contains all entities related to the <see cref="T"/> that are to be included in the query.</param>
        /// <returns>An instance of <see cref="T"/>.</returns>
        T Find(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Gets an instance of <see cref="T"/> according with the given expression parameter.
        /// </summary>
        /// <param name="condition">Contains the filter that will be used for the search in the database.</param>
        /// <param name="includes">Contains all entities related to the <see cref="T"/> that are to be included in the query.</param>
        /// <returns>An instance of <see cref="Task{T}"/>.</returns>
        Task<T> FindAsync(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Gets a collection of <see cref="T"/> according with the given expression parameter.
        /// </summary>
        /// <param name="condition">Contains the filter that will be used for the search in the database.</param>
        /// <param name="includes">Contains all entities related to the <see cref="T"/> that are to be included in the query.</param>
        /// <returns>An <see cref="List{T}"/>.</returns>
        List<T> FindAll(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Gets all rows of <see cref="T"/> according with the given expression parameter.
        /// </summary>
        /// <param name="includes">Contains all entities related to the <see cref="T"/> that are to be included in the query.</param>
        /// <returns>An <see cref="IEnumerable{T}"/>.</returns>
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Gets all rows of <see cref="T"/> according with the given expression parameter.
        /// </summary>
        /// <param name="includes">Contains all entities related to the <see cref="T"/> that are to be included in the query.</param>
        /// <returns>An <see cref="IEnumerable{T}"/>.</returns>
        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Gets a collection of <see cref="T"/> according with the given expression parameter.
        /// </summary>
        /// <param name="condition">Contains the filter that will be used for the search in the database.</param>
        /// <param name="includes">Contains all entities related to the <see cref="T"/> that are to be included in the query.</param>
        /// <returns>An <see cref="IEnumerable{T}"/>.</returns>
        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Stores a given <see cref="T"/>
        /// </summary>
        /// <param name="entity">An instance of <see cref="T"/></param>
        /// <returns>An implementation of <see cref="IOperationResult{T}"/></returns>
        IOperationResult<T> Create(T entity);

        /// <summary>
        /// Updates a given <see cref="T"/>.
        /// </summary>
        /// <param name="entity">An instance of <see cref="T"/>.</param>
        /// <returns>An implementation of <see cref="IOperationResult{T}"/>.</returns>
        IOperationResult<T> Update(T entity);

        /// <summary>
        /// Removes a given <see cref="T"/>.
        /// </summary>
        /// <param name="entity">An instance of <see cref="T"/>.</param>
        /// <returns>An implementation of <see cref="IOperationResult{T}"/>.</returns>
        IOperationResult<T> Remove(T entity);

        /// <summary>
        /// Checks the existence of any <see cref="T"/> that match the filter parameter.
        /// </summary>
        /// <param name="predicate">Contains the filter that will be used for the search in the database.</param>
        /// <param name="includes">Contains all entities related to the <see cref="T"/> that are to be included in the query.</param>
        /// <returns>A <see cref="bool"/> value representing if <see cref="T"/> exists</returns>
        bool Exists(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Checks the existence of any <see cref="T"/> that match the filter parameter.
        /// </summary>
        /// <param name="condition">Contains the filter that will be used for the search in the database.</param>
        /// <param name="includes">Contains all entities related to the <see cref="T"/> that are to be included in the query.</param>
        /// <returns>A <see cref="bool"/> value representing if <see cref="T"/> exists</returns>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Checks the existence of any <see cref="T"/> that match the filter parameter.
        /// </summary>
        /// <param name="condition">Contains the filter that will be used for the search in the database.</param>
        /// <returns>A <see cref="bool"/> value representing if <see cref="T"/> exists</returns>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> condition);

        /// <summary>
        /// Performs the saving of the changes that have been executed on <see cref="T"/>.
        /// </summary>
        void Save();

        /// <summary>
        /// Performs the saving of the changes that have been executed on <see cref="Task{T}"/>.
        /// </summary>
        Task SaveAsync();
    }
}
