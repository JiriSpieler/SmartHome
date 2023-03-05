using Models;
using SmartHome.Dao.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Repository.IRepositories
{
    public interface IRoomInputRepository
    {
        Task<List<RoomInput>> GetRoomInputsAsync();

        Task AddRoomInputAsync(RoomInputAddModel model);

        Task<RoomInput> GetRoomInputAsync(int id);
    }
}
