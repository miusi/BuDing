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

namespace BuDing.Application.Services.Stardand
{
    public abstract class DataService<TEntity> : IDataService<TEntity> where TEntity : class, IAggregateRoot
    {


        private readonly IUnitOfWork _unitOfWork;

        private readonly IRepository<TEntity> _repository;

        protected DataService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<TEntity>();
        }


        public IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetEntityById(int id)
        {
            return _repository.GetEntityById(id);
        }

        public Task<TEntity> GetEntityByIdAsync(int id)
        {
            return _repository.GetEntityByIdAsync(id);
        }

        public List<TEntity> GetAllList()
        {
            return _repository.GetAllList();
        }

        public Task<List<TEntity>> GetAllListAsync()
        {
            return _repository.GetAllListAsync();
        }

        public IList<TEntity> GetListCollection(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return _repository.GetListCollection(filter, orderBy, includeProperties);
        }

        public Task<IList<TEntity>> GetListCollectionAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return _repository.GetListCollectionAsync(filter, orderBy, includeProperties);
        }

        public T Query<T>(Func<IQueryable<TEntity>, T> queryMethod)
        {
            return _repository.Query(queryMethod);
        }

        public TEntity FirstOrDefault(int id)
        {
            return _repository.FirstOrDefault(id);
        }

        public TEntity FisrtOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.FisrtOrDefault(filter);
        }

        public Task<TEntity> FisrtOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.FisrtOrDefaultAsync(filter);
        }

        public Task<TEntity> FirstOrDefaultAsync(int id)
        {
            return _repository.FirstOrDefaultAsync(id);
        }

        public IList<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            return _unitOfWork.GetWithRawSql<TEntity>(query, parameters);
        }

        public Task<IList<TEntity>> GetWithRawSqlAsync(string query, params object[] parameters)
        {
            return _unitOfWork.GetWithRawSqlAsync<TEntity>(query, parameters);
        }

        public TEntity Insert(TEntity entity)
        {
            var ent = _repository.Insert(entity);
            _unitOfWork.SaveChanges();
            return ent;
        }

        public Task<TEntity> InertAsync(TEntity entity)
        {
            var ent = _repository.InertAsync(entity);
            _unitOfWork.SaveChanges();
            return ent;
        }

        public int InsertAndGetId(TEntity entity)
        {
            var result = _repository.InsertAndGetId(entity);
            _unitOfWork.SaveChanges();
            return result;
        }

        public Task<int> InsertAndGetIdAsync(TEntity entity)
        {
            var result = _repository.InsertAndGetIdAsync(entity);
            _unitOfWork.SaveChangesAsync();
            return result;
        }

        public TEntity Update(TEntity entityToUpdate)
        {
            var entity = _repository.Update(entityToUpdate);
            _unitOfWork.SaveChanges();
            return entity;
        }

        public Task<TEntity> UpdateAsync(TEntity entityToUpdate)
        {
            var entity = _repository.UpdateAsync(entityToUpdate);
            _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public int UpdateFields(string query, params object[] parameters)
        {
            var result = _unitOfWork.ExecuteSqlCommand(query, parameters);
            result= _unitOfWork.SaveChanges();
            return result;
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
            _unitOfWork.SaveChanges();
        }

        public Task DeleteAsync(TEntity entity)
        {
            var result = _repository.DeleteAsync(entity);
            result = _unitOfWork.SaveChangesAsync();
            return result;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public Task DeleteAsync(int id)
        {
            var result= _repository.DeleteAsync(id);
            result = _unitOfWork.SaveChangesAsync();
            return result;
        }

        public void Delete(Expression<Func<TEntity, bool>> filter)
        {
            _repository.Delete(filter);
            _unitOfWork.SaveChanges();
        }

        public Task DeleteAsync(Expression<Func<TEntity, bool>> filter)
        {
            var result = _repository.DeleteAsync(filter);
            result= _unitOfWork.SaveChangesAsync();
            return result;
        }
    }
}
