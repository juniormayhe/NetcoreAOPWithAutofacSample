using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebAPI.DTOs;
using Snappy;
namespace Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IFixture fixture;
        Stream stream = new MemoryStream();
        private string compressedString = "";
        public void Compress()
        {
            string computedHash="";
            var ms = new MemoryStream();
            using (var ss = new Snappy.SnappyStream(ms, CompressionMode.Compress, true))
            {
                var writer = new StreamWriter(ss);
                writer.WriteLine("Hello Hello Hello Hello Hello");  
            }
            
            var compressed = Encoding.UTF8.GetString(ms.ToArray());

            ms.Position = 0;
            using (var decoder = new SnappyStream(ms, CompressionMode.Decompress))
            {
                using (var reader = new StreamReader(decoder)) { 
                    var uncompressed = reader.ReadToEnd();
                }

            }



        }

        public string ToString(Stream stream)
        {
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();
            return text;
        }

        public Stream ToStream(string s)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(s));
        }

        public RoutesController(IFixture fixture)
        {
            this.fixture = fixture;
            Compress();
        }

        // GET api/routes
        [HttpGet]
        public IEnumerable<Route> Get(string compressedHash)
        {
            

            using (var stream = ToStream(compressedHash))
            {
                using (var decompressor = new SnappyStream(stream, CompressionMode.Decompress))
                {

                }
            }
            

            List<Route> routes = new List<Route>();
            routes.AddRange(fixture.Build<Route>().With(MerchantId => 1).CreateMany(5));
            routes.AddRange(fixture.Build<Route>().With(MerchantId => 2).CreateMany(5));
            routes.AddRange(fixture.Build<Route>().With(MerchantId => 3).CreateMany(5));
            routes.AddRange(fixture.Build<Route>().With(MerchantId => 4).CreateMany(5));
            routes.AddRange(fixture.Build<Route>().With(MerchantId => 5).CreateMany(5));
            return routes;
        }

        //// GET api/routes/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/routes
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/routes/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/routes/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }

    
}
