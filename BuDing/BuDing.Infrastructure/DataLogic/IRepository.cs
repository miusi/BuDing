using BuDing.Infrastructure.PageList;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BuDing.Infrastructure.DataLogic
{
    public interface IRepository<TEntity>:IRepository<TEntity,int> where TEntity:class,IEntity,IAggregateRoot
    {
    }

    public interface IRepository<TEntity, TPrimaryKey>  where TEntity : class, IEntity<TPrimaryKey>,IAggregateRoot<TPrimaryKey>
    {
        void ChangeTable(string table);

        #region Select 

        IQueryable<TEntity> GetAll();

        TEntity GetEntityById(TPrimaryKey id);

        Task<TEntity> GetEntityByIdAsync(TPrimaryKey id);

        IList<TEntity> GetAllList();

        Task<IList<TEntity>> GetAllListAsync();

        IEnumerable<TEntity> GetEnumerable(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        Task<IEnumerable<TEntity>> GetEnumerableAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        T Query<T>(Func<IQueryable<TEntity>, T> queryMethod);

        TEntity FirstOrDefault(TPrimaryKey id);

        TEntity FisrtOrDefault(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> FisrtOrDefaultAsync(Expression<Func<TEntity, bool>> filter);


        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);

		//IPagedList<TEntity> GetPagedList(Expression<Func<TEntity, bool>> filter = null,
		//							 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
		//							 Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
		//							 int pageIndex = 0,
		//							 int pageSize = 20,
		//							 bool disableTracking = true);

		//Task<IPagedList<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>> filter = null,
		//										 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
		//										 Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
		//										 int pageIndex = 0,
		//										 int pageSize = 20,
		//										 bool disableTracking = true,
		//										 CancellationToken cancellationToken = default(CancellationToken));


		//IPagedList<TResult> GetPagedList<TResult>(Expression<Func<TEntity, TResult>> selector,
		//										Expression<Func<TEntity, bool>> filter = null,
		//										Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
		//										Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
		//										int pageIndex = 0,
		//										int pageSize = 20,
		//										bool disableTracking = true) where TResult : class;

		//Task<IPagedList<TResult>> GetPagedListAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
		//												 Expression<Func<TEntity, bool>> filter = null,
		//												 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
		//												 Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
		//												 int pageIndex = 0,
		//												 int pageSize = 20,
		//												 bool disableTracking = true,
		//												 CancellationToken cancellationToken = default(CancellationToken)) where TResult : class;

		#endregion

		#region Insert

		TEntity Insert(TEntity entity);

        Task<TEntity> InertAsync(TEntity entity);

        TPrimaryKey InsertAndGetId(TEntity entity);

        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);

        #endregion

        #region Update

        TEntity Update(TEntity entityToUpdate);

        Task<TEntity> UpdateAsync(TEntity entityToUpdate);

        #endregion

        #region Delete

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Deletes an entity by primary key.
        /// </summary>
        /// <param name="id">Primary key of the entity</param>
        void Delete(TPrimaryKey id);

        /// <summary>
        /// Deletes an entity by primary key.
        /// </summary>
        /// <param name="id">Primary key of the entity</param>
        Task DeleteAsync(TPrimaryKey id);

        /// <summary>
        /// Deletes many entities by function.
        /// Notice that: All entities fits to given filter are retrieved and deleted.
        /// This may cause major performance problems if there are too many entities with
        /// given filter.
        /// </summary>
        /// <param name="filter">A condition to filter entities</param>
        void Delete(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Deletes many entities by function.
        /// Notice that: All entities fits to given filter are retrieved and deleted.
        /// This may cause major performance problems if there are too many entities with
        /// given filter.
        /// </summary>
        /// <param name="filter">A condition to filter entities</param>
        Task DeleteAsync(Expression<Func<TEntity, bool>> filter);

        #endregion
         
        #region Aggregates

        int Count();

        Task<int> CountAsync();

        int Count(Expression<Func<TEntity, bool>> filter);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter);

        long LongCount();

        Task<long> LongCountAsync();

        long LongCount(Expression<Func<TEntity, bool>> filter);

        Task<long> LongCountAsync(Expression<Func<TEntity, bool>> filter);
        #endregion


    }
}
