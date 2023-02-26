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
    public class OutputRepository : Repository<Output>, IOutputRepository
    {
        public OutputRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Output>> GetOutputsAsync()
        {
            return await GetAllAsync();
        }

        public async Task AddOutputAsync(OutputAddModel model)
        {
            Output output = new Output();

            if (model.Id.HasValue)
            {
                output = await GetByIdAsync(model.Id.Value);

                output.Value = model.Value;
                output.Dev = model.Dev;
                output.Circuit = model.Circuit;
                output.Name = model.Name;
                output.LastUpdate = DateTime.Now;

                await UpdateAsync(output);
            }
            else
            {
                output.Value = model.Value;
                output.Dev = model.Dev;
                output.Circuit = model.Circuit;
                output.Name = model.Name;
                output.LastUpdate = DateTime.Now;

                await AddAsync(output);
            }
        }

        public async Task<Output> GetOutputAsync(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}
