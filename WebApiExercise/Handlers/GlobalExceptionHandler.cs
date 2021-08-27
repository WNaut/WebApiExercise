using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;
using Unity;
using WebApiExercise.App_Start;

namespace WebApiExercise.Handlers
{
    /// <summary>
    /// Handle exceptions globally for web api services
    /// Unknown exception type, pass through. 
    /// Let the framework deal with it.
    ///  Ultimately, it will be send down to the UI with a InternalServerError code
    /// and a generic "An error has occurred" message (unless in debug mode).
    /// </summary>
    /// <remarks>
    /// https://docs.microsoft.com/en-us/aspnet/web-api/overview/error-handling/exception-handling
    /// </remarks>
    public sealed class GlobalExceptionHandler : ExceptionHandler
    {
        private readonly IDictionary<string, Action<ExceptionHandlerContext>> _handlers = new ConcurrentDictionary<string, Action<ExceptionHandlerContext>>
        {
            [typeof(ArgumentException).Name] = context => HandleException(context, HttpStatusCode.BadRequest),
            [typeof(InvalidOperationException).Name] = context => HandleException(context, HttpStatusCode.BadRequest),
            [typeof(NullReferenceException).Name] = context => HandleException(context, HttpStatusCode.BadRequest),
            [typeof(AggregateException).Name] = context => HandleValidationException(context, HttpStatusCode.BadRequest),
            [typeof(Exception).Name] = context => HandleException(context, HttpStatusCode.BadRequest),
        };

        /// <inheritdoc />
        public override void Handle(ExceptionHandlerContext context)
        {
            string key = context.Exception.GetType().Name;
            if (_handlers.ContainsKey(key))
            {
                _handlers[key](context);
            }
        }

        private static void HandleException(ExceptionHandlerContext context, HttpStatusCode code)
        {
            IUnityContainer container = UnityConfig.GetConfigureContainer();
            HttpResponseMessage response = context.Request.CreateResponse(code, new { context.Exception.Message });

            context.Result = new ResponseMessageResult(response);
        }

        private static void HandleValidationException(ExceptionHandlerContext context, HttpStatusCode code)
        {
            IList<ValidationException> exceptions = (context.Exception as AggregateException)?.InnerExceptions.Cast<ValidationException>().ToList();

            if (!exceptions.Any())
            {
                return;
            }

            var modelState = new ModelStateDictionary();
            const string errorMessage = "Request is invalid";

            foreach (string memberName in exceptions.SelectMany(GetMemberNamesFor))
            {
                modelState.AddModelError(memberName, errorMessage);
            }

            var error = new HttpError(modelState, includeErrorDetail: true)
            {
                Message = errorMessage
            };

            context.Result = new ResponseMessageResult(context.Request.CreateErrorResponse(code, error));
        }

        private static IEnumerable<string> GetMemberNamesFor(ValidationException validationException)
        {
            return IsNullOrEmpty(validationException.ValidationResult.MemberNames) ? Enumerable.Empty<string>() : validationException.ValidationResult.MemberNames;
        }

        private static bool IsNullOrEmpty(IEnumerable<string> memberNames)
            => memberNames == null || !memberNames.Any();

        /// <inheritdoc />
        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }
    }
}