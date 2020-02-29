using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Services
{
    public interface ICityDataService
    {
        Task<IEnumerable<City>> GetAllCities();
        Task<City> GetCityDetails(int cityId);
        Task<City> AddCity(City city);
        Task UpdateCity(City city);
        Task DeleteCity(int cityId);
    }
}
