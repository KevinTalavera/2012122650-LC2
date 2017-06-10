using _2012122650_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.EntitiesDTO
{
    public class EvaluacionDTO
    {
        public int EvaluacionId { get; set; }
        public EstadoEvaluacion EstadoEvaluacion { get; set; }
        public TipoEvaluacion TipoEvaluacion { get; set; }
    }
}
