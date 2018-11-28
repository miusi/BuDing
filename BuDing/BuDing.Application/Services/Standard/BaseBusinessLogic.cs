
using System;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace BuDing.Application.Services.Standard
{
    using BuDing.Infrastructure.DataLogic;
    using BuDing.Infrastructure.BusinessLogic;

    public abstract class BaseBusinessLogic<TEntity> : IBusinessLogic<TEntity> where TEntity : class
	{
		#region Public Members

		public string ErrorMessage { get; set; }
		public string InfoMessage { get; set; }
		public bool HasErrors { get; set; }

		#endregion Public Members


		#region Private Members

		private IRepository<TEntity> _repository;

		#endregion Private Members


		#region Protected Members

		//protected IValidationDictionary ValidationDictionary { get; set; }

		#endregion Protected Members


		#region Public Interface

		public BaseBusinessLogic(IRepository<TEntity> repository)
		{
			_repository = repository;
		}

		public virtual void BuildErrorMessage(Exception ex)
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine(string.Format("Message: {0}", ex.Message));
			sb.AppendLine(string.Format("Message Source: {0}", ex.Source));
			sb.AppendLine(string.Format("Message TargetSite: {0}", ex.TargetSite));
			if (ex.InnerException != null)
			{
				Exception innerEx = ex.InnerException;

				do
				{
					sb.AppendLine(string.Format("InnerException Message: {0}", innerEx.Message));
					sb.AppendLine(string.Format("InnerException Source:", innerEx.Source));
					sb.AppendLine(string.Format("InnerException TargetSite:", innerEx.TargetSite));
					innerEx = innerEx.InnerException;
				}
				while (innerEx != null); 
			}
			ErrorMessage = sb.ToString();
			InfoMessage = "Error Occured, please check ErrorMessage!";
			HasErrors = true;
		}

		public IEnumerable<TEntity> GetEnumerableCollection(Expression<Func<TEntity, bool>> filter = null, Func<IEnumerable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
		{
			return _repository.GetEnumerableCollection(filter, orderBy, includeProperties);
		}

		public IQueryable<TEntity> GetQueryableCollection(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
		{
			return _repository.GetQueryableCollection(filter, orderBy, includeProperties);
		}

		public IList<TEntity> GetListCollection(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
		{
			return _repository.GetListCollection(filter, includeProperties);
		}

		public TEntity GetEntityById(object id)
		{
			return _repository.GetEntityById(id);
		}

		public void Insert(TEntity entityToInsert)
		{
			this.Initialize();
			if (Validate(entityToInsert))
			{
				_repository.Insert(entityToInsert);
			}
		}

		public void Delete(object id)
		{
			_repository.Delete(id);
		}

		public void Delete(TEntity entityToDelete)
		{

			_repository.Delete(entityToDelete);
		}

		public void Update(TEntity entityToUpdate)
		{
			this.Initialize();
			if (Validate(entityToUpdate))
			{
				_repository.Update(entityToUpdate);
			}
		}

		public virtual bool Validate(TEntity entityToValidate)
		{
			throw new NotImplementedException();
		}

		#endregion Public Interface

		#region private method
		private void Initialize()
		{
			ErrorMessage = string.Empty;
			InfoMessage = string.Empty;
			HasErrors = false;
		}

		#endregion

	}
}
