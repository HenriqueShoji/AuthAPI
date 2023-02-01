namespace Auth_API.Middleware.Exceptions
{
    [Serializable]
    public class DuplicateDataException : Exception
    {
        public DuplicateDataException() { }
        public DuplicateDataException(string message) : base(message) { }
    }
}
