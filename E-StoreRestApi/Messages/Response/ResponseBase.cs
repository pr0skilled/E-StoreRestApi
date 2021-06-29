using System.Collections.Generic;
using System.Net;

namespace E_StoreRestApi.Messages.Response
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            Messages = new List<string>();
        }

        public List<string> Messages { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
