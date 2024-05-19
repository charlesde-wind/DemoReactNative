
namespace Shared.Models
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public IList<string> ErrorMessage { get; set; } = new List<string>();
        public ValidationResult(FluentValidation.Results.ValidationResult validationResult) {
            IsValid = validationResult.IsValid;
            ErrorMessage = validationResult.Errors.Select(x => $"{x.PropertyName}: {x.ErrorMessage}").ToList();
        }

        public ValidationResult(bool isValid, string errorMessage)
        {
            IsValid = isValid;
            ErrorMessage = new List<string>() { errorMessage };
        }

        public ValidationResult(bool isValid, IList<string> errorMessages)
        {
            IsValid = isValid;
            ErrorMessage = errorMessages;
        }

        public ValidationResult(bool isValid)
        {
            IsValid = isValid;
        }
    }
}