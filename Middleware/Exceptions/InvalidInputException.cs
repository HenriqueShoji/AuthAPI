namespace Auth_API.Middleware.Exceptions
{
    [Serializable]
    public class InvalidInputException : Exception
    {
        public InvalidInputException() { }

        public InvalidInputException(string message) : base(message) { }
    }
}
