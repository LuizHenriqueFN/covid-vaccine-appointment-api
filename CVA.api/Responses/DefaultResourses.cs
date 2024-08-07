﻿using System.Net;

namespace CVA.api.Responses
{
    public class DefaultResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public List<string> Messages { get; set; }

        public DefaultResponse(HttpStatusCode httpStatusCode, List<string> messages)
        {
            StatusCode = httpStatusCode;
            Messages = messages;
        }
    }
}
