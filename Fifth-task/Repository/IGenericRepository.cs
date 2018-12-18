using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TaxiDriverServiceWPF.Repository
{
    /// <summary>
    /// Interface of the repository
    /// </summary>
    /// <typeparam name="TEntity">Object to be entity</typeparam>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets collection of entities
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order of the records</param>
        /// <param name="includeProperties">Properties</param>
        /// <returns>Collection of <see cref="TEntity"/></returns>
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
                                 IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        /// <summary>
        /// Gets entity by its id
        /// </summary>
        /// <param name="id">Id of the entity</param>
        /// <returns><see cref="TEntity"/></returns>
        TEntity GetByID(object id);

        /// <summary>
        /// Inserts entity into Db
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Deletes entity by its id
        /// </summary>
        /// <param name="id">Entity's id</param>
        void Delete(object id);

        /// <summary>
        /// Deletes entity
        /// </summary>
        /// <param name="entityToDelete">Entity to delete</param>
        void Delete(TEntity entityToDelete);

        /// <summary>
        /// Updates existing entity
        /// </summary>
        /// <param name="entityToUpdate">Entity to update</param>
        void Update(TEntity entityToUpdate);
    }
}
