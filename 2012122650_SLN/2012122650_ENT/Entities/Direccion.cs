using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class Direccion
    {
        public int codDireccion { get; set; }
        public string nombre { get; set; }
        public CentroAtencion CentroAtencion { get; set; }
        public ICollection<Ubigeo> Ubigeo { get; set; }

        public Direccion()
        {
            Ubigeo = new Collection<Ubigeo>();
        }
    }
}
