using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class EstadoEvaluacion
    {
        public int codEstadoEva { get; set; }
        public string nomEstadoEva { get; set; }
        public ICollection<Evaluacion> Evaluacion { get; set; }

        public EstadoEvaluacion()
        {
            Evaluacion = new Collection<Evaluacion>();
        }
    }
}
