using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Contracts;
using Core.Models;
using Core.Validators;

namespace Core.Managers
{
    /// <summary>
    /// Represents a manager for <see cref="User"/>
    /// </summary>
    public sealed class UserManager
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Creates an instance of <see cref="UserManager"/>
        /// </summary>
        /// <param name="userRepository">An implementation of <see cref="IUserRepository"/></param>
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Retrieves a list with all the users
        /// </summary>
        /// <returns>An implementation of <see cref="Task{IOperationResult}"/></returns>
        public async Task<IOperationResult<ICollection<User>>> GetUsers()
        {
            try
            {
                return BasicOperationResult<ICollection<User>>.Ok(await _userRepository.GetAllAsync());
            }
            catch (Exception)
            {
                return BasicOperationResult<ICollection<User>>.Fail("Could Not Retrieve The Users");
            }
        }

        /// <summary>
        /// Retrieves an user by user identification
        /// </summary>
        /// <returns>An implementation of <see cref="Task{IOperationResult}"/></returns>
        public async Task<IOperationResult<User>> GetUserById(int userId)
        {
            try
            {
                User foundUser = await _userRepository.FindAsync(user => user.Id == userId);

                if (foundUser == null)
                {
                    return BasicOperationResult<User>.Fail("User Not Found");
                }

                return BasicOperationResult<User>.Ok(foundUser);
            }
            catch (Exception)
            {
                return BasicOperationResult<User>.Fail("Could Not Retrieve The User");
            }
        }

        /// <summary>
        /// Creates an user 
        /// </summary>
        /// <returns>An implementation of <see cref="Task{IOperationResult}"/></returns>
        public async Task<IOperationResult<User>> Create(User userRequest)
        {
            try
            {
                var userValidator = new UserValidator();
                var validation = await userValidator.ValidateAsync(userRequest);

                if (!validation.IsValid)
                {
                    var validationFailure = validation.Errors.FirstOrDefault();
                    return BasicOperationResult<User>.Fail(validationFailure.ErrorMessage, HttpStatusCode.BadRequest);
                }

                _userRepository.Create(userRequest);

                await _userRepository.SaveAsync();

                return BasicOperationResult<User>.Ok();
            }
            catch (Exception)
            {
                return BasicOperationResult<User>.Fail("Could Not Retrieve The User");
            }
        }

        /// <summary>
        /// Updates an existing user
        /// </summary>
        /// <returns>An implementation of <see cref="Task{IOperationResult}"/></returns>
        public async Task<IOperationResult<User>> Update(User userRequest)
        {
            try
            {
                if (userRequest == null)
                {
                    BasicOperationResult<User>.Fail("WrongInformation");
                }

                var userValidator = new UserValidator();
                var validation = await userValidator.ValidateAsync(userRequest);

                if (!validation.IsValid)
                {
                    var validationFailure = validation.Errors.FirstOrDefault();
                    return BasicOperationResult<User>.Fail(validationFailure.ErrorMessage, HttpStatusCode.BadRequest);
                }

                User foundUser = await _userRepository.FindAsync(user => user.Id == userRequest.Id);

                if (foundUser == null)
                {
                    BasicOperationResult<User>.Fail("User Not Found");
                }

                foundUser.LastName = userRequest.LastName;
                foundUser.FirstName = userRequest.FirstName;
                foundUser.Address = userRequest.Address;
                foundUser.City = userRequest.City;
                foundUser.Email = userRequest.Email;
                foundUser.Phone = userRequest.Phone;
                foundUser.State = userRequest.State;
                foundUser.Street = userRequest.Street;
                foundUser.Zip = userRequest.Zip;
                await _userRepository.SaveAsync();

                return BasicOperationResult<User>.Ok("User Updated Succesfully");
            }
            catch (Exception)
            {
                return BasicOperationResult<User>.Fail("Could Not Update The User");
            }
        }

        /// <summary>
        /// Remove a existing user
        /// </summary>
        /// <returns>An implementation of <see cref="Task{IOperationResult}"/></returns>
        public async Task<IOperationResult<User>> Delete(int userid)
        {
            try
            {
                User foundUser = await _userRepository.FindAsync(user => user.Id == userid);

                if (foundUser == null)
                {
                    BasicOperationResult<User>.Fail("User Not Found");
                }

                _userRepository.Remove(foundUser);
                await _userRepository.SaveAsync();

                return BasicOperationResult<User>.Ok("User Delete Succesfully");
            }
            catch (Exception)
            {
                return BasicOperationResult<User>.Fail("Could Not Delete The User");
            }
        }
    }
}
