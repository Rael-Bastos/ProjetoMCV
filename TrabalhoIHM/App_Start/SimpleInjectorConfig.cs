using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;
using TrabalhoIHM.Data;
using TrabalhoIHM.Dominio.UoW;
using TrabalhoIHM.Interfaces;
using TrabalhoIHM.Models;
using TrabalhoIHM.Repositorio;

namespace TrabalhoIHM.App_Start
{
    public class SimpleInjectorConfig
    {
        public static void RegisterComponents()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

           

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            container.Register<EscolaContext>(Lifestyle.Scoped);
            container.Register<IAlunosRepository, AlunosRepository>();
            container.Register<IUnitOfWork, UnitOfWork>();
        }
    }
}