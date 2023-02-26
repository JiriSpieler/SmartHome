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
    public class InputRepository : Repository<Input>, IInputRepository
    {
        public InputRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Input>> GetInputsAsync()
        {
            return await GetAllAsync();
        }

        public async Task AddInputAsync(InputAddModel model)
        {
            Input input = new Input();

            if (model.Id.HasValue)
            {
                input = await GetByIdAsync(model.Id.Value);

                input.Value = model.Value;
                input.Dev = model.Dev;
                input.Circuit = model.Circuit;
                input.Name = model.Name;
                input.LastUpdate = DateTime.Now;
                
                await UpdateAsync(input);
            }
            else
            {
                input.Value = model.Value;
                input.Dev = model.Dev;
                input.Circuit = model.Circuit;
                input.Name = model.Name;
                input.LastUpdate = DateTime.Now;

                await AddAsync(input);
            }
        }

        public async Task<Input> GetInputAsync(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}
