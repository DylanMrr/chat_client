using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;

namespace ClientChat_1.Network
{
    public class HttpNetworkService
    {
        //todo получить конфиги

        public async Task<HttpRequestResult> Post(string jsonMessage, string uri, string authToken = null)
        {
            var data = new StringContent(jsonMessage, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(authToken))
                    client.DefaultRequestHeaders.Add("JWT", authToken);

                var response = await client.PostAsync(uri, data);
                string result = response.Content.ReadAsStringAsync().Result;
                var code = response.StatusCode;
                return new HttpRequestResult((int)code, result);
            }
        }

        //todo исправить
        public async Task<HttpRequestResult> Get(string uri, string authToken)
        {
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(authToken))
                    client.DefaultRequestHeaders.Add("JWT", authToken);

                var response = await client.GetAsync(uri);
                string result = response.Content.ReadAsStringAsync().Result;
                var code = response.StatusCode;
                return new HttpRequestResult((int)code, result);
            }
        }

    }
}
