
namespace Shared.Models
{
    public class ValidationResult<T>: ValidationResult where T : class
    {
        public T? ResultObject { get; set; }
        public ValidationResult(bool success, IList<string> errorMessage, T? resultObject=null): base(success, errorMessage)
        {
            ResultObject = resultObject;
        }

        public ValidationResult(bool success, string errorMessage, T? resultObject = null) : base(success, errorMessage)
        {
            ResultObject = resultObject;
        }

        public ValidationResult(bool success, T? resultObject = null) : base(success)
        {
            ResultObject = resultObject;
        }

        public ValidationResult(FluentValidation.Results.ValidationResult validationResult) : base(validationResult) 
        {
        }
    }
}