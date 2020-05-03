using System;
using System.Collections.Generic;
using System.Text;
using ClientChat_1.Network;
using ClientChat_1.Messages;

namespace ClientChat_1.Managers
{
    public class NetworkManager
    {
        public JsonDecoder JsonDecoder { get; private set; }
        public HttpNetworkService HttpNetworkService { get; private set; }

        public NetworkManager()
        {
            JsonDecoder = new JsonDecoder();
            HttpNetworkService = new HttpNetworkService();
        }

        public async void Authorize(AuthorizeMessage authorizeMessage)
        {
            var result = await HttpNetworkService.Post(
                JsonDecoder.Serialize(authorizeMessage),
                ""
            );
        }
    }
}
