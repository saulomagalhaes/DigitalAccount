namespace WebApi.Models.Error
{
    public class CustomValidationFailure
    {
        public CustomValidationFailure(string propetyName, string errorMessage)
        {
            PropertyName = propetyName;
            ErrorMessage = errorMessage;

        }
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
