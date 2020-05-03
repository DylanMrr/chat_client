using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ClientChat_1.Network
{
    public class HttpNetworkService
    {
        //todo получить конфиги


        public async Task<HttpRequestResult> Post(string jsonMessage, string uri, string authToken = null)
        {
            int responseCode = 0;
            string responseMessage = await Task.Run(async () =>
            {
                byte[] messageBytes = new UTF8Encoding().GetBytes(jsonMessage);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "POST";
                request.ContentLength = messageBytes.Length;
                request.ContentType = "application/json";

                if (!string.IsNullOrEmpty(authToken))
                {
                    request.Headers.Add("JWT", authToken);
                }

                using (Stream requestBody = request.GetRequestStream())
                {
                    await requestBody.WriteAsync(messageBytes, 0, messageBytes.Length);
                }

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

        public async Task<HttpRequestResult> Get(string uri, string authToken)
        {
            int responseCode = 0;
            string responseMessage = await Task.Run(async () =>
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "GET";

                request.Headers.Add("JWT", authToken);

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
