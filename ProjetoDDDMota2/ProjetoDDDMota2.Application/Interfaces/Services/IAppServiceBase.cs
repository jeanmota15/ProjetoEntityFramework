﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDDMota2.Application.Interfaces.Services
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();
    }
}
