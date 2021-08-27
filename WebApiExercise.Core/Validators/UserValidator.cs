using FluentValidation;
using WebApiExercise.Core.Contracts;
using WebApiExercise.Core.Models;

namespace WebApiExercise.Core.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        internal const string SaveUser = "SaveUser";
        private readonly IUserRepository _userRepository;
        internal UserValidator(IUserRepository userRepository)
        {

        }

        private bool IsValidUser(User userRequest)
        {
            bool result =
             _userRepository.Exists(user => user.Id == userRequest.Id);

            return !result;

        }
    }
}
