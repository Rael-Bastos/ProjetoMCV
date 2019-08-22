using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
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

            container.Register<IAlunosRepository, AlunosRepository>();

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}