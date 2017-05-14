using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class Ubigeo
    {
        public int codUbigeo { get; set; }
        public Direccion Direccion { get; set; }

        public ICollection<Departamento> Departamento { get; set; }
        public ICollection<Provincia> Provincia { get; set; }
        public ICollection<Distrito> Distrito { get; set; }

        public Ubigeo()
        {
            Departamento = new Collection<Departamento>();
            Provincia = new Collection<Provincia>();
            Distrito = new Collection<Distrito>();
        }
    }
}
