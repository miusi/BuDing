using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BuDing.Infrustructure.Contract.BusinessLogic
{
	interface IBusinessLogic<TEntity>
	{
		string ErrorMessage { get; }
		string InfoMessage { get; }
		bool HasErrors { get; }

		IEnumerable<TEntity> GetEnumerableCollection(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IEnumerable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null,
			string includeProperties = "");
		IQueryable<TEntity> GetQueryableCollection(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "");
		IList<TEntity> GetListCollection(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");
		TEntity GetEntityById(object id);
		void Insert(TEntity entityToInsert);
		void Delete(object id);
		void Delete(TEntity entityToDelete);
		void Update(TEntity entityToUpdate);
		bool Validate(TEntity entityToValidate);

		//string GetError(string key, Enums.DictionaryReturnType returnType, string displayFormatString);
		//List<string> GetErrors(Enums.DictionaryReturnType returnType, string displayFormatString);
	}
}
