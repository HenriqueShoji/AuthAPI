namespace Auth_API.Middleware.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException() { }

        public NotFoundException(string message) : base(message) { }
    }
}
