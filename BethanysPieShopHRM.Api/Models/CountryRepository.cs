using System.Collections.Generic;
using System.Linq;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Api.Models
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CountryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Country AddCountry(Country country)
        {
            var addedEntity = _appDbContext.Countries.Add(country);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public void DeleteCountry(int countryId)
        {
            var foundCountry = _appDbContext.Countries.FirstOrDefault(e => e.CountryId == countryId);
            if (foundCountry == null) return;

            _appDbContext.Countries.Remove(foundCountry);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _appDbContext.Countries;
        }

        public Country GetCountryById(int countryId)
        {
            return _appDbContext.Countries.FirstOrDefault(c => c.CountryId == countryId);
        }

        public Country UpdateCountry(Country country)
        {
            var foundCountry = _appDbContext.Countries.FirstOrDefault(e => e.CountryId == country.CountryId);

            if (foundCountry != null)
            {
                foundCountry.CountryId = country.CountryId;
                foundCountry.Name = country.Name;
                foundCountry.Latitude = country.Latitude;
                foundCountry.Longitude = country.Longitude;
                _appDbContext.SaveChanges();

                return foundCountry;
            }

            return null;
        }
    }
}
