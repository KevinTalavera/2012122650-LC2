using _2012122650_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_PER.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly _2012122650DbContext _Context;
        //private static UnityOfWork _Instance;
        //private static readonly object _Lock = new object();

        public ICentroAtencionRepository CentroAtencion { get; set; }
        public IClienteRepository Cliente { get; set; }
        public IContratoRepository Contrato { get; set; }
        public IDepartamentoRepository Departamento { get; set; }
        public IDistritoRepository Distrito { get; set; }
        public IEquipoCelularRepository EquipoCelular { get; set; }
        public IEvaluacionRepository Evaluacion { get; set; }
        public ILineaTelefonicaRepository LineaTelefonica { get; set; }
        public IPlanRepository Plan { get; set; }
        public IProvinciaRepository Provincia { get; set; }
        public ITrabajadorRepository Trabajador { get; set; }
        public IUbigeoRepository Ubigeo { get; set; }
        public IVentaRepository Venta { get; set; }

        public UnityOfWork()
        {

        }

        public UnityOfWork(_2012122650DbContext context)
        {
            //Se crea un unico contexto para la base de datos
            //para apuntar todos los repositorios a la misma base de datos.
            _Context = context;

            CentroAtencion = new CentroAtencionRepository(_Context);
            Cliente = new ClienteRepository(_Context);
            Contrato = new ContratoRepository(_Context);
            Departamento = new DepartamentoRepository(_Context);
            Distrito = new DistritoRepository(_Context);
            EquipoCelular = new EquipoCelularRepository(_Context);
            Evaluacion = new EvaluacionRepository(_Context);
            LineaTelefonica = new LineaTelefonicaRepository(_Context);
            Plan = new PlanRepository(_Context);
            Provincia = new ProvinciaRepository(_Context);
            Trabajador = new TrabajadorRepository(_Context);
            Ubigeo = new UbigeoRepository(_Context);
            Venta = new VentasRepository(_Context);

        }


        public void Dispose()
        {
            _Context.Dispose();
        }

        public int SaveChange()
        {
            return _Context.SaveChanges();
        }

        /*int IUnityOfWork.SaveChange()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }*/

        public void StateModified(object entity)
        {
            //throw new NotImplementedException();
            _Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
