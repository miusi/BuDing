using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BuDing.Infrastructure.DataService
{
	public interface IDataService<TEntity>:IDataService<TEntity,int>
	{

	}

	public interface IDataService<TEntity,TPrimaryKey>  
	{
	    #region Select 

	    IQueryable<TEntity> GetAll();

	    TEntity GetEntityById(TPrimaryKey id);

	    Task<TEntity> GetEntityByIdAsync(TPrimaryKey id);

	    List<TEntity> GetAllList();

	    Task<List<TEntity>> GetAllListAsync();

	    IList<TEntity> GetListCollection(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

	    Task<IList<TEntity>> GetListCollectionAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

	    T Query<T>(Func<IQueryable<TEntity>, T> queryMethod);

	    TEntity FirstOrDefault(TPrimaryKey id);

	    TEntity FisrtOrDefault(Expression<Func<TEntity, bool>> filter);

	    Task<TEntity> FisrtOrDefaultAsync(Expression<Func<TEntity, bool>> filter);


	    Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);

	    IList<TEntity> GetWithRawSql(string query, params object[] parameters);

	    Task<IList<TEntity>> GetWithRawSqlAsync(string query, params object[] parameters);

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

	    int UpdateFields(string query, params object[] parameters);

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
    }
}
