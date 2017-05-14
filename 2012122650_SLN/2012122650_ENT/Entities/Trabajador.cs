using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class Trabajador
    {
        public int codTrabajador { get; set; }
        public string nombre { get; set; }
        public TipoTrabajador TipoTrabajador { get; set; }
        public ICollection<Evaluacion> Evaluacion { get; set; }

        public Trabajador()
        {
            Evaluacion = new Collection<Evaluacion>();
        }
    }
}
