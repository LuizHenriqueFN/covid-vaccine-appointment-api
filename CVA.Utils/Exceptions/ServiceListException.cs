using System.Runtime.Serialization;

namespace CVA.Utils.Exceptions
{
    [Serializable]
    public class ServiceListException : Exception
    {
        public List<string> Messages { get; set; } = new List<string>();

        public ServiceListException() { }

        public ServiceListException(IEnumerable<string> messages)
        {
            Messages = messages.ToList();
        }

        protected ServiceListException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
