using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class EquipoCelular
    {
        public int codEquipoCel { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public Evaluacion Evaluacion { get; set; }
        public AdministradorEquipo AdministradorEquipo { get; set; }
    }
}
