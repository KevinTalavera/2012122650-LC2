using _2012122650_ENT.Entities;
using _2012122650_PER.EntityTypeConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2012122650_PER
{
    public class _2012122650DbContext : DbContext
    {
        public DbSet<AdministradorEquipo> AdministradoresEquipo { get; set; }
        public DbSet<EquipoCelular> EquiposCelular { get; set; }
        public DbSet<LineaTelefonica> LineasTelefonica { get; set; }
        public DbSet<AdministradorLinea> AdministradoresLinea { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Ubigeo> Ubigeos { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<CentroAtencion> CentrosAtencion { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Trabajador> Trabajadores { get; set; }

        public _2012122650DbContext() : base("DBContext")
		{

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.Add(new EquipoCelularConfiguration());
            modelBuilder.Configurations.Add(new LineaTelefonicaConfiguration());
            modelBuilder.Configurations.Add(new DistritoConfiguration());
            modelBuilder.Configurations.Add(new ProvinciaConfiguration());
            modelBuilder.Configurations.Add(new DepartamentoConfiguration());
            modelBuilder.Configurations.Add(new UbigeoConfiguration());
            modelBuilder.Configurations.Add(new CentroAtencionConfiguration());
            modelBuilder.Configurations.Add(new ContratoConfiguration());
            modelBuilder.Configurations.Add(new VentaConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new EvaluacionConfiguration());
            modelBuilder.Configurations.Add(new PlanConfiguration());
            modelBuilder.Configurations.Add(new TrabajadorConfiguration());



            base.OnModelCreating(modelBuilder);
        }
    }
}
