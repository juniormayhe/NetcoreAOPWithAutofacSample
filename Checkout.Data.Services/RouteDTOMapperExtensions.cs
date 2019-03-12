using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Data.Services
{
    using System.Linq;

    public static class RouteDTOMapperExtensions
    {
        public static List<Checkout.Application.DTO.Route> MapToCheckoutDTO(this List<ClientSDK.DTOs.Route> routesFromClient)
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
