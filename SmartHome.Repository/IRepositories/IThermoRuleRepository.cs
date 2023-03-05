using Models;
using SmartHome.Dao.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Repository.IRepositories
{
    public interface IThermoRuleRepository
    {
        Task<List<ThermoRule>> GetThermoRulesAsync();

        Task AddThermoRuleAsync(ThermoRuleAddModel model);

        Task<ThermoRule> GetThermoRuleAsync(int id);
    }
}
