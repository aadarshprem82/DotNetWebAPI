using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Domain;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Some Region",
                    Code = "SRE",
                    RegionImageURL = "someurl.com"
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Some Other Region",
                    Code = "SOE",
                    RegionImageURL = "someotherurl.com"
                }
            };
            return Ok(regions);
        }
    }
}