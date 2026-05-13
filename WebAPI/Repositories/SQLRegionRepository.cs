using WebAPI.Models.Domain;
using WebAPI.Models.DTO;
using WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly WebApiDbContext dbContext;
        public SQLRegionRepository(WebApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Region>> GetAllRegionsAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetRegionByIdAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> AddRegionAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region; 
        }

        public async Task<Region?> UpdateRegionAsync(Guid id, Region region)
        {
            var currRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (currRegion == null)
            {
                return null;
            }

            currRegion.Code = region.Code;
            currRegion.Name = region.Name;
            currRegion.RegionImageURL = region.RegionImageURL;

            await dbContext.SaveChangesAsync();
            return currRegion;
        }

        public async Task<Region?> DeleteRegionAsync(Guid id)
        {
            var currRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (currRegion == null)
            {
                return null;
            }

            dbContext.Regions.Remove(currRegion);
            await dbContext.SaveChangesAsync();
            return currRegion;
        }
    
    }
}