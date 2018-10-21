﻿using System.Web.Http;
using DatabaseAccess.Repositories;
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

            container.Register<IClubRepository, ClubRepository>(Lifestyle.Singleton);
            container.Register<ITeamRepository, TeamRepository>(Lifestyle.Singleton);
            container.Register<IGameRepository, GameRepository>(Lifestyle.Singleton);
            container.Register<ISeasonRepository, SeasonRepository>(Lifestyle.Singleton);
            container.Register<IDivisionRepository, DivisionRepository>(Lifestyle.Singleton);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
