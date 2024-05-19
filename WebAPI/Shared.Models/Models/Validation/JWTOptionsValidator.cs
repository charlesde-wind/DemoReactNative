using AuthProvider.Configuration;
using FluentValidation;

namespace Shared.Models.Models.Validation
{
    internal class JWTOptionsValidator : AbstractValidator<JWTOptions>
    {
        public JWTOptionsValidator()
        {
            RuleFor(x => x.Audience)
                .NotEmpty()
                    .WithMessage(x=>ValidationErrorMessages.MustNotBeEmpty(nameof(x.Audience)));
            
            RuleFor(x => x.SigningKey)
                .NotEmpty()
                    .WithMessage(x => ValidationErrorMessages.MustNotBeEmpty(nameof(x.SigningKey)));

            RuleFor(x => x.Issuer)
                .NotEmpty()
                    .WithMessage(x => ValidationErrorMessages.MustNotBeEmpty(nameof(x.Issuer)));

        }
    }
}
