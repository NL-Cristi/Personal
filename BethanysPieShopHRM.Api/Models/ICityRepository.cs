using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Api.Models
{
    public interface ICityRepository
    {
        IEnumerable<City> GetAllCities();
        City GetCityById(int cityId);
        City AddCity(City city);
        City UpdateCity(City city);
        void DeleteCity(int cityId);
    }
}
