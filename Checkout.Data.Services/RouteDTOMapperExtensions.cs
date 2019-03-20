namespace Checkout.Data.Services
{
    using System.Collections.Generic;

    using System.Linq;

    public static class RouteDTOMapperExtensions
    {
        public static List<Checkout.Application.DTO.Route> MapToCheckoutDTO(this List<Routing.ClientSDK.DTOs.Route> routesFromClient)
        {
            List<Checkout.Application.DTO.Route> routesForCheckout = routesFromClient
                .Select(x => new Checkout.Application.DTO.Route
                {
                    EstimatedDelivery = x.EstimatedDelivery,
                    LocationId = x.LocationId,
                    MerchantId = x.MerchantId
                }).ToList();

            return routesForCheckout;
        }
    }
}
