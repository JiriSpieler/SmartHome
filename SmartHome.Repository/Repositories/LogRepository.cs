using Microsoft.EntityFrameworkCore;
using Models;
using SmartHome.Dao.Dao;
using SmartHome.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Repository.Repositories
{
    public class LogRepository : Repository<Log>, ILogRepository
    {
        public LogRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Log>> GetLogsAsync()
        {
            return await GetAllAsync();
        }

        public async Task AddLogAsync(LogAddModel model)
        {
            Log log = new Log();
            
            log.CreateDate = DateTime.Now;
            log.Description = model.Description;
            log.Message = model.Message;
            log.Type = model.Type;
            log.Section = model.Section;

            await AddAsync(log);
        }

        public async Task<Log> GetLogAsync(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}
