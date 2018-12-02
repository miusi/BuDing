using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BuDing.Application.Repositories.Standard
{
    public interface IRepositoryWithDbContext
    {
        DbContext GetDbContext();
    }
}
