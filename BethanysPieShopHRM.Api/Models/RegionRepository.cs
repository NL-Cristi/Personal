using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;


namespace BethanysPieShopHRM.Api.Models
{
    public class RegionRepository : IRegionRepository
    {
        private readonly AppDbContext _appDbContext;

        public RegionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Region AddRegion(Region region)
        {
            var addedEntity = _appDbContext.Regions.Add(region);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public void DeleteRegion(int regionId)
        {
            var foundRegion = _appDbContext.Regions.FirstOrDefault(e => e.RegionId == regionId);
            if (foundRegion == null) return;

            _appDbContext.Regions.Remove(foundRegion);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Region> GetAllRegions()
        {
            return _appDbContext.Regions;
        }

        public Region GetRegionById(int regionId)
        {
            return _appDbContext.Regions.FirstOrDefault(c => c.RegionId == regionId);
        }

        public Region UpdateRegion(Region region)
        {
            var foundRegion = _appDbContext.Regions.FirstOrDefault(e => e.RegionId == region.RegionId);

            if (foundRegion != null)
            {
                foundRegion.RegionId = region.RegionId;
                foundRegion.Name = region.Name;
                _appDbContext.SaveChanges();

                return foundRegion;
            }

            return null;
        }
    }
}
