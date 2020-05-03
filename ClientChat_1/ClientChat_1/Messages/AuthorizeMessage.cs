using System;
using System.Collections.Generic;
using System.Text;

namespace ClientChat_1.Messages
{
    [Serializable]
    public class AuthorizeMessage :IMessage
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
