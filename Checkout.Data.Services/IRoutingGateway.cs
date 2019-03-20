using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using Checkout.Application.DTO;
using Checkout.Data.Services.Interceptors;

//[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Checkout.Data.Services
{
    //[Intercept(typeof(MerchantInterceptor))]
    public interface IRoutingGateway
    {
        Task<List<Route>> GetRoutes();

        Task<List<Route>> GetRoutesByMerchantId(int requestId, int merchantId);
    }
}