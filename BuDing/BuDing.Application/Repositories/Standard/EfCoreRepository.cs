using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BuDing.Application.Context;
using BuDing.Infrastructure;
using BuDing.Infrastructure.DataLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BuDing.Application.Repositories.Standard
{
    public class EfCoreRepository<TEntity> : EfCoreRepository<TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity, IAggregateRoot
    {
        public EfCoreRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }

    public class EfCoreRepository<TEntity,TPrimaryKey>:RepositoryBase<TEntity,TPrimaryKey>,IRepositoryWithDbContext where TEntity:class,IEntity<TPrimaryKey>,IAggregateRoot<TPrimaryKey>
    {
        internal readonly DbContext _dbContext; 

        public EfCoreRepository(DbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        /// <summary>
        /// Changes the table name. This require the tables in the same database.
        /// </summary>
        /// <param name="table"></param>
        /// <remarks>
        /// This only been used for supporting multiple tables in the same model. This require the tables in the same database.
        /// </remarks>
        public override void ChangeTable(string table)
        {
            if (_dbContext.Model.FindEntityType(typeof(TEntity)).Relational() is RelationalEntityTypeAnnotations relational)
            {
                relational.TableName = table;
            }
        }

        public virtual DbSet<TEntity> Table => _dbContext.Set<TEntity>();

        public override IQueryable<TEntity> GetAll()
        {
            return Table.AsQueryable();
        }

        //public override IList<TEntity> GetWithRawSql(string query, params object[] parameters)
        //{
        //    return Table.FromSql(query, parameters).ToList();
        //}

        public override TEntity Insert(TEntity entity)
        {
            var newEntity = Table.Add(entity).Entity;
            return newEntity;
        }

        public override TEntity Update(TEntity entityToUpdate)
        {
            AttachIfNot(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State=EntityState.Modified;
            return entityToUpdate;
        }

        //public override int UpdateFields(string query, params object[] parameters)
        //{
        //    IList<TEntity> entities = GetWithRawSql(query, parameters);
        //    foreach (var entity in entities)
        //    {
        //        Update(entity);
        //    }
        //    return 1;
        //}

        public override void Delete(TEntity entity)
        {
            AttachIfNot(entity);
            Table.Remove(entity);
        }

        public override void Delete(TPrimaryKey id)
        {
            var entity = GetFromChangeTracjerOrNull(id);
            if (entity != null)
            {
                Delete(entity);
                return;
            }

            entity = FirstOrDefault(id);
            if (entity != null)
            {
                Delete(entity);
                return;
            }
        }

        public DbContext GetDbContext()
        {
            return _dbContext;
        }

        protected virtual void AttachIfNot(TEntity entity)
        {
            var entry = _dbContext.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
            if (entry != null)
            {
                return;
            }
            Table.Attach(entity);
        }

        private TEntity GetFromChangeTracjerOrNull(TPrimaryKey id)
        {
            var entry = _dbContext.ChangeTracker.Entries()
                .FirstOrDefault(ent => ent.Entity is TEntity &&
                                       EqualityComparer<TPrimaryKey>.Default.Equals(id, ((TEntity) ent.Entity).ID));
            return entry?.Entity as TEntity;
        }
    }
}
