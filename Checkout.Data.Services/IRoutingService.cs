using System.Collections.Generic;
using System.Threading.Tasks;
using Checkout.Application.DTO;

namespace Checkout.Data.Services
{
    public interface IRoutingService
    {
        Task<List<Route>> GetRoutes();
    }
}