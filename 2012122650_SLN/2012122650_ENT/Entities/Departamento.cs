﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string departamento { get; set; }

        public ICollection<Provincia> Provincias { get; set; }

        public Departamento()
        {
            Provincias = new Collection<Provincia>();
        }
    }
}
