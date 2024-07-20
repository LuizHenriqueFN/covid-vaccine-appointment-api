using System.Net;

namespace CVA.api.Responses
{
    public class DefaultResponses
    {
        public HttpStatusCode StatusCode { get; set; }

        public List<string> Messages { get; set; }

        public DefaultResponses(HttpStatusCode httpStatusCode, List<string> messages)
        {
            StatusCode = httpStatusCode;
            Messages = messages;
        }
    }
}
