using SmartHome.Dao.Dao;
using SmartHome.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Repository
{
    public interface IUoW
    {
        /// <summary>
        /// Potvrzení vložení do DB
        /// </summary>
        void CommitSM();

        Task CommitSMAsync();

        #region REPOSITORIES

        IRepository<Room> Room { get; }

        IRepository<Input> Input { get; }

        IRepository<Output> Output { get; }

        #endregion

        #region EXTENDED REPOSTIORIES

        IRoomRepository RoomEx { get; }

        IInputRepository InputEx { get; }

        IOutputRepository OutputEx { get; }

        #endregion
    }
}
