using Core.Contracts;
using Core.Managers;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiExercise.Filters;

namespace WebApiExercise.Controllers
{
    /// <summary>
    /// Represents a controller for <see cref="User"/>
    /// </summary>
    [RoutePrefix("api/users")]
    [JwtAuthentication]
    public sealed class UsersController : ApiController
    {
        private readonly UserManager _userManager;

        /// <summary>
        /// Creates a new instance of <see cref="UsersController"/>
        /// </summary>
        /// <param name="mapper">An instance of <see cref="IMapper"/></param>
        /// <param name="userManager">An instance of <see cref="UserManager"/></param>
        public UsersController(UserManager userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Retrieves a list of users
        /// </summary>
        /// <returns>An implementation of <see cref="IHttpActionResult"/></returns>
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetUsers()
        {
            IOperationResult<ICollection<User>> operationResult = await _userManager.GetUsers();

            if (!operationResult.Success)
            {
                return BadRequest(operationResult.Message);
            }

            return Ok(operationResult);
        }

        /// <summary>
        /// Retrieves a user by user id
        /// </summary>
        /// <returns>An implementation of <see cref="IHttpActionResult"/></returns>
        [HttpPost()]
        [Route("")]
        public async Task<IHttpActionResult> CreateUser(User userRequest)
        {
            IOperationResult<User> operationResult = await _userManager.Create(userRequest);

            if (!operationResult.Success)
            {
                return BadRequest(operationResult.Message);
            }

            return Ok(operationResult);
        }

        /// <summary>
        /// Retrieves a user by user id
        /// </summary>
        /// <returns>An implementation of <see cref="IHttpActionResult"/></returns>
        [HttpGet()]
        [Route("{userId}")]
        public async Task<IHttpActionResult> GetUser(int userId)
        {
            IOperationResult<User> operationResult = await _userManager.GetUserById(userId);

            if (!operationResult.Success)
            {
                return BadRequest(operationResult.Message);
            }

            return Ok(operationResult);
        }

        /// <summary>
        /// Updates an existing user
        /// </summary>
        /// <param name="userRequest">The user to update</param>
        /// <returns>An implementation of <see cref="IHttpActionResult"/></returns>
        [HttpPut]
        public async Task<IHttpActionResult> UpdateUser([FromBody] User userRequest)
        {
            IOperationResult<User> operationResult = await _userManager.Update(userRequest);

            if (!operationResult.Success)
            {
                return BadRequest(operationResult.Message);
            }

            return Ok(new { message = operationResult.Message });
        }

        /// <summary>
        /// Removes an existing user
        /// </summary>
        /// <param name="userRequest">The user to update</param>
        /// <returns>An implementation of <see cref="IHttpActionResult"/></returns>
        [HttpDelete]
        [Route("{userId}")]
        public async Task<IHttpActionResult> RemoveUser(int userid)
        {
            IOperationResult<User> operationResult = await _userManager.Delete(userid);

            if (!operationResult.Success)
            {
                return BadRequest(operationResult.Message);
            }

            return Ok(new { message = operationResult.Message });
        }
    }
}
