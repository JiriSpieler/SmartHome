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
    public class RoomOutputRepository : Repository<RoomOutput>, IRoomOutputRepository
    {
        public RoomOutputRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<RoomOutput>> GetRoomOutputsAsync()
        {
            return await GetAllAsync();
        }

        public async Task AddRoomOutputAsync(RoomOutputAddModel model)
        {
            RoomOutput roomOutput = new RoomOutput();

            if (model.Id.HasValue)
            {
                roomOutput = await GetByIdAsync(model.Id.Value);

                roomOutput.IdOutput = model.IdOutput;
                roomOutput.IdRoom = model.IdRoom;

                await UpdateAsync(roomOutput);
            }
            else
            {
                roomOutput.IdOutput = model.IdOutput;
                roomOutput.IdRoom = model.IdRoom;

                await AddAsync(roomOutput);
            }
        }

        public async Task<RoomOutput> GetRoomOutputAsync(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}
