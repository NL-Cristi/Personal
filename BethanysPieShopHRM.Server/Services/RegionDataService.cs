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
    
    public class RegionDataService : IRegionDataService
    {
        private readonly HttpClient _httpClient;

        public RegionDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Region> AddRegion(Region region)
        {
            var regionJson =
                    new StringContent(JsonSerializer.Serialize(region), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/employee", regionJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Region>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeleteRegion(int regionId)
        {
            await _httpClient.DeleteAsync($"api/region/{regionId}");
        }

        public async Task<IEnumerable<Region>> GetAllRegions()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Region>>
                (await _httpClient.GetStreamAsync($"api/region"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }


        public async Task<Region> GetRegionDetails(int regionId)
        {
            return await JsonSerializer.DeserializeAsync<Region>
                 (await _httpClient.GetStreamAsync($"api/region/{regionId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdatRegion(Region region)
        {
            var regionJson =
                            new StringContent(JsonSerializer.Serialize(region), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/region", regionJson);
        }
    }
}