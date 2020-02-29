using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Api.Models
{
    public class CityRepository : ICityRepository
    {

        private readonly AppDbContext _appDbContext;

        public CityRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public City AddCity(City city)
        {
            var addedEntity = _appDbContext.Cities.Add(city);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public void DeleteCity(int cityId)
        {
            var foundCity = _appDbContext.Cities.FirstOrDefault(e => e.CityId == cityId);
            if (foundCity == null) return;

            _appDbContext.Cities.Remove(foundCity);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<City> GetAllCities()
        {
            return _appDbContext.Cities;
        }

        public City GetCityById(int cityId)
        {
            return _appDbContext.Cities.FirstOrDefault(c => c.CityId == cityId);
        }

        public City UpdateCity(City city)
        {
            var foundCity = _appDbContext.Cities.FirstOrDefault(e => e.CityId == city.CityId);

            if (foundCity != null)
            {
                foundCity.CityId = city.CityId;
                foundCity.Name = city.Name;
                foundCity.Latitude = city.Latitude;
                foundCity.Longitude = city.Longitude;
                _appDbContext.SaveChanges();

                return foundCity;
            }

            return null;
        }
    }
}
