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
    public class RoomThermoRuleRepository : Repository<RoomThermoRule>, IRoomThermoRuleRepository
    {
        public RoomThermoRuleRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<RoomThermoRule>> GetRoomThermoRulesAsync()
        {
            return await GetAllAsync();
        }

        public async Task AddRoomThermoRuleAsync(RoomThermoRuleAddModel model)
        {
            RoomThermoRule roomThermoRule = new RoomThermoRule();

            if (model.Id.HasValue)
            {
                roomThermoRule = await GetByIdAsync(model.Id.Value);

                roomThermoRule.IdRoom = model.IdRoom;
                roomThermoRule.IdThermoRule= model.IdThermoRule;

                await UpdateAsync(roomThermoRule);
            }
            else
            {
                roomThermoRule.IdRoom = model.IdRoom;
                roomThermoRule.IdThermoRule = model.IdThermoRule;

                await AddAsync(roomThermoRule);
            }
        }

        public async Task<RoomThermoRule> GetRoomThermoRuleAsync(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}
