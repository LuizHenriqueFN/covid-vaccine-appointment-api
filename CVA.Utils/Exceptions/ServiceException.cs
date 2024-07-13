namespace CVA.Utils.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException() { }

        public ServiceException(string message) : base(message) { }

        public ServiceException(string message, Exception exception) : base(message, exception) { }
    }
}
