using System;
using System.Collections.Generic;
using System.Text;

namespace BuDing.Infrastructure
{
	public interface IEntity:IAggregateRoot<int>
	{
	}

    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey ID { get; set; }
    }
}
