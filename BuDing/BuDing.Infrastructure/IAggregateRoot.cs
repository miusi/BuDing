using System;
using System.Collections.Generic;
using System.Text;

namespace BuDing.Infrastructure
{
    public interface IAggregateRoot : IAggregateRoot<int>, IEntity
    {
        
    }

    public interface IAggregateRoot<TPrimaryKey>:IEntity<TPrimaryKey>
    {
    }
}
