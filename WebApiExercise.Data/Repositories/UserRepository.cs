using WebApiExercise.Core.Contracts;
using WebApiExercise.Core.Models;
using WebApiExercise.Persistence;

namespace WebApiExercise.Core.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
