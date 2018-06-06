using QuotesApp.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuotesApp.Service.Implementation
{
    class HttpService : IHttpService
    {
        private readonly HttpClient HttpClient;

        public HttpService()
        {
            HttpClient = new HttpClient();
        }

        public async Task<String> ExecuteGetRequest(string url)
        {
            string responseData = "";
            try
            {
                var response = await HttpClient.GetAsync(new Uri(url));
                if(response.IsSuccessStatusCode)
                {
                    responseData = await response.Content.ReadAsStringAsync();
                }
            }catch(System.Exception exception)
            {
                Debug.WriteLine(exception);
            }
            return responseData;
        }
    }
}
