﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class Trabajador
    {
        public int TrabajadorId { get; set; }
        public string NombreTrabajador { get; set; }

        public TipoTrabajador TipoTrabajador { get; set; }

        public List<Evaluacion> Evaluaciones { get; set; }

        public Trabajador()
        {
            TipoTrabajador = new TipoTrabajador();
            Evaluaciones = new List<Evaluacion>();
        }
    }
}
