﻿using Models;
using SmartHome.Dao.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Repository.IRepositories
{
    public interface IOutputRepository
    {
        Task<List<Output>> GetOutputsAsync();

        Task AddOutputAsync(OutputAddModel model);

        Task<Output> GetOutputAsync(int id);
    }
}
