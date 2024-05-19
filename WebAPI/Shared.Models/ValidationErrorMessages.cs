namespace Shared.Models
{
    public class ValidationErrorMessages
    {
        public const string MustBeAValidEmail ="Message";
        public static string MustNotBeEmpty (string fieldName) => $"{fieldName} must not be empty";
        public static string MustNotExceedLength (string fieldName, int maxLength) => $"{fieldName} must not exceed {maxLength} characters";
        public static string MustBeAtleastLength (string fieldName, int minLength) => $"{fieldName} must have a minimum of {minLength} characters";
        public const string EmailAndPasswordDoNotExist = "The email and password provided do not exist";
    }
}