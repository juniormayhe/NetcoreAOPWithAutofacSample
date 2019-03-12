using System;

namespace Checkout.Application.DTO
{
    public class Route
    {
        public int MerchantId { get; set; }
        public int LocationId { get; set; }
        public DateTime EstimatedDelivery { get; set; }
    }
}
