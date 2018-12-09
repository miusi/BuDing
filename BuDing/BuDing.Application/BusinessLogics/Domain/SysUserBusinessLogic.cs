using BuDing.Application.Interfaces.BusinessLogic;
using BuDing.Domain.Entities;
using BuDing.Infrastructure.DataLogic;
using BuDing.Infrastructure.PageList;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuDing.Application.BusinessLogics.Domain
{
	public class SysUserBusinessLogic : ISysUserBusinessLogic
	{
		private IUnitOfWork _unitOfWork;
		private IRepository<SysUserEntity> _repository;
		public SysUserBusinessLogic(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
			this._repository = this._unitOfWork.GetRepository<SysUserEntity>();
		}

		public Task Delete(SysUserEntity entity)
		{
			var result = _repository.DeleteAsync(entity);
			_unitOfWork.SaveChangesAsync();
			return result;
		}

		public Task<IPagedList<SysUserEntity>> GetPagedList(int pageIndex, int pageSize)
		{
			return Task.FromResult(_repository.GetEnumerable().ToPagedList<SysUserEntity>(pageIndex,pageSize));
		}

		public Task<IPagedList<SysUserEntity>> GetPagedListByUserName(string userName, int pageIndex, int pageSize)
		{
            return Task.FromResult(_repository.GetEnumerable(t => t.Name == userName).ToPagedList<SysUserEntity>(pageIndex, pageSize));
		}
        

		public Task<SysUserEntity> GetSysUserById(int id)
		{ 
			return _repository.GetEntityByIdAsync(id);
		}

		public Task<SysUserEntity> Insert(SysUserEntity entity)
		{
			throw new NotImplementedException();
		}

		public Task<SysUserEntity> Update(SysUserEntity entity)
		{
			throw new NotImplementedException();
		}
	}
}
