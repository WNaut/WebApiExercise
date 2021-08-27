using Core.Contracts;
using Core.Models;
using FluentValidation;

namespace Core.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        internal UserValidator()
        {
            RuleFor(p => p.FirstName)
             .NotEmpty()
             .WithMessage("'FirstName' is required")
             .WithErrorCode("400")
             .MaximumLength(50)
             .WithMessage("'FirstName' 50 must have less than 50 characters")
             .WithErrorCode("400");

            RuleFor(p => p.LastName)
             .NotEmpty()
             .WithMessage("'LastName' is required")
             .WithErrorCode("400")
             .MaximumLength(50)
             .WithMessage("'LastName' 50 must have less than 50 characters")
             .WithErrorCode("400");

            RuleFor(p => p.Address)
             .NotEmpty()
             .WithMessage("'Address' is required")
             .WithErrorCode("400")
             .MaximumLength(50)
             .WithMessage("'Address' 50 must have less than 50 characters")
             .WithErrorCode("400");

            RuleFor(p => p.City)
             .NotEmpty()
             .WithMessage("'City' is required")
             .WithErrorCode("400")
             .MaximumLength(50)
             .WithMessage("'City' 50 must have less than 50 characters")
             .WithErrorCode("400");

            RuleFor(p => p.City)
             .NotEmpty()
             .WithMessage("'City' is required")
             .WithErrorCode("400")
             .MaximumLength(50)
             .WithMessage("'City' 50 must have less than 50 characters")
             .WithErrorCode("400");

            RuleFor(p => p.Email)
             .NotEmpty()
             .WithMessage("'Email' is required")
             .WithErrorCode("400")
             .MaximumLength(50)
             .WithMessage("'Email' 50 must have less than 50 characters")
             .WithErrorCode("400")
             .EmailAddress()
             .WithMessage("'Email' is not valid");

            RuleFor(p => p.Phone)
             .NotEmpty()
             .WithMessage("'Phone' is required")
             .WithErrorCode("400")
             .MaximumLength(50)
             .WithMessage("'Phone' 50 must have less than 50 characters")
             .WithErrorCode("400");

            RuleFor(p => p.State)
             .NotEmpty()
             .WithMessage("'State' is required")
             .WithErrorCode("400")
             .MaximumLength(50)
             .WithMessage("'State' 50 must have less than 50 characters")
             .WithErrorCode("400");

            RuleFor(p => p.Street)
             .NotEmpty()
             .WithMessage("'Street' is required")
             .WithErrorCode("400")
             .MaximumLength(50)
             .WithMessage("'Street' 50 must have less than 50 characters")
             .WithErrorCode("400");

            RuleFor(p => p.Zip)
             .NotEmpty()
             .WithMessage("'Zip' is required")
             .WithErrorCode("400")
             .MaximumLength(50)
             .WithMessage("'Zip' 50 must have less than 50 characters")
             .WithErrorCode("400");
        }
    }
}
