namespace NotificationBLLibrary.Exceptions
{

    public class InvalidMailIdException : Exception
    {
        private string message = string.Empty;

        public InvalidMailIdException()
        {
            message = "Email ID is not in a valid format. Please check and try again.";
        }

        public override string Message => message;
    }
}