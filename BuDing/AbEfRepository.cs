using System;
using System.Collections.Generic;
using System.Text;

namespace BuDing.Infrustructure.EF
{
	using System.Linq;
	using System.Linq.Expressions;
	using BuDing.Framework.DataLogic;
	using Microsoft.EntityFrameworkCore;

	public abstract class AbEfRepository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected DbContext Context;
		protected DbSet<TEntity> DbSet;

		public AbEfRepository(DbContext context)
		{
			this.Context = context;
			this.DbSet = context.Set<TEntity>();
		}

		public void Delete(object id)
		{
			TEntity entityToDelete = DbSet.Find(id);
			Delete(entityToDelete);
		}

		public void Delete(TEntity entityToDelete)
		{
			if (Context.Entry(entityToDelete).State == EntityState.Deleted)
			{
				DbSet.Attach(entityToDelete);
			}
			DbSet.Remove(entityToDelete);
		} 
		public TEntity GetEntityById(object id)
		{
			return DbSet.Find(id);
		}

		public IEnumerable<TEntity> GetEnumerableCollection(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
		{
			var query = GetQueryableCollection(filter, orderBy, includeProperties);

			return query.ToList<TEntity>();
		}

		public IList<TEntity> GetListCollection(Expression<Func<TEntity, bool>> filter = null,string includeProperties = "")
		{
			var query = GetQueryableCollection(filter, null, includeProperties);

			return query.ToList<TEntity>();
		}

		public IQueryable<TEntity> GetQueryableCollection(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
		{
			IQueryable<TEntity> query = DbSet;

			foreach (var includeProperty in includeProperties.Split(new char[] { ',' }))
			{
				query = query.Include(includeProperty);
			}

			if (orderBy != null)
			{
				query = orderBy(query);
			}

			return query;
		}

		public IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
		{
			return DbSet.FromSql(query, parameters);
		}

		public void Insert(TEntity entity)
		{
			DbSet.Add(entity);
		}

		public void Update(TEntity entityToUpdate)
		{
			DbSet.Attach(entityToUpdate);
			Context.Entry(entityToUpdate).State = EntityState.Modified;
		}

		public int UpdateFields(string query, params object[] parameters)
		{
			return Context.Database.ExecuteSqlCommand(query, parameters);
		}
	}
}
