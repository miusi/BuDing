
using System;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Collections.Generic;
using BuDing.Application.Repositories.Standard;
using BuDing.Infrastructure;

namespace BuDing.Application.Services.Standard
{
    using BuDing.Infrastructure.DataLogic;
    using BuDing.Infrastructure.BusinessLogic;

    public abstract class BaseBusinessLogic<TEntity> : IBusinessLogic<TEntity> where TEntity : class, IAggregateRoot
    {
		#region Public Members

		public string ErrorMessage { get; set; }
		public string InfoMessage { get; set; }
		public bool HasErrors { get; set; }

        #endregion Public Members


        #region Private Members

        private readonly IUnitOfWork _unitOfWork;

        private readonly IRepository<TEntity> _repository;

		#endregion Private Members


		#region Protected Members

		//protected IValidationDictionary ValidationDictionary { get; set; }

		#endregion Protected Members


		#region Public Interface

        protected BaseBusinessLogic(IUnitOfWork unitOfWork,IRepository<TEntity> repository)
		{
			_repository = repository;
		    _unitOfWork = unitOfWork;
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
