using System;
using System.Net.Http;

namespace ClientSDK
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ClientSDK.DTOs;
    using Newtonsoft.Json;

    public class Client
    {
        private readonly string baseUrl;

        /// <summary>
        /// something as http://localhost:4026
        /// </summary>
        /// <param name="baseUrl"></param>
        public Client(string baseUrl)
        {
            this.baseUrl = $"{baseUrl}/api/routes";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Route>> GetRoutesAsync()
        {
            var routes = new List<Route>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var httpResponseMessage = await client.GetAsync(this.baseUrl);
                    var result = await httpResponseMessage.Content.ReadAsStringAsync();
                    
                    routes = JsonConvert.DeserializeObject<List<Route>>(result);
                }
                catch (HttpRequestException e)
                {
                    System.Diagnostics.Trace.WriteLine("\nException Caught!");
                    System.Diagnostics.Trace.WriteLine("Message :{0} ", e.Message);
                }
            }

            return routes;
        }
    }
}
