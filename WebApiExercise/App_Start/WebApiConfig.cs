using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WebApiExercise.Handlers;

namespace WebApiExercise
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new AuthorizeAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());

            JsonSerializerSettings serializerSettings = config.Formatters.JsonFormatter.SerializerSettings;
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            serializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializerSettings.NullValueHandling = NullValueHandling.Ignore;
        }
    }
}
