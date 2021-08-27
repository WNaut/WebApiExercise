using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiExercise.Core.Contracts;
using WebApiExercise.Core.Models;

namespace WebApiExercise.Core.Managers
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
            catch (Exception e)
            {
                return BasicOperationResult<ICollection<User>>.Fail("CouldNotRetrieveTheUsers");
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
                    BasicOperationResult<User>.Fail("UserNotFound");
                }

                return BasicOperationResult<User>.Ok(foundUser);
            }
            catch (Exception e)
            {
                return BasicOperationResult<User>.Fail("CouldNotRetrieveTheUser");
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
                _userRepository.Create(userRequest);

                await _userRepository.SaveAsync();

                return BasicOperationResult<User>.Ok();
            }
            catch (Exception e)
            {
                return BasicOperationResult<User>.Fail("CouldNotRetrieveTheUser");
            }
        }

        /// <summary>
        /// Updates an existing user
        /// </summary>
        /// <returns>An implementation of <see cref="Task{IOperationResult}"/></returns>
        public async Task<IOperationResult<User>> Update(User userRequest)
        {
            if (userRequest == null)
            {
                BasicOperationResult<User>.Fail("WrongInformation");
            }

            try
            {
                User foundUser = await _userRepository.FindAsync(user => user.Id == userRequest.Id);

                if (foundUser == null)
                {
                    BasicOperationResult<User>.Fail("UserNotFound");
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

                return BasicOperationResult<User>.Ok("UserUpdatedSuccesfully");
            }
            catch (Exception e)
            {
                return BasicOperationResult<User>.Fail("CouldNotUpdateTheUser");
            }
        }

        /// <summary>
        /// Remove a existing user
        /// </summary>
        /// <returns>An implementation of <see cref="Task{IOperationResult}"/></returns>
        public async Task<IOperationResult<User>> Delete(User userRequest)
        {
            if (userRequest == null)
            {
                BasicOperationResult<User>.Fail("WrongInformation");
            }

            try
            {
                User foundUser = await _userRepository.FindAsync(user => user.Id == userRequest.Id);

                if (foundUser == null)
                {
                    BasicOperationResult<User>.Fail("UserNotFound");
                }

                _userRepository.Remove(foundUser);
                await _userRepository.SaveAsync();

                return BasicOperationResult<User>.Ok("UserUpdatedSuccesfully");
            }
            catch (Exception e)
            {
                return BasicOperationResult<User>.Fail("CouldNotUpdateTheUser");
            }
        }
    }
}
