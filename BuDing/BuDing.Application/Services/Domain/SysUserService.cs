
using System;


namespace BuDing.Application.Services.Domain
{
	using BuDing.Domain.Entities;
	using BuDing.Common.Security;
	using BuDing.Infrastructure.DataLogic;
	using BuDing.Application.Services.Stardand;
	using BuDing.Application.Interfaces.Services;
	using BuDing.Application.Interfaces.PageList;
	using BuDing.Infrastructure.ValidationLogic;
	using BuDing.Infrastructure.Utilities;

	public class SysUserService : ServiceBase<SysUserEntity>,ISysUserService
	{
		public SysUserService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		/// <summary>
		/// 新增系统用户
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
	    public override ValidationResult Add(SysUserEntity entity)
	    {
			entity.Passwrod = SecurityHelper.MD5Hash(entity.Passwrod);
			entity.CreateOn = DateTime.Now;
			entity.ModifiedOn = DateTime.Now;

			ValidationResult.Add(base.Add(entity)); 

	        if (ValidationResult.IsValid)
	        {
	            _unitOfWork.SaveChanges();
	        }
	        return ValidationResult;
	    }

	    public IPagedList<SysUserEntity> GetPagedList(int pageIndex, int pageSize)
        {
            return _repository.GetEnumerable().ToPagedList<SysUserEntity>(pageIndex, pageSize);
        }

        public IPagedList<SysUserEntity> GetPagedListByUserName(string userName, int pageIndex, int pageSize)
        {
            return _repository.GetEnumerable(t => t.Name == userName).ToPagedList<SysUserEntity>(pageIndex, pageSize);
        }

		public BaseResult Login(string username, string password)
		{
			throw new NotImplementedException();
		}
	}
}
