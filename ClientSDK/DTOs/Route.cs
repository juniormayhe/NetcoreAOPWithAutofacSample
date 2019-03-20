namespace Routing.ClientSDK.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Route
    {
        public int MerchantId { get; set; }
        public int LocationId { get; set; }
        public DateTime EstimatedDelivery { get; set; }
    }
}
