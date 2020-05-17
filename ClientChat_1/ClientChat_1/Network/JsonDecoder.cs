using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ClientChat_1.Messages;
using ClientChat_1.Messages.Responses;

namespace ClientChat_1.Network
{
    public class JsonDecoder
    {
        private readonly Dictionary<string, Func<string, IMessage>> deserializedMessage = new Dictionary<string, Func<string, IMessage>>()
        {
            [MessagesTypes.LoginResponse] = new Func<string, IMessage>(LoginResponse),
            [MessagesTypes.MessagesModel] = new Func<string, IMessage>(MessagesModel)
        };

        public string Serialize<T>(T request) where T : IMessage
        {
            return JsonConvert.SerializeObject(request);
        }

        public T Deserialize<T>(string response, string type) where T : IMessage
        {
            return (T)deserializedMessage[type].Invoke(response);
        }

        private static AuthResponse LoginResponse(string response)
        {
            return JsonConvert.DeserializeObject<AuthResponse>(response);
        }

        private static Models.MessagesModel MessagesModel(string response)
        {
            return JsonConvert.DeserializeObject<Models.MessagesModel>(response);
        }
    }
}
