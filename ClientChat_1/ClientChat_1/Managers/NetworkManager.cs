using System;
using System.Collections.Generic;
using System.Text;
using ClientChat_1.Network;
using ClientChat_1.Messages;
using ClientChat_1.Messages.Responses;
using ClientChat_1.Configs;
using System.Threading.Tasks;

namespace ClientChat_1.Managers
{
    public class NetworkManager
    {
        public JsonDecoder JsonDecoder { get; private set; }
        public HttpNetworkService HttpNetworkService { get; private set; }

        private string baseLobbyUrl;
        //private string websocketUrl;

        public NetworkManager(JsonDecoder jsonDecoder)
        {
            this.JsonDecoder = jsonDecoder;
            HttpNetworkService = new HttpNetworkService();
            baseLobbyUrl = string.Concat(NetworkConfig.LobbyProtocol,
                NetworkConfig.MasterAdress,
                NetworkConfig.ServerPort); 
        }

        public async Task<AuthResponse> Login(AuthMessage authorizeMessage)
        {
            var result = await HttpNetworkService.Post(
                JsonDecoder.Serialize(authorizeMessage),
                string.Concat(baseLobbyUrl, NetworkConfig.LoginUrl)
            );
            var response = new AuthResponse();
            if (result.Status == 200)
            {
                response = JsonDecoder.Deserialize<AuthResponse>(result.Message, MessagesTypes.LoginResponse);
                response.IsSuccesful = true;
            }
            else
            {
                //todo
            }
            return response;
        }

        public async Task GetContacts()
        {

        }

        public async Task<RegisterResponse> Register(RegisterMessage authorizeMessage)
        {
            var result = await HttpNetworkService.Post(
                JsonDecoder.Serialize(authorizeMessage),
                string.Concat(baseLobbyUrl, NetworkConfig.RegisterUrl)
            );
            return new RegisterResponse();
        }
    }
}
