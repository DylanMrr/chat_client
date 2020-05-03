using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ClientChat_1.Messages;

namespace ClientChat_1.Network
{
    public class JsonDecoder
    {
        private readonly Dictionary<string, Func<string, IMessage>> deserializedMessage = new Dictionary<string, Func<string, IMessage>>()
        {

        };

        public string Serialize<T>(T request) where T : IMessage
        {
            return JsonConvert.SerializeObject(request);
        }

        /*public T Deserialized<T>(string response, string type = "") where T : IMessage
        {
            if (type == "")
            {
                
            }
        }*/
    }
}
