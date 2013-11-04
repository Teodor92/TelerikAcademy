using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JustWeather.Data
{
    public class HttpRequester
    {
        public async Task<HttpResponseMessage> Post(string url, object data, string mediaValueType = "application/json")
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            var jsonData = JsonConvert.SerializeObject(data);
            request.Content = new StringContent(jsonData);

            var client = new HttpClient();
            return await client.SendAsync(request);
        }

        internal async static Task<T> Get<T>(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = new HttpClient();
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<T>(content);
            return responseData;
        }
    }
}
