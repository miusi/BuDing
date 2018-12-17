using System;
using System.Collections.Generic;
using System.Text;
using BuDing.Infrastructure.DataLogic;
using BuDing.Infrastructure.DataService;
using Microsoft.EntityFrameworkCore;

namespace BuDing.Application.Services.Stardand
{

    public class TransactionAppService<TContext> : ITransactionAppService<TContext> where TContext : DbContext, new()
    {
        private IUnitOfWork _uow;

        //public void BeginTransaction()
        //{
        //    throw new NotImplementedException();
        //}

        public void Commit()
        {
            _uow.SaveChanges();
        }
    }
}
