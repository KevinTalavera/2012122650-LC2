﻿using _2012122650_ENT.Entities;
using _2012122650_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_PER.Repositories
{
    public class EquipoCelularRepository : Repository<EquipoCelular>, IEquipoCelularRepository
    {
        public EquipoCelularRepository(_2012122650DbContext context) : base(context)
        {

        }
    }
}
