using System;
using System.Collections.Generic;
using System.Text;

namespace BuDing.Infrustructure.Contract.DataService
{
	public interface IDataService
	{

	}

	public interface IDataService<TEntity> : IDataService
	{
		TEntity GetEntityById(object id);

		List<TEntity> GetEntities();

		void Insert(TEntity entity);

		void Update(TEntity entity);

		void Delete(int? id);
	}
}
