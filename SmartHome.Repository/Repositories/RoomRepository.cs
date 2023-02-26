using AutoMapper;
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
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(DbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<List<Room>> GetRoomsAsync()
        {
            return await GetAllAsync();
        }

        public async Task AddRoomAsync(RoomAddModel model)
        {
            Room room = new Room();

            if (model.Id.HasValue)
            {
                room = await GetByIdAsync(model.Id.Value);

                room.DefaultTemp = model.DefaultTemp;
                room.Name = model.Name;
                room.Hystersis= model.Hystersis;

                await UpdateAsync(room);
            } else
            {
                room.DefaultTemp = model.DefaultTemp;
                room.Name = model.Name;
                room.Hystersis = model.Hystersis;

                await AddAsync(room);
            }     
        }

        public async Task<Room> GetRoomAsync(int id)
        {
            return await GetByIdAsync(id); 
        }
    }
}
