using BuDing.Infrastructure.ValidationLogic;
using System;
<<<<<<< HEAD
using System.Collections.Generic; 
=======
using System.Collections.Generic;

>>>>>>> c7747ad702ae94245d36a983112b60290acbbf20
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BuDing.Infrastructure.ValidationLogic;

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

		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);

		Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, bool @readonly = false); 

		ValidationResult Add(TEntity entity);
		 
		Task<ValidationResult> AddAsync(TEntity entity);

		ValidationResult Update(TEntity entity);
		Task<ValidationResult> UpdateAsync(TEntity entity);
		ValidationResult Delete(TEntity entity);
		Task<ValidationResult> DeleteAsync(TEntity entity);

		ValidationResult Delete(TPrimaryKey id);

		Task<ValidationResult> DeleteAsync(TPrimaryKey id);
	}
}
