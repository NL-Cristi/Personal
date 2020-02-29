using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Services
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryDetails(int countryId);
        Task<Country> AddCountry(Country country);
        Task UpdateCountry(Country country);
        Task DeleteCountry(int countryId);

    }
}
