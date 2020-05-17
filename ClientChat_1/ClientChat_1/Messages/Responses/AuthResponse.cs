using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ClientChat_1.Messages.Responses
{
    [Serializable]
    public class AuthResponse: HttpServerResponse
    {
        [JsonProperty(PropertyName = "result")]
        public string Result;
        [JsonProperty(PropertyName = "jwt")]
        public string Jwt;
    }
}
