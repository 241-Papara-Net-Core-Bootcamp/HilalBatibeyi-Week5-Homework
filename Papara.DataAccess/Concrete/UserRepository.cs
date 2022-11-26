using Microsoft.EntityFrameworkCore;
using Papara.Core.Entites;
using Papara.Core.Enums;
using Papara.Core.Interfaces;
using Papara.DataAccess.Abstract;
using Papara.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papara.DataAccess.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DbSet<User> _user;

        public UserRepository(PaparaDbContext dbContext, Func<CacheTech, ICacheService> cacheService)
            : base(dbContext, cacheService)
        {
            _user = dbContext.Set<User>();
        }
    }
}
