
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;


namespace BuDing.Application.Services.Stardand
{
	using BuDing.Infrastructure;
	using BuDing.Infrastructure.DataLogic;
	using BuDing.Infrastructure.DataService;
	using BuDing.Infrastructure.ValidationLogic;
	using BuDing.Infrastructure.ValidationLogic.Interfaces;

	public class ServiceBase<TEntity> : IService<TEntity> where TEntity : class, IAggregateRoot
	{
		protected readonly IUnitOfWork _unitOfWork;

		protected readonly IRepository<TEntity> _repository;

		private ValidationResult _validationResult;

		protected ServiceBase(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_repository = _unitOfWork.GetRepository<TEntity>();
			_validationResult = new ValidationResult();
		}

		protected ValidationResult ValidationResult
		{
			get { return _validationResult; }
		}


		public virtual TEntity Get(int id, bool @readonly = false)
		{
			return _repository.GetEntityById(id);
		}

		public virtual IEnumerable<TEntity> All(bool @readonly = false)
		{
			return _repository.GetAllList();
		}


		public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate = null, bool @readonly = false)
		{
			return _repository.GetEnumerable(predicate).ToList();
		}

		public virtual ValidationResult Add(TEntity entity)
		{
			if (!ValidationResult.IsValid)
				return ValidationResult;

			var selfValidationEntity = entity as ISelfValidation;
			if (selfValidationEntity != null && !selfValidationEntity.IsValid)
				return selfValidationEntity.ValidationResult;


			_repository.Insert(entity);
			return _validationResult;
		}


		public virtual ValidationResult Update(TEntity entity)
		{
			if (!ValidationResult.IsValid)
				return ValidationResult;
			var selfValidationEntity = entity as ISelfValidation;
			if (selfValidationEntity != null && !selfValidationEntity.IsValid)
				return selfValidationEntity.ValidationResult;
			_repository.Update(entity);
			return _validationResult;
		}


		public ValidationResult Delete(TEntity entity)
		{
			if (!ValidationResult.IsValid)
				return ValidationResult;

			_repository.Delete(entity);
			return _validationResult;
		}

		public ValidationResult Delete(int id)
		{
			if (!ValidationResult.IsValid)
				return ValidationResult;

			_repository.Delete(id);
			return _validationResult;
		}

	}
}
