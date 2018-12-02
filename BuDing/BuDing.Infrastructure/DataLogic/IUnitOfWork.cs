using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace BuDing.Infrastructure.DataLogic
{
	public interface IUnitOfWork
	{

	    /// <summary>
	    /// Changes the database name. This require the databases in the same machine. NOTE: This only work for MySQL right now.
	    /// </summary>
	    /// <param name="database">The database name.</param>
	    /// <remarks>
	    /// This only been used for supporting multiple databases in the same model. This require the databases in the same machine.
	    /// </remarks>
	    void ChangeDatabase(string database);

	    /// <summary>
	    /// Gets the specified repository for the <typeparamref name="TEntity"/>.
	    /// </summary>
	    /// <param name="hasCustomRepository"><c>True</c> if providing custom repositry</param>
	    /// <typeparam name="TEntity">The type of the entity.</typeparam>
	    /// <returns>An instance of type inherited from <see cref="IRepository{TEntity}"/> interface.</returns>
	    IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class, IAggregateRoot;

        int SaveChanges();

	    Task<int> SaveChangesAsync();

        int ExecuteSqlCommand(string sql, params object[] parameters);

        IList<TEntity> GetWithRawSql<TEntity>(string query, params object[] parameters) where TEntity : class, IAggregateRoot;

	    Task<IList<TEntity>> GetWithRawSqlAsync<TEntity>(string query, params object[] parameters) where TEntity : class, IAggregateRoot;

    }
}
