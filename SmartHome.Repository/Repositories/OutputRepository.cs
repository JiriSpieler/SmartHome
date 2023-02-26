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
    public class OutputRepository : Repository<Output>, IOutputRepository
    {
        public OutputRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
