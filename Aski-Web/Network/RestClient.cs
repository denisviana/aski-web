using System;
using System.Net.Http;

namespace Aski_Web.Network
{
    public class RestClient : HttpClient
    {

        private static HttpClient instance;

        private RestClient()
        {

        }

        public static HttpClient getInstance(){
            if (instance == null){
                instance = new HttpClient
                {
                    BaseAddress = new Uri("https://aski-api.azurewebsites.net/")
                };
                instance.DefaultRequestHeaders.Accept.Clear();
                instance.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }

            return instance;
        }
    }
}
