using System.Linq;
using System.Web.Mvc;

using Unity.AspNet.Mvc;
using WebApiExercise.App_Start;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApiExercise.UnityMvcActivator), nameof(WebApiExercise.UnityMvcActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(WebApiExercise.UnityMvcActivator), nameof(WebApiExercise.UnityMvcActivator.Shutdown))]

namespace WebApiExercise
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with ASP.NET MVC.
    /// </summary>
    public static class UnityMvcActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start() 
        {
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(UnityConfig.GetConfigureContainer()));

            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityConfig.GetConfigureContainer()));

            // TODO: Uncomment if you want to use PerRequestLifetimeManager
            // Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            UnityConfig.GetConfigureContainer().Dispose();
        }
    }
}