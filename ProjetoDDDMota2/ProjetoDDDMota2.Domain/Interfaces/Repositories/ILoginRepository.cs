﻿using ProjetoDDDMota2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDDMota2.Domain.Interfaces.Repositories
{
    public interface ILoginRepository : IRepositoryBase<Login>
    {
        Login Logar(string usuario, string senha);
    }
}
