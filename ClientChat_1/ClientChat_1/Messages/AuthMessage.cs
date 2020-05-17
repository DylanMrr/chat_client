using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ClientChat_1.Messages
{
    [Serializable]
    public class AuthMessage :IMessage
    {
        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
