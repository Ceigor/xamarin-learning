using Newtonsoft.Json;
using QuotesApp.Exception;
using QuotesApp.Service.Abstraction;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuotesApp.Service.Implementation
{
    class HttpService : IHttpService
    {
        private readonly HttpClient HttpClient;
        private readonly TimeSpan REQUEST_TIMEOUT_SECONDS = TimeSpan.FromSeconds(5);

        public HttpService()
        {
            HttpClient = new HttpClient() { Timeout = REQUEST_TIMEOUT_SECONDS };
        }

        public async Task<T> ExecuteGetRequest<T>(string url)
        {
            Debug.WriteLine("Connecting to url = " + url);
            var response = HttpClient.GetAsync(new Uri(url)).Result;
            Debug.WriteLine("when will return...");
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Sucessful!, waiting for content...");
                var responseData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseData);
            }
            else
                throw new HttpException(response.StatusCode);
        }
    }
}
