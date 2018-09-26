using System;
using System.Net.Http;

namespace Aski_Web.Network
{
    public class RestClient : HttpClient
    {

        private static RestClient instance;

        private RestClient()
        {
            instance = new RestClient
            {
                BaseAddress = new Uri("https://aski-api.azurewebsites.net/")
            };
            instance.DefaultRequestHeaders.Accept.Clear();
            instance.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static RestClient getInstance(){
            if (instance == null)
                instance = new RestClient();

            return instance;
        }
    }
}
