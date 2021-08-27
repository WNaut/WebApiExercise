using Core.Contracts;
using Core.Repositories;
using Persistence;
using System.Web.Http;
using Unity;
using Unity.AspNet.Mvc;
using UnityDependencyResolver = Unity.WebApi.UnityDependencyResolver;

namespace WebApiExercise.App_Start
{
    public static class UnityConfig
    {
        private static readonly UnityContainer _container;

        internal static IUnityContainer GetConfigureContainer() => _container;

        static UnityConfig() => _container = new UnityContainer();

        /// <summary>
        /// Register all components of DI
        /// </summary>
        public static void RegisterComponents()
        {
            RegisterDatabaseContext();
            RegisterRepositories();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(_container);
        }

        private static void RegisterDatabaseContext()
        {
            _container.RegisterType<AppDbContext>(new PerRequestLifetimeManager());
        }

        private static void RegisterRepositories()
        {
            var context = new AppDbContext();
            _container.RegisterType<IUserRepository, UserRepository>(new PerRequestLifetimeManager());
        }
    }
}