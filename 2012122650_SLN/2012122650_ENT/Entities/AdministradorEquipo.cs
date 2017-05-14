using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class AdministradorEquipo
    {
        public int codAdmiEquipo { get; set; }
        public double inventario { get; set; }
        public ICollection<EquipoCelular> EquipoCelular { get; set; }

        public AdministradorEquipo()
        {
            EquipoCelular = new Collection<EquipoCelular>();
        }
    }
}
