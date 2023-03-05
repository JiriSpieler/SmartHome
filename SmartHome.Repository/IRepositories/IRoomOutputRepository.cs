using Models;
using SmartHome.Dao.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Repository.IRepositories
{
    public interface IRoomOutputRepository
    {
        Task<List<RoomOutput>> GetRoomOutputsAsync();

        Task AddRoomOutputAsync(RoomOutputAddModel model);

        Task<RoomOutput> GetRoomOutputAsync(int id);
    }
}
