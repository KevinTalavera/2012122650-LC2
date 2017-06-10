﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class AdministradorEquipo
    {
        public int AdministradorEquipoId { get; set; }
        public string MarcaEquipo { get; set; }
        public int Cantidad { get; set; }
        public EquipoCelular EquipoCelular { get; set; }
        

        public AdministradorEquipo()
        {
            EquipoCelular = new EquipoCelular();
        }
    }
}
