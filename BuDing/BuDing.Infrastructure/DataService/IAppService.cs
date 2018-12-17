using System;
using System.Collections.Generic;
using System.Text;

namespace BuDing.Infrastructure.DataService
{
    public interface IAppService<TEntity> : IReadOnlyService<TEntity>, IWriteOnlyAppService<TEntity>, IDisposable where TEntity : class
    {
    }
}
