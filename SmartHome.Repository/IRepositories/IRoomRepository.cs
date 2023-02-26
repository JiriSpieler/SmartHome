using Models;
using SmartHome.Dao.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Repository.IRepositories
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetRoomsAsync();

        Task AddRoomAsync(RoomAddModel model);

        Task<Room> GetRoomAsync(int id);
    }
}
