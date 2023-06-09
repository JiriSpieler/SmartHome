﻿using Models;
using SmartHome.Dao.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Repository.IRepositories
{
    public interface IInputRepository
    {
        Task<List<Input>> GetInputsAsync();

        Task AddInputAsync(InputAddModel model);

        Task<Input> GetInputAsync(int id);
    }
}
