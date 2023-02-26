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

        public async Task AddRoomAsync(RoomAddModel model)
        {
            await AddAsync(new Dao.Dao.Room()
            {
                DefaultTemp = model.DefaultTemp,
                Hystersis = model.Hystersis,
                Name = model.Name
            });
        }

        public async Task<Room> GetRoomAsync(int id)
        {
            return await GetByIdAsync(id); 
        }
    }
}
