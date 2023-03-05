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

        IRepository<ThermoRule> ThermoRule { get; }

        IRepository<RoomInput> RoomInput { get; }

        IRepository<RoomOutput> RoomOutput { get; }

        IRepository<RoomThermoRule> RoomThermoRule { get; }

        IRepository<Log> Log { get; }

        #endregion

        #region EXTENDED REPOSTIORIES

        IRoomRepository RoomEx { get; }

        IInputRepository InputEx { get; }

        IOutputRepository OutputEx { get; }

        IThermoRuleRepository ThermoRuleEx { get; }

        IRoomInputRepository RoomInputEx { get; }

        IRoomOutputRepository RoomOutputEx { get; }

        IRoomThermoRuleRepository RoomThermoRuleEx { get; }

        ILogRepository LogEx { get; }

        #endregion
    }
}
