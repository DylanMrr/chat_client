using System;
using System.Collections.Generic;
using System.Text;

namespace ClientChat_1.Managers
{
    public class Managers
    {
        public NetworkManager NetworkManager { get; private set; }

        public Managers()
        {
            NetworkManager = new NetworkManager();
        }
    }
}
