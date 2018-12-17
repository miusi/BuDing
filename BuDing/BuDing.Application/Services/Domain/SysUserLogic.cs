 
using BuDing.Application.Services.Stardand;
using BuDing.Domain.Entities;
using BuDing.Infrastructure.BusinessLogic;
using BuDing.Infrastructure.DataLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace BuDing.Application.Services.Domain
{
	public class SysUserLogic : DataService<SysUserEntity>
	{
		public SysUserLogic(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
        
        private readonly ValidationResult _validationResult;
	    protected ValidationResult ValidationResult
	    {
	        get { return _validationResult; }
	    }

        public override ValidationResult Add(SysUserEntity entity)
	    {
	        throw new NotImplementedException();
	    }

	    public override Task<ValidationResult> AddAsync(SysUserEntity entity)
	    {
	        throw new NotImplementedException();
	    }
         

	    public override ValidationResult Delete(SysUserEntity entity)
	    {
	        throw new NotImplementedException();
	    }

	    public override Task<ValidationResult> DeleteAsync(SysUserEntity entity)
	    {
	        throw new NotImplementedException();
	    }
	}
}
