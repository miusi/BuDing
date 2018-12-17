using System;
using System.Collections.Generic; 
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks; 
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

     

        private readonly ValidationResult _validationResult;

        internal readonly IUnitOfWork _unitOfWork;

        internal readonly IRepository<TEntity> _repository;

        protected DataService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<TEntity>();
        }


        public TEntity Get(int id, bool @readonly = false)
        {
            return _repository.GetEntityById(id);
        }

        public Task<TEntity> GetAsync(int id, bool @readonly = false)
        {
            return _repository.GetEntityByIdAsync(id);
        }

        public IList<TEntity> All(bool @readonly = false)
        {
            return _repository.GetListCollection();
        }

        public Task<IList<TEntity>> AllAsync(bool @readonly = false)
        {
            return _repository.GetListCollectionAsync();
        }

        public IList<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return _repository.GetListCollection(predicate);
        }

        public Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return _repository.GetListCollectionAsync(predicate);
        }

        public IPagedList<TEntity> GetPagedList(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, bool @readonly = false)
        {
            return _repository.GetPagedList(predicate, null, null, pageIndex, pageSize);
        }

        public Task<IPagedList<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, bool @readonly = false)
        {
            return _repository.GetPagedListAsync(predicate, null, null, pageIndex, pageSize);
        }

        private ValidationResult ValidationResult
        {
            get { return _validationResult; }
        }
        public ValidationResult Add(TEntity entity)
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
            if (!ValidationResult.IsValid)
                return Task.FromResult(ValidationResult);

            var selfValidationEntity = entity as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return Task.FromResult(selfValidationEntity.ValidationResult);


            _repository.Insert(entity);
            return Task.FromResult(_validationResult);
        }

        public ValidationResult Update(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            var selfValidationEntity = entity as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return selfValidationEntity.ValidationResult;


            _repository.Update(entity);
            return _validationResult;
        }

        public Task<ValidationResult> UpdateAsync(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return Task.FromResult(ValidationResult);

            var selfValidationEntity = entity as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return Task.FromResult(selfValidationEntity.ValidationResult);


            _repository.UpdateAsync(entity);
            return Task.FromResult(_validationResult);
        }

        public  ValidationResult Delete(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            var selfValidationEntity = entity as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return selfValidationEntity.ValidationResult;


            _repository.Delete(entity);
            return _validationResult;
        }

        public Task<ValidationResult> DeleteAsync(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return Task.FromResult(ValidationResult);

            var selfValidationEntity = entity as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return Task.FromResult(selfValidationEntity.ValidationResult);


            _repository.Delete(entity);
            return Task.FromResult(_validationResult);
        }
    }
}
