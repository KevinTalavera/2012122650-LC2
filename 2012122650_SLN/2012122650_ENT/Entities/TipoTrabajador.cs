using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class TipoTrabajador
    {
        public int codTipoTra { get; set; }
        public string cargo { get; set; }
        public ICollection<Trabajador> Trabajador { get; set; }

        public TipoTrabajador()
        {
            Trabajador = new Collection<Trabajador>();
        }
    }
}
