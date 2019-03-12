using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.WebAPI.DTOs
{
    public class Route
    {
        public int MerchantId { get; set; }
        public int LocationId { get; set; }
        public DateTime EstimatedDelivery { get; set; }
    }
}
