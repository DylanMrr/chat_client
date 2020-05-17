using System;
using System.Collections.Generic;
using System.Text;
using ClientChat_1.Network;

namespace ClientChat_1.Managers
{
    public class Managers
    {
        public NetworkManager NetworkManager { get; private set; }
        public Session Session { get; private set; }
        public FileManager FileManager { get; private set; }
        public MessagesManager MessagesManager { get; private set; }
        public JsonDecoder JsonDecoder { get; private set; }

        public LogWriter LogWriter { get; private set; }

        public Managers()
        {
            JsonDecoder = new JsonDecoder();
            NetworkManager = new NetworkManager(JsonDecoder);
            Session = new Session();
            FileManager = new FileManager();
            MessagesManager = new MessagesManager(FileManager, JsonDecoder);
            LogWriter = new LogWriter("Creating log writer");
        }
    }
}
