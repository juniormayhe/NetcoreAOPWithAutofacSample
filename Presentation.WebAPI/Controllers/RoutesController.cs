namespace Routing.Presentation.WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoFixture;

    using Microsoft.AspNetCore.Mvc;

    using Routing.Presentation.WebAPI.DTOs;

    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IFixture fixture;
        
        public RoutesController(IFixture fixture)
        {
            this.fixture = fixture;
        }

        // GET api/routes
        [HttpGet]
        public IEnumerable<Route> Get()
        {
            List<Route> routes = buildRoutes();
            return routes;
        }

        [HttpGet("id/{merchantId}")]
        public IEnumerable<Route> GetByMerchantId(int merchantId)
        {
            List<Route> routes = buildRoutes();
            return routes.Where(x => x.MerchantId == merchantId).ToList();
        }

        private List<Route> buildRoutes()
        {
            List<Route> routes = new List<Route>();
            
            routes.AddRange(this.fixture.Build<Route>().With(x => x.MerchantId, 1).CreateMany(5));
            routes.AddRange(this.fixture.Build<Route>().With(x => x.MerchantId, 2).CreateMany(5));
            routes.AddRange(this.fixture.Build<Route>().With(x => x.MerchantId, 3).CreateMany(5));
            routes.AddRange(this.fixture.Build<Route>().With(x => x.MerchantId, 4).CreateMany(5));
            routes.AddRange(this.fixture.Build<Route>().With(x => x.MerchantId, 5).CreateMany(5));
            return routes;
        }
    }
}
