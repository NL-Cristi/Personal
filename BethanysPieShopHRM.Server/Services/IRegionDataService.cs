using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Services
{
    public interface IRegionDataService
    {
        Task<IEnumerable<Region>> GetAllRegions();
        Task<Region> GetRegionById(int regionId);
    }
}