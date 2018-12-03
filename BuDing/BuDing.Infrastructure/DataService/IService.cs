using BuDing.Infrastructure.PageList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BuDing.Infrastructure.DataService
{
	public interface IService<TEntity>:IService<TEntity,int> where TEntity : class
	{

	}

	public interface IService<TEntity,TPrimaryKey> where TEntity:class
	{
		TEntity Get(TPrimaryKey id, bool @readonly = false);

		Task<TEntity> GetAsync(TPrimaryKey id, bool @readonly = false);

		IList<TEntity> All(bool @readonly = false);

		Task<IList<TEntity>> AllAsync(bool @readonly = false);

		IList<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);

		Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);

		IPagedList<TEntity> GetPagedList(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, bool @readonly = false);

		Task<IPagedList<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, bool @readonly = false);

		ValidationResult Add(TEntity entity);
		 
		Task<ValidationResult> AddAsync(TEntity entity);

		ValidationResult Update(TEntity entity);
		Task<ValidationResult> UpdateAsync(TEntity entity);
		ValidationResult Delete(TEntity entity);
		Task<ValidationResult> DeleteAsync(TEntity entity);
	}
}
