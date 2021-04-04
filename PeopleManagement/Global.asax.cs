using PeopleManagement.App_Start;
using PeopleManagement.Data;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PeopleManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Init database
            var db = new PeopleManagementEntities();
           // db.Database.Initialize(true);
           // System.Data.Entity.Database.SetInitializer(new PeopleManagementSeedData(db));
            

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Autofac and AutoMapper configurations
            Bootstrapper.Run();
        }
    }
}
