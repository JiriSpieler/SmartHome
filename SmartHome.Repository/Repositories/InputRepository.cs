using Microsoft.EntityFrameworkCore;
using SmartHome.Dao.Dao;
using SmartHome.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Repository.Repositories
{
    public class InputRepository : Repository<Input>, IInputRepository
    {
        public InputRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
