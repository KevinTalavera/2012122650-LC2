using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_ENT.IRepositories
{
    public interface IUnityOfWork : IDisposable
    {
        //cada una de las propiedades deben ser solo lectura
        ICentroAtencionRepository CentroAtencion { get; set; }
        IClienteRepository Cliente { get; set; }
        IContratoRepository Contrato { get; set; }
        IDepartamentoRepository Departamento { get; set; }
        IDistritoRepository Distrito { get; set; }
        IEquipoCelularRepository EquipoCelular { get; set; }
        IEvaluacionRepository Evaluacion { get; set; }
        ILineaTelefonicaRepository LineaTelefonica { get; set; }
        IPlanRepository Plan { get; set; }
        IProvinciaRepository Provincia { get; set; }
        ITrabajadorRepository Trabajador { get; set; }
        IUbigeoRepository Ubigeo { get; set; }
        IVentaRepository Venta { get; set; }

        int SaveChange();

        void StateModified(object entity);
    }
}
