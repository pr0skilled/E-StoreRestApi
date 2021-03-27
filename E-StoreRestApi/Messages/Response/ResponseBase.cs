using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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
