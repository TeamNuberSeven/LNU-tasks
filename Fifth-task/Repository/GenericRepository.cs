using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using TaxiDriverServiceWPF.DataTypes;

namespace TaxiDriverServiceWPF.Repository
{
    /// <summary>
    /// Class representing instance of the repository
    /// </summary>
    /// <typeparam name="TEntity">Object to be entity</typeparam>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal DriverContext context;
        internal DbSet<TEntity> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/>
        /// </summary>
        /// <param name="context">DataBase context</param>
        public GenericRepository(DriverContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Gets collection of entities
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order of the records</param>
        /// <param name="includeProperties">Properties</param>
        /// <returns>Collection of <see cref="TEntity"/></returns>
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
                                                IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        /// Gets entity by its id
        /// </summary>
        /// <param name="id">Id of the entity</param>
        /// <returns><see cref="TEntity"/></returns>
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// Inserts entity into Db
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        /// <summary>
        /// Deletes entity by its id
        /// </summary>
        /// <param name="id">Entity's id</param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Deletes entity
        /// </summary>
        /// <param name="entityToDelete">Entity to delete</param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// Updates existing entity
        /// </summary>
        /// <param name="entityToUpdate">Entity to update</param>
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
