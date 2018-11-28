using System.Data.Common;

namespace BuDing.Infrastructure.DataLogic
{
	public interface IUnitOfWork
	{
		DbTransaction BeginTransaction();
		void Commit();
		void RollBack();

		void SaveChanges();

	}
}
