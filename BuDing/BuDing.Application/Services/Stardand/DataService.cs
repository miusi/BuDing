using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BuDing.Application.Context;
using BuDing.Application.Repositories.Standard;
using BuDing.Infrastructure;
using BuDing.Infrastructure.DataLogic;
using BuDing.Infrastructure.DataService;
using BuDing.Infrastructure.PageList;
using BuDing.Infrastructure.ValidationLogic;
using BuDing.Infrastructure.ValidationLogic.Interfaces;

namespace BuDing.Application.Services.Stardand
{
    public abstract class DataService<TEntity> : IService<TEntity> where TEntity : class, IAggregateRoot
    {


        private readonly IUnitOfWork _unitOfWork;

        protected readonly IRepository<TEntity> _repository;

        private ValidationResult _validationResult;

        protected DataService(IUnitOfWork unitOfWork)
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

        public virtual Task<TEntity> GetAsync(int id, bool @readonly = false)
        {
            return _repository.GetEntityByIdAsync(id);
        }

        public virtual IList<TEntity> All(bool @readonly = false)
        {
            return _repository.GetAllList();
        }

        public virtual Task<IList<TEntity>> AllAsync(bool @readonly = false)
        {
            return _repository.GetAllListAsync();
        }

        public virtual IList<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return _repository.GetEnumerable(predicate).ToList();
        }

        public virtual Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return Task.FromResult(Find(predicate, @readonly));
        }

        public virtual IPagedList<TEntity> GetPagedList(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, bool @readonly = false)
        {
            return _repository.GetEnumerable(predicate).ToPagedList<TEntity>(pageIndex, pageSize);
        }

        public virtual Task<IPagedList<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, bool @readonly = false)
        {
            return Task.FromResult(GetPagedList(predicate, pageIndex, pageSize));
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

        public Task<ValidationResult> AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
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

        public virtual Task<ValidationResult> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Delete(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            _repository.Delete(entity);
            return _validationResult;
        }

        public Task<ValidationResult> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
