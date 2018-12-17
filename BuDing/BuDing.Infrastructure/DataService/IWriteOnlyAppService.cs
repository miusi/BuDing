using BuDing.Infrastructure.ValidationLogic;

namespace BuDing.Infrastructure.DataService
{
	public interface IWriteOnlyAppService<TEntity> where TEntity:class
	{
	    ValidationResult Create(TEntity entity);

	    ValidationResult Update(TEntity entity);

	    ValidationResult Remove(TEntity entity);
	}
}
