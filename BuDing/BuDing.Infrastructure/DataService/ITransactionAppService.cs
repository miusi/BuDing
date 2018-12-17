using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuDing.Infrastructure.DataService
{
    public interface ITransactionAppService<TContext> where TContext : DbContext, new()
    {
        //void BeginTransaction();

        void Commit();
    }
}
