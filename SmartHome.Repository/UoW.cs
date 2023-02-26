using SmartHome.Dao.Dao;
using SmartHome.Repository.IRepositories;
using SmartHome.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Repository
{
    public class UoW : IUoW
    {
        #region Commit and DbContext

        /// <summary>
        /// CWSContext
        /// </summary>
        private SmartHomeContext SHContext { get; set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public UoW()
        {
            CreateSHContext();
        }

        /// <summary>
        /// Vytvoření DB kontextu
        /// pro SDRD databázi
        /// </summary>
        private void CreateSHContext()
        {
            SHContext = new SmartHomeContext();
        }

        /// <summary>
        /// Potvrzení změn do DB
        /// </summary>
        public void CommitSM()
        {
            SHContext.SaveChanges();
        }

        public async Task CommitSMAsync()
        { 
            await SHContext.SaveChangesAsync();
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Ukončení spojení do databáze
        /// Funkce je určena proto, aby
        /// ukončila spojení s DB a objekty
        /// změněné mimo tuto aplikaci
        /// byly vždy aktuální
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (SHContext != null) SHContext.Dispose();
            }
        }

        #endregion

        #region REPOSITORIES

        private IRepository<Room> _room;

        public IRepository<Room> Room
        {
            get
            {
                if (_room == null)
                    _room = new Repository<Room>(SHContext);

                return _room;
            }
        }

        private IRepository<Output> _output;

        public IRepository<Output> Output
        {
            get
            {
                if (_output == null)
                    _output = new Repository<Output>(SHContext);

                return _output;
            }
        }

        private IRepository<Input> _input;

        public IRepository<Input> Input
        {
            get
            {
                if (_input == null)
                    _input = new Repository<Input>(SHContext);

                return _input;
            }
        }

        #endregion

        #region EXTENDED REPOSTIORIES

        /// <summary>
        /// RoomEx
        /// </summary>
        private IRoomRepository _roomEx;

        public IRoomRepository RoomEx
        {
            get
            {
                if (_roomEx == null)
                    _roomEx = new RoomRepository(SHContext);

                return _roomEx;
            }
        }

        /// <summary>
        /// InputEx
        /// </summary>
        private IInputRepository _inputEx;

        public IInputRepository InputEx
        {
            get
            {
                if (_inputEx == null)
                    _inputEx = new InputRepository(SHContext);

                return _inputEx;
            }
        }

        /// <summary>
        /// OutputEx
        /// </summary>
        private IOutputRepository _outputEx;

        public IOutputRepository OutputEx
        {
            get
            {
                if (_outputEx == null)
                    _outputEx = new OutputRepository(SHContext);

                return _outputEx;
            }
        }

        #endregion
    }
}
