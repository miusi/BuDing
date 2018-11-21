using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace BuDing.Infrustructure.Contract.DataLogic
{
	public interface IUnitOfWork
	{
		DbTransaction BeginTransaction();
		void Commit();
		void RollBack();

	}
}
