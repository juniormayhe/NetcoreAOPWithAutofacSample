using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Checkout.WebApplication.Models;

namespace Checkout.WebApplication.Controllers
{
    using Data.Services;

    public class HomeController : Controller
    {
        private readonly IRoutingService routingService;

        public HomeController(IRoutingService routingService)
        {
            this.routingService = routingService;
        }

        public async Task<IActionResult> Index()
        {
            var routesFromRoutingClient = await routingService.GetRoutes();
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
