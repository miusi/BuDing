using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BuDing.Infrustructure.DataLogic
{
	interface IRepositoryAsync<TEntity>:IRepository
	{
		Task<IEnumerable<TEntity>> GetEnumerableCollection(
	 Expression<Func<TEntity, bool>> filter = null,
	 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
	 string includeProperties = "");

		Task<IQueryable<TEntity>> GetQueryableCollection(
	   Expression<Func<TEntity, bool>> filter = null,
	   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
	   string includeProperties = "");

		Task<IList<TEntity>> GetListCollection(
		 Expression<Func<TEntity, bool>> filter = null,
		 string includeProperties = "");

		Task<IEnumerable<TEntity>> GetWithRawSql(string query, params object[] parameters);

		Task<TEntity> GetEntityById(object id); 

		Task Insert(TEntity entity);

		Task Delete(object id);

		Task Delete(TEntity entityToDelete);

		Task Update(TEntity entityToUpdate);

		Task<int> UpdateFields(string query, params object[] parameters);
	}
}
