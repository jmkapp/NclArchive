using System.Web.Http;
using DatabaseAccess.Repositories.Cache;
using DatabaseAccess.Repositories.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace NclArchiveApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<IClubRepository, CachedClubRepository>(Lifestyle.Singleton);
            container.Register<ITeamRepository, CachedTeamRepository>(Lifestyle.Singleton);
            container.Register<IGameRepository, CachedGameRepository>(Lifestyle.Singleton);
            container.Register<ISeasonRepository, CachedSeasonRepository>(Lifestyle.Singleton);
            container.Register<IDivisionRepository, CachedDivisionRepository>(Lifestyle.Singleton);
            container.Register<IVenueRepository, CachedVenueRepository>(Lifestyle.Singleton);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
