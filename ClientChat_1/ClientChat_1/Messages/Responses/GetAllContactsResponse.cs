using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ClientChat_1.Messages.Responses
{
    [Serializable]
    public class GetAllContactsResponse: HttpServerResponse
    {
        [JsonProperty(PropertyName = "contacts")]
        public List<string> Contacts;

        [JsonProperty(PropertyName = "requested_contacts")]
        public List<string> RequestedContacts;

        [JsonProperty(PropertyName = "not_confirmed_contacts")]
        public List<string> NotConfirmedContacts;
    }
}
