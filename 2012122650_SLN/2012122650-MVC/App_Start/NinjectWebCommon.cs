[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(_2012122650_MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(_2012122650_MVC.App_Start.NinjectWebCommon), "Stop")]

namespace _2012122650_MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using _2012122650_ENT.IRepositories;
    using _2012122650_PER.Repositories;
    using _2012122650_PER;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUnityOfWork>().To<UnityOfWork>();
            kernel.Bind<_2012122650DbContext>().To<_2012122650DbContext>();

            kernel.Bind<ICentroAtencionRepository>().To<CentroAtencionRepository>();
            kernel.Bind<IClienteRepository>().To<ClienteRepository>();
            kernel.Bind<IContratoRepository>().To<ContratoRepository>();
            kernel.Bind<IDepartamentoRepository>().To<DepartamentoRepository>();
            kernel.Bind<IDistritoRepository>().To<DistritoRepository>();
            kernel.Bind<IEquipoCelularRepository>().To<EquipoCelularRepository>();
            kernel.Bind<IEvaluacionRepository>().To<EvaluacionRepository>();
            kernel.Bind<ILineaTelefonicaRepository>().To<LineaTelefonicaRepository>();
            kernel.Bind<IPlanRepository>().To<PlanRepository>();
            kernel.Bind<IProvinciaRepository>().To<ProvinciaRepository>();
            kernel.Bind<ITrabajadorRepository>().To<TrabajadorRepository>();
            kernel.Bind<IUbigeoRepository>().To<UbigeoRepository>();
            kernel.Bind<IVentaRepository>().To<VentasRepository>();
        }        
    }
}
