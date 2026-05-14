namespace NotificationBLLibrary.Exceptions
{

    public class InvalidPhoneNumberException : Exception
    {
        private string message = string.Empty;

        public InvalidPhoneNumberException()
        {
            message = "Phone Number is not in a valid format. Please check and try again.";
        }

        public override string Message => message;
    }
}