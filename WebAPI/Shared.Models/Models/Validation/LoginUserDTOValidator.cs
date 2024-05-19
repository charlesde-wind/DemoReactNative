using AuthProvider.Models.DTO;
using FluentValidation;
using Shared.Models.Constants;

namespace Shared.Models.Models.Validation
{
    internal class LoginUserDTOValidator : AbstractValidator<LoginUserDTO>
    {
        public LoginUserDTOValidator() {
            RuleFor(x => x.Email)
                .NotEmpty()
                    .WithMessage(x => ValidationErrorMessages.MustNotBeEmpty(nameof(x.Email)))
                .EmailAddress()
                    .WithMessage(ValidationErrorMessages.MustBeAValidEmail);

            RuleFor(x => x.Password)
                .NotEmpty()
                    .WithMessage(x => ValidationErrorMessages.MustNotBeEmpty(nameof(x.Password)))
                .MinimumLength(FieldValidationRules.MinimumLengthOfPassword)
                    .WithMessage(x => ValidationErrorMessages.MustBeAtleastLength(
                        nameof(x.Password),
                    FieldValidationRules.MinimumLengthOfPassword))
                .MaximumLength(FieldValidationRules.MaximumLengthOfPassword)
                    .WithMessage(x => ValidationErrorMessages.MustNotExceedLength(
                        nameof(x.Password),
                        FieldValidationRules.MaximumLengthOfPassword));
        }
    }
}
