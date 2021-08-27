using System.Net;
using Core.Contracts;

namespace Core.Models
{
    public class BasicOperationResult<T> : IOperationResult<T>
    {
        private BasicOperationResult(string message, bool success, T entity, HttpStatusCode statusCode)
        {
            Message = message;
            Success = success;
            Entity = entity;
            StatusCode = statusCode;
        }

        /// <summary>
        /// Represents the message operation result
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Represents the detailed message operation result
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Represents if the operation was successful
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// Represents the operation result
        /// </summary>
        public T Entity { get; }


        /// <summary>
        /// Creates an instance of <see cref="BasicOperationResult{T}"/> successful with the <see cref="T"/> default value
        /// </summary>
        /// <returns>An instance of <see cref="BasicOperationResult{T}"/> successful</returns>
        public static BasicOperationResult<T> Ok()
        {
            return new BasicOperationResult<T>("", true, default, HttpStatusCode.OK);
        }

        /// <summary>
        /// Creates an instance of <see cref="BasicOperationResult{T}"/> successfully
        /// </summary>
        /// <param name="entity">An instance of <see cref="T"/></param>
        /// <returns>An instance of <see cref="BasicOperationResult{T}"/> successful</returns>
        public static BasicOperationResult<T> Ok(T entity)
            => new BasicOperationResult<T>("", true, entity, HttpStatusCode.OK);

        /// <summary>
        /// Creates an instance of <see cref="BasicOperationResult{T}"/> successfully
        /// </summary>
        /// <param name="entity">An instance of <see cref="T"/></param>
        /// <param name="message">An <see cref="string"/> value that represents a error message</param>
        /// <returns>An instance of <see cref="BasicOperationResult{T}"/> successful</returns>
        public static BasicOperationResult<T> Ok(T entity, string message)
            => new BasicOperationResult<T>(message, true, entity, HttpStatusCode.OK);

        /// <summary>
        /// Creates an instance of <see cref="BasicOperationResult{T}"/> successfully
        /// </summary>
        /// <param name="message">An <see cref="string"/> value that represents a error message</param>
        /// <returns>An instance of <see cref="BasicOperationResult{T}"/> successful</returns>
        public static BasicOperationResult<T> Ok(string message)
            => new BasicOperationResult<T>(message, true, default, HttpStatusCode.OK);

        /// <summary>
        /// Creates an instance of <see cref="BasicOperationResult{T}"/> for fail case.
        /// </summary>
        /// <param name="message">An <see cref="string"/> value that represents a error message</param>
        /// <returns>An instance of <see cref="BasicOperationResult{T}"/> failed</returns>
        public static BasicOperationResult<T> Fail(string message)
            => new BasicOperationResult<T>(message, false, default, HttpStatusCode.BadRequest);

        /// <summary>
        /// Creates an instance of <see cref="BasicOperationResult{T}"/> for fail case.
        /// </summary>
        /// <param name="message">An <see cref="string"/> value that represents a error message</param>
        /// <param name="statusCode">An <see cref="HttpStatusCode"/> value that represents a status code</param>
        /// <returns>An instance of <see cref="BasicOperationResult{T}"/> failed</returns>
        public static BasicOperationResult<T> Fail(string message, HttpStatusCode statusCode)
            => new BasicOperationResult<T>(message, false, default, statusCode);
    }
}
