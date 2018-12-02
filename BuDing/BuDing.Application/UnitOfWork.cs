
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BuDing.Application.Repositories.Standard;
using BuDing.Infrastructure;
using BuDing.Infrastructure.DataLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;

namespace BuDing.Application
{
    public class UnitOfWork<TDbContext> : IRepositoryFactory, IUnitOfWork where TDbContext:DbContext
	{
	    private readonly TDbContext _dbContext;

	    private bool disposed = false;

        private Dictionary<Type, object> repositories;

        public UnitOfWork(TDbContext context)
	    {
	        _dbContext = context ?? throw new ArgumentNullException(nameof(context));
	    }

	    public int SaveChanges()
	    {
	        return _dbContext.SaveChanges();
	    }

	    public Task<int> SaveChangesAsync()
	    {
	        return _dbContext.SaveChangesAsync();
	    }

	    /// <summary>
	    /// Executes the specified raw SQL command.
	    /// </summary>
	    /// <param name="sql">The raw SQL.</param>
	    /// <param name="parameters">The parameters.</param>
	    /// <returns>The number of state entities written to database.</returns>
	    public int ExecuteSqlCommand(string sql, params object[] parameters) => _dbContext.Database.ExecuteSqlCommand(sql, parameters);

        public IList<TEntity> GetWithRawSql<TEntity>(string query, params object[] parameters) where TEntity : class, IAggregateRoot
        {
            return _dbContext.Set<TEntity>().FromSql(query, parameters).ToList();
        }

	    public Task<IList<TEntity>> GetWithRawSqlAsync<TEntity>(string query, params object[] parameters) where TEntity : class, IAggregateRoot
	    {
	        return Task.FromResult(GetWithRawSql<TEntity>(query,parameters));
	    }

	    public void ChangeDatabase(string database)
	    {
	        var connection = _dbContext.Database.GetDbConnection();
	        if (connection.State.HasFlag(ConnectionState.Open))
	        {
	            connection.ChangeDatabase(database);
	        }
	        else
	        {
	            var connectionString = Regex.Replace(connection.ConnectionString.Replace(" ", ""), @"(?<=[Dd]atabase=)\w+(?=;)", database, RegexOptions.Singleline);
	            connection.ConnectionString = connectionString;
	        }

	        // Following code only working for mysql.
	        var items = _dbContext.Model.GetEntityTypes();
	        foreach (var item in items)
	        {
	            if (item.Relational() is RelationalEntityTypeAnnotations extensions)
	            {
	                extensions.Schema = database;
	            }
	        }
        }

	    public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class, IAggregateRoot
	    {
	        if (repositories == null)
	        {
	            repositories=new Dictionary<Type, object>();
	        }

	        if (hasCustomRepository)
	        {
	            var customerRepo = _dbContext.GetService<IRepository<TEntity>>();
	            if (customerRepo != null)
	                return customerRepo;
	        }

	        var type = typeof(TEntity);
	        if (!repositories.ContainsKey(type))
	        {
	            repositories[type]=new EfCoreRepository<TEntity>(_dbContext);
	        }

	        return (IRepository<TEntity>)repositories[type];
	    }
	}
}
