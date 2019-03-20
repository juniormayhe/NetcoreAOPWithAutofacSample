namespace Checkout.WebApplication.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Checkout.WebApplication.Models;

    using Data.Services;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly IRoutingGateway _routingGateway;

        public HomeController(IRoutingGateway routingGateway)
        {
            this._routingGateway = routingGateway;
        }

        public async Task<IActionResult> Index()
        {
            var routesFromRoutingClient = await _routingGateway.GetRoutes();
            ViewData["routes"] = routesFromRoutingClient;
            return View();
        }

        public async Task<IActionResult> IndexById(int merchantId)
        {
            var routesFromRoutingClient = await _routingGateway.GetRoutesByMerchantId(0, 2);
            ViewData["routes"] = routesFromRoutingClient;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
