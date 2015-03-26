using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using JustBlog.Controllers;
using JustBlog.Core;
using JustBlog.Core.Objects;
using Ninject;
using Ninject.Web.Common;
using JustBlog.Providers;

namespace JustBlog
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Load(new RepositoryModule());
            kernel.Bind<IBlogRepository>().To<BlogRepository>();
            kernel.Bind<IAuthProvider>().To<AuthProvider>();
            return kernel;
        }

        protected override void OnApplicationStarted()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(Post), new PostModelBinder(Kernel));
            //HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

            base.OnApplicationStarted();
        }

        
        //protected void Application_Start()
        //{
        //    //AreaRegistration.RegisterAllAreas();

        //    //WebApiConfig.Register(GlobalConfiguration.Configuration);
        //    //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    //RouteConfig.RegisterRoutes(RouteTable.Routes);

        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //    base.OnApplicationStarted();
        //}
    }
}