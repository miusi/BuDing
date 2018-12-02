
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuDing.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BuDing.Application.Repositories.Standard
{
	using System.Threading;
	using BuDing.Infrastructure.DataLogic;
	using BuDing.Infrastructure.PageList;
	using Microsoft.EntityFrameworkCore.Query;

	public abstract class RepositoryBase<TEntity,TPrimaryKey> : IRepository<TEntity,TPrimaryKey> where TEntity : class,IEntity<TPrimaryKey>,IAggregateRoot<TPrimaryKey>
    {
        public abstract IQueryable<TEntity> GetAll();


        /// <summary>
        /// Changes the table name. This require the tables in the same database.
        /// </summary>
        /// <param name="table"></param>
        /// <remarks>
        /// This only been used for supporting multiple tables in the same model. This require the tables in the same database.
        /// </remarks>
        public abstract void ChangeTable(string table);
         


        public virtual List<TEntity> GetAllList()
        {
            return GetAll().ToList();
        }


        public virtual Task<List<TEntity>> GetAllListAsync()
        {
            return Task.FromResult(GetAllList());
        }

        public virtual TEntity GetEntityById(TPrimaryKey id)
        {
            var entity = FirstOrDefault(id);
            return entity;
        }

	    public virtual async Task<TEntity> GetEntityByIdAsync(TPrimaryKey id)
	    {
	        var entity = await FirstOrDefaultAsync(id);

	        return entity;
	    }



	    public virtual IList<TEntity> GetListCollection(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
	    {
	        IQueryable<TEntity> query = GetAll();

	        if (filter != null)
	        {
	            query = query.Where(filter);
	        }

	        foreach (var includeProperty in includeProperties.Split(new char[]{','}))
	        {
	            query = query.Include(includeProperty);
	        }

	        if (orderBy != null)
	        {
	            query = orderBy(query);
	        }

	        return query.ToList();
	    }

	    public virtual Task<IList<TEntity>> GetListCollectionAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
	    {
	        return Task.FromResult(GetListCollection(filter, orderBy, includeProperties));
	    }

	    public virtual T Query<T>(Func<IQueryable<TEntity>, T> queryMethod)
	    {
	        return queryMethod(GetAll());
	    }

	    public virtual TEntity FirstOrDefault(TPrimaryKey id)
	    {
	        var entity = GetAll().FirstOrDefault(CreateEqualityExpressionForId(id));
	        return entity;
	    }

	    public virtual TEntity FisrtOrDefault(Expression<Func<TEntity, bool>> filter)
	    {
	        return GetAll().FirstOrDefault(filter);
	    }

	    public virtual Task<TEntity> FisrtOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
	    {
	        return Task.FromResult(FisrtOrDefault(filter));
	    }

	    public virtual Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
	    {
	        return Task.FromResult(FirstOrDefault(id));
	    }

     //   public abstract IList<TEntity> GetWithRawSql(string query, params object[] parameters);

	    //public virtual Task<IList<TEntity>> GetWithRawSqlAsync(string query, params object[] parameters)
	    //{
	    //    return Task.FromResult(GetWithRawSql(query, parameters));
	    //}

        public abstract TEntity Insert(TEntity entity);

	    public virtual Task<TEntity> InertAsync(TEntity entity)
	    {
	        return Task.FromResult(Insert(entity));
	    }

	    public virtual TPrimaryKey InsertAndGetId(TEntity entity)
	    {
	        return Insert(entity).ID;
	    }

	    public virtual Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
	    {
	        return Task.FromResult(InsertAndGetId(entity));
	    }

        public abstract TEntity Update(TEntity entityToUpdate);

	    public virtual Task<TEntity> UpdateAsync(TEntity entityToUpdate)
	    {
	        return Task.FromResult(Update(entityToUpdate));
        }

        //public abstract int UpdateFields(string query, params object[] parameters);


        public abstract void Delete(TEntity entity);

	    public virtual Task DeleteAsync(TEntity entity)
	    {
	        Delete(entity);
	        return Task.FromResult(0);
	    }

        public abstract void Delete(TPrimaryKey id);

	    public virtual Task DeleteAsync(TPrimaryKey id)
	    {
            Delete(id);
	        return Task.FromResult(0);
	    }

	    public virtual void Delete(Expression<Func<TEntity, bool>> filter)
	    {
            //批量
	        foreach (var entity in GetAll().Where(filter).ToList())
	        {
	            Delete(entity);
	        }
        }

	    public virtual Task DeleteAsync(Expression<Func<TEntity, bool>> filter)
	    {
	        Delete(filter);
	        return Task.FromResult(0);
        }

	    public virtual int Count()
	    {
	        return GetAll().Count();
	    }

	    public virtual Task<int> CountAsync()
	    {
	        return Task.FromResult(Count());
        }

	    public virtual int Count(Expression<Func<TEntity, bool>> filter)
	    {
	        return GetAll().Where(filter).Count();
        }

	    public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> filter)
	    {
	        return Task.FromResult(Count(filter));
        }

	    public virtual long LongCount()
	    {
	        return GetAll().LongCount();
        }

	    public virtual Task<long> LongCountAsync()
	    {
	        return Task.FromResult(LongCount());
        }

	    public virtual long LongCount(Expression<Func<TEntity, bool>> filter)
	    {
	        return GetAll().Where(filter).LongCount();
        }

	    public virtual Task<long> LongCountAsync(Expression<Func<TEntity, bool>> filter)
	    {
	        return Task.FromResult(LongCount(filter));
        }

		public IPagedList<TEntity> GetPagedList(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = true)
		{
			IQueryable<TEntity> query = GetAll();
			if (disableTracking)
			{
				query = query.AsNoTracking();
			}

			if (include != null)
			{
				query = include(query);
			}

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (orderBy != null)
			{
				return orderBy(query).ToPagedList(pageIndex, pageSize);
			}
			else
			{
				return query.ToPagedList(pageIndex, pageSize);
			}
		}

		public Task<IPagedList<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = true, CancellationToken cancellationToken = default(CancellationToken))
		{
			IQueryable<TEntity> query = GetAll();
			if (disableTracking)
			{
				query = query.AsNoTracking();
			}

			if (include != null)
			{
				query = include(query);
			}

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (orderBy != null)
			{
				return orderBy(query).ToPagedListAsync(pageIndex, pageSize, 0, cancellationToken);
			}
			else
			{
				return query.ToPagedListAsync(pageIndex, pageSize, 0, cancellationToken);
			}
		}

		public IPagedList<TResult> GetPagedList<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = true) where TResult : class
		{
			IQueryable<TEntity> query = GetAll();
			if (disableTracking)
			{
				query = query.AsNoTracking();
			}

			if (include != null)
			{
				query = include(query);
			}

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (orderBy != null)
			{
				return orderBy(query).Select(selector).ToPagedList(pageIndex, pageSize);
			}
			else
			{
				return query.Select(selector).ToPagedList(pageIndex, pageSize);
			}
		}

		public Task<IPagedList<TResult>> GetPagedListAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = true, CancellationToken cancellationToken = default(CancellationToken)) where TResult : class
		{
			IQueryable<TEntity> query = GetAll();
			if (disableTracking)
			{
				query = query.AsNoTracking();
			}

			if (include != null)
			{
				query = include(query);
			}

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (orderBy != null)
			{
				return orderBy(query).Select(selector).ToPagedListAsync(pageIndex, pageSize, 0, cancellationToken);
			}
			else
			{
				return query.Select(selector).ToPagedListAsync(pageIndex, pageSize, 0, cancellationToken);
			}
		}


		protected static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
		{
			var lambdaParam = Expression.Parameter(typeof(TEntity));
			var lambdaBody = Expression.Equal(Expression.PropertyOrField(lambdaParam, "ID"),
				Expression.Constant(id, typeof(TPrimaryKey)));

			return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
		}

	}
}
