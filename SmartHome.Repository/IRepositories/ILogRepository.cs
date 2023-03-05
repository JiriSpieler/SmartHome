using Models;
using SmartHome.Dao.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Repository.IRepositories
{
    public interface ILogRepository
    {
        Task<List<Log>> GetLogsAsync();

        Task AddLogAsync(LogAddModel model);

        Task<Log> GetLogAsync(int id);
    }
}
