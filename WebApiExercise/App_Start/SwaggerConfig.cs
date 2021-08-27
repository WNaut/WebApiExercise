using Swashbuckle.Application;
using System.Web;
using System.Web.Http;
using WebApiExercise.App_Start;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApiExercise.App_Start
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Web.Api");
                })
                .EnableSwaggerUi(c =>
                {
                    c.EnableApiKeySupport("Authorization", "header");
                });
        }
    }
}