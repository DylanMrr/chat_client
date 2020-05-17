using System;
using System.Collections.Generic;
using System.Text;

namespace ClientChat_1.Models
{
    [Serializable]
    public class MessagesModel: Messages.IMessage
    {
        public List<List<string>> Messages;
    }
}
