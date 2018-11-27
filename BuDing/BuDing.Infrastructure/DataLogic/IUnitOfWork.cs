using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace BuDing.Infrustructure.DataLogic
{
	public interface IUnitOfWork
	{
		DbTransaction BeginTransaction();
		void Commit();
		void RollBack();

		void SaveChanges();

	}
}
