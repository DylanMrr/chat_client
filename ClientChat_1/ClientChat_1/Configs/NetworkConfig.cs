using System;
using System.Collections.Generic;
using System.Text;

namespace ClientChat_1.Configs
{
    public class NetworkConfig
    {
        public const string LobbyProtocol = "http://";
        public const string WebsocketProtocol = "ws://";
        public const string MasterAdress = "192.168.0.102:";
        //public const string MasterAdress = "localhost:";
        public const string ServerPort = "8888";

        public const string LoginUrl = "/login";
        public const string RegisterUrl = "/register";
    }
}
