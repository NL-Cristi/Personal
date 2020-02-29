using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Services
{
    public class CityDataService : ICityDataService
    {
        private readonly HttpClient _httpClient;

        public CityDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<City> AddCity(City city)
        {
            var cityJson = new StringContent(JsonSerializer.Serialize(city), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/city", cityJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<City>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeleteCity(int cityId)
        {
            await _httpClient.DeleteAsync($"api/city/{cityId}");
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<City>>
                            (await _httpClient.GetStreamAsync($"api/city"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<City> GetCityDetails(int cityId)
        {
            return await JsonSerializer.DeserializeAsync<City>
                             (await _httpClient.GetStreamAsync($"api/city/{cityId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateCity(City city)
        {
            var cityJson = new StringContent(JsonSerializer.Serialize(city), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/city", cityJson);
        }
    }
}
