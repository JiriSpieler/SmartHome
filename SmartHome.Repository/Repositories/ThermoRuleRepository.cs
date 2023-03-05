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
    public class ThermoRuleRepository : Repository<ThermoRule>, IThermoRuleRepository
    {
        public ThermoRuleRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<ThermoRule>> GetThermoRulesAsync()
        {
            return (await GetAllAsync()).Where(p => !p.Disabled).ToList();
        }

        public async Task AddThermoRuleAsync(ThermoRuleAddModel model)
        {
            ThermoRule thermoRule = new ThermoRule();

            if (model.Id.HasValue)
            {
                thermoRule = await GetByIdAsync(model.Id.Value);

                thermoRule.Disabled = model.Disabled;
                thermoRule.End = model.End;
                thermoRule.Start = model.Start;
                thermoRule.WeekDay = model.WeekDay;
                thermoRule.LastUpdate = DateTime.Now;

                await UpdateAsync(thermoRule);
            }
            else
            {
                thermoRule.Disabled = false;
                thermoRule.End = model.End;
                thermoRule.Start = model.Start;
                thermoRule.WeekDay = model.WeekDay;
                thermoRule.IntervalSatus = false;
                thermoRule.LastUpdate = DateTime.Now;

                await AddAsync(thermoRule);
            }
        }

        public async Task<ThermoRule> GetThermoRuleAsync(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}
