using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.Entities
{
    public class Evaluacion
    {
        public int codEvaluacion { get; set; }
        public Venta Venta { get; set; }
        public CentroAtencion CentroAtencion { get; set; }
        public Trabajador Trabajador { get; set; }
        public EstadoEvaluacion EstadoEvaluacion { get; set; }
        public TipoEvaluacion TipoEvaluacion { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Plan> Plan { get; set; }
        public ICollection<EquipoCelular> EquipoCelular { get; set; }
        public ICollection<LineaTelefonica> LineaTelefonica { get; set; }

        public Evaluacion()
        {
            Plan = new Collection<Plan>();
            EquipoCelular = new Collection<EquipoCelular>();
            LineaTelefonica = new Collection<LineaTelefonica>();
        }
    }
}
