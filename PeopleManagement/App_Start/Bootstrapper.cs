using Autofac;
using Autofac.Integration.Mvc;
using PeopleManagement.Data.Infrastructure;
using PeopleManagement.Data.Repositories;
using PeopleManagement.Infrastructure;
using PeopleManagement.Service.Services;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace PeopleManagement.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutoFacContainer();
        }

        private static void SetAutoFacContainer()
        {
            var builder = new ContainerBuilder();
            {
                //Controllers
                builder.RegisterControllers(Assembly.GetExecutingAssembly());
                builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
                builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

                // Repositories
                builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
                    .Where(t => t.Name.EndsWith("Repository"))
                    .AsImplementedInterfaces().InstancePerRequest();
                builder.RegisterAssemblyTypes(typeof(SubjectRepository).Assembly)
                    .Where(t => t.Name.EndsWith("Repository"))
                    .AsImplementedInterfaces().InstancePerRequest();
                builder.RegisterAssemblyTypes(typeof(UserSubjectsRepository).Assembly)
                    .Where(t => t.Name.EndsWith("Repository"))
                    .AsImplementedInterfaces().InstancePerRequest();

                //Services
                builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                    .Where(t => t.Name.EndsWith("Service"))
                    .AsImplementedInterfaces().InstancePerRequest();
                builder.RegisterAssemblyTypes(typeof(SubjectService).Assembly)
                    .Where(t => t.Name.EndsWith("Service"))
                    .AsImplementedInterfaces().InstancePerRequest();
                builder.RegisterAssemblyTypes(typeof(UserSubjectsService).Assembly)
                    .Where(t => t.Name.EndsWith("Service"))
                    .AsImplementedInterfaces().InstancePerRequest();

                builder.RegisterFilterProvider();

                //Register AutoMapper here using AutoFacModule class 
                builder.RegisterModule<AutoFacModule>();

                Autofac.IContainer container = builder.Build();
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            };
        }
    }
}