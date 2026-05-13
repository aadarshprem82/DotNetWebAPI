using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly WebApiDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        public RegionsController(WebApiDbContext dbContext, IRegionRepository regionRepository)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regionsDomain = await regionRepository.GetAllRegionsAsync();

            var regionsDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                   Id = regionDomain.Id,
                   Code = regionDomain.Code,
                   Name = regionDomain.Name,
                   RegionImageURL = regionDomain.RegionImageURL
                });
            }

            return Ok(regionsDto);
            // var regions = new List<Region>
            // {
            //     new Region
            //     {
            //         Id = Guid.NewGuid(),
            //         Name = "Some Region",
            //         Code = "SRE",
            //         RegionImageURL = "someurl.com"
            //     },
            //     new Region
            //     {
            //         Id = Guid.NewGuid(),
            //         Name = "Some Other Region",
            //         Code = "SOE",
            //         RegionImageURL = "someotherurl.com"
            //     }
            // };
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            // var regionDomain = dbContext.Regions.Find(id);
            var regionDomain = await regionRepository.GetRegionByIdAsync(id);
            
            if (regionDomain == null)
            {
                return NotFound();
            }

            var regionDto = new RegionDto()
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageURL = regionDomain.RegionImageURL
            };

            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegion([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            var regionDomainModel = new Region()
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageURL = addRegionRequestDto.RegionImageURL
            };

            regionDomainModel = await regionRepository.AddRegionAsync(regionDomainModel);

            var regionDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageURL = regionDomainModel.RegionImageURL
            };

            return CreatedAtAction(nameof(AddRegion), new {id = regionDto.Id}, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDomainModel = await regionRepository.UpdateRegionAsync(id, new Region()
            {
                Code = updateRegionRequestDto.Code,
                Name = updateRegionRequestDto.Name,
                RegionImageURL = updateRegionRequestDto.RegionImageURL
            });

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            var regionDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageURL = regionDomainModel.RegionImageURL
            };

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteRegionAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // return NoContent();
            var regionDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageURL = regionDomainModel.RegionImageURL
            };
            return Ok(regionDto);
        }
    }
}