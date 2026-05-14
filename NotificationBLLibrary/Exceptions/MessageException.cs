namespace NotificationBLLibrary.Exceptions
{

    public class MessageException : Exception
    {
            public string message;
            public MessageException(string message)
            {
                if (string.IsNullOrEmpty(message))
                {
                    message = "Message is null or empty";
                }
                else if (message.Length < 5)
                {
                    message = "Message is too short";
                }
                else if (message.Length > 160)
                {
                    message = "Message is too long";
                }
            }

            public override string Message => message;
    }
}