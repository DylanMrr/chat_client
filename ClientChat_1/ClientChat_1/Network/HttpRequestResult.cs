using System;
using System.Collections.Generic;
using System.Text;

namespace ClientChat_1.Network
{
    public class HttpRequestResult
    {
        public int Status { get; private set; }
        public string Message { get; private set; }

        public HttpRequestResult(int status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
