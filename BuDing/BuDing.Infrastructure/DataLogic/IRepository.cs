using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BuDing.Infrastructure.DataLogic
{
	public interface IRepository
	{
	}

	public interface IRepository<TEntity> : IRepository where TEntity:class
	{
		IEnumerable<TEntity> GetEnumerableCollection(
		 Expression<Func<TEntity, bool>> filter = null,
		 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
		 string includeProperties = ""); 

		IQueryable<TEntity> GetQueryableCollection(
	   Expression<Func<TEntity, bool>> filter = null,
	   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
	   string includeProperties = "");

		IList<TEntity> GetListCollection(
		 Expression<Func<TEntity, bool>> filter = null,
		 string includeProperties = "");

		IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters);

		TEntity GetEntityById(object id); 

		void Insert(TEntity entity);

		void Delete(object id);

		void Delete(TEntity entityToDelete);

		void Update(TEntity entityToUpdate);

		int UpdateFields(string query, params object[] parameters);
	}
}
