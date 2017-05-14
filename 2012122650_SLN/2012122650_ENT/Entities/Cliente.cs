using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class Cliente
    {
        public int codCliente { get; set; }
        public string nombre { get; set; }
        public string DNI { get; set; }
        public ICollection<Evaluacion> Evaluacion { get; set; }
        public ICollection<Venta> Venta { get; set; }
    }
}
