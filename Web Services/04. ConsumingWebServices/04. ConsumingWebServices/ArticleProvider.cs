using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _04.ConsumingWebServices
{
    public class ArticleProvider
    {
        private HttpClient client;

        public ArticleProvider(string url)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public AllArticles GetArticles(string queryString)
        {
            HttpResponseMessage articles = client.GetAsync(string.Format("v1/articles/search.json?q={0}", queryString)).Result;

            if (articles.IsSuccessStatusCode)
            {
                AllArticles searchResult = articles.Content.ReadAsAsync<AllArticles>().Result;
                return searchResult;
            }
            else
            {
                throw new HttpRequestException(string.Format("Get faild! Statuse code: {0}. Reason: {1}", (int)articles.StatusCode, articles.ReasonPhrase));
            }
        }

        public AllArticles GetArticles(string queryString, int count)
        {
            HttpResponseMessage articles = client.GetAsync(string.Format("v1/articles/search.json?q={0}&count={1}", queryString, count)).Result;

            if (articles.IsSuccessStatusCode)
            {
                AllArticles searchResult = articles.Content.ReadAsAsync<AllArticles>().Result;
                return searchResult;
            }
            else
            {
                throw new HttpRequestException(string.Format("Get faild! Statuse code: {0}. Reason: {1}", (int)articles.StatusCode, articles.ReasonPhrase));
            }
        }
    }
}
