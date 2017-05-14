using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class Provincia
    {
        public int codProvincia { get; set; }
        public string nomProvincia { get; set; }
        public Departamento Departamento { get; set; }
        public Ubigeo Ubigeo { get; set; }
        public ICollection<Distrito> Distrito { get; set; }

        public Provincia()
        {
            Distrito = new Collection<Distrito>();
        }
    }
}
