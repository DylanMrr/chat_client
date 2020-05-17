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
            int responseCode = 0;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";

            request.Headers.Add("JWT", authToken);
                
            string responseMessage = await Task.Run(async () =>
            {
                using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    responseCode = (int)response.StatusCode;
                    return await reader.ReadToEndAsync();
                }
            });

            return new HttpRequestResult(responseCode, responseMessage);
        }

    }
}
