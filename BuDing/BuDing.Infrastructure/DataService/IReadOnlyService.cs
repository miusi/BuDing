using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BuDing.Infrastructure.PageList;

namespace BuDing.Infrastructure.DataService
{

	public interface IReadOnlyService<TEntity> : IReadOnlyService<TEntity, int> where TEntity : class
	{

	}
	public interface IReadOnlyService<TEntity, TPrimaryKey> where TEntity : class
	{
		TEntity Get(TPrimaryKey id, bool @readonly = false);

		Task<TEntity> GetAsync(TPrimaryKey id, bool @readonly = false);

		IList<TEntity> All(bool @readonly = false);

		Task<IList<TEntity>> AllAsync(bool @readonly = false);

		IList<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);

		Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);

		IPagedList<TEntity> GetPagedList(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, bool @readonly = false);

		Task<IPagedList<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, bool @readonly = false);

	}
}
