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
    public class RoomInputRepository : Repository<RoomInput>, IRoomInputRepository
    {
        public RoomInputRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<RoomInput>> GetRoomInputsAsync()
        {
            return await GetAllAsync();
        }

        public async Task AddRoomInputAsync(RoomInputAddModel model)
        {
            RoomInput roomInput = new RoomInput();

            if (model.Id.HasValue)
            {
                roomInput = await GetByIdAsync(model.Id.Value);

                roomInput.IdInput = model.IdInput;
                roomInput.IdRoom = model.IdRoom;
                roomInput.IdSecondaryInput = model.IdSecondaryInput;

                await UpdateAsync(roomInput);
            }
            else
            {
                roomInput.IdInput = model.IdInput;
                roomInput.IdRoom = model.IdRoom;
                roomInput.IdSecondaryInput = model.IdSecondaryInput;

                await AddAsync(roomInput);
            }
        }

        public async Task<RoomInput> GetRoomInputAsync(int id)
        {
            return await GetByIdAsync(id);
        }
    }
}
