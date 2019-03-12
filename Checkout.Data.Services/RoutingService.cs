using System;

namespace Checkout.Data.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Checkout.Application.DTO;
    using ClientSDK;

    public class RoutingService : IRoutingService
    {
        Client client;

        public RoutingService()
        {
            client = new Client("http://localhost:4026");
        }

        public async Task<List<Route>> GetRoutes()
        {
            List<ClientSDK.DTOs.Route> routes = await client.GetRoutesAsync();
            
            return routes.MapToCheckoutDTO();
        }
    }
}
