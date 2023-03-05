using Models;
using SmartHome.Dao.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Repository.IRepositories
{
    public interface IRoomThermoRuleRepository
    {
        Task<List<RoomThermoRule>> GetRoomThermoRulesAsync();

        Task AddRoomThermoRuleAsync(RoomThermoRuleAddModel model);

        Task<RoomThermoRule> GetRoomThermoRuleAsync(int id);
    }
}
