using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class Distrito
    {
        public int codDistrito { get; set; }
        public string nomDistrito { get; set; }
        public Ubigeo Ubigeo { get; set; }
        public Provincia Provincia { get; set; }
    }
}
