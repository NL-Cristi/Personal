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

        public IEnumerable<Region> GetAllRegions()
        {
            return _appDbContext.Regions;
        }

        public Region GetRegionById(int regionId)
        {
            return _appDbContext.Regions.FirstOrDefault(c => c.RegionId == regionId);
        }
    }
}
