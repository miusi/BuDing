
using System.Data.Common;
using BuDing.Infrastructure.DataLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BuDing.Application
{
    public class UnitOfWork : IUnitOfWork
	{
		private readonly DbContext _context;

		public UnitOfWork(DbContext context)
		{
			_context = context;
		}

		public DbTransaction BeginTransaction()
		{
			_context.Database.BeginTransaction();


			return _context.Database.CurrentTransaction.GetDbTransaction();
		}

		public void Commit()
		{
			_context.SaveChanges();
			_context.Database.CommitTransaction();
		}

		public void RollBack()
		{
			_context.Database.RollbackTransaction();
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}
