using System.Net;
using System.Web.Http;
using WebApiExercise.Handlers;

namespace WebApiExercise.Controllers
{
    public class AuthenticationController : ApiController
    {
        [AllowAnonymous]
        public string Get(string username, string password)
        {
            return TokenValidationHandler.GenerateToken(username);
        }
    }
}
