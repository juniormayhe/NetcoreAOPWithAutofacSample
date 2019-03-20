namespace Checkout.Data.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Checkout.Application.DTO;

    using Routing.ClientSDK;

    public class RoutingGateway : IRoutingGateway
    {
        RoutingClient routingClient;

        public RoutingGateway()
        {
            routingClient = new RoutingClient("http://localhost:4026");
        }

        public async Task<List<Route>> GetRoutes()
        {
            List<Routing.ClientSDK.DTOs.Route> routes = await routingClient.GetRoutesAsync();
            
            return routes.MapToCheckoutDTO();
        }

        public async Task<List<Route>> GetRoutesByMerchantId(int requestId, int merchantId)
        {
            List<Routing.ClientSDK.DTOs.Route> routes = await routingClient.GetRoutesByMerchantIdAsync(merchantId);

            return routes.ToList().MapToCheckoutDTO();
        }
    }
}
