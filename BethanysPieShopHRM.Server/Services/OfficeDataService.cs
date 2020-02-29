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
    public class OfficeDataService : IOfficeDataService
    {
        private readonly HttpClient _httpClient;

        public OfficeDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Office> AddOffice(Office office)
        {
            var officeJson = new StringContent(JsonSerializer.Serialize(office), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/office", officeJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Office>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeleteOffice(int officeId)
        {
            await _httpClient.DeleteAsync($"api/office/{officeId}");
        }

        public async Task<IEnumerable<Office>> GetAllOffices()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Office>>
                            (await _httpClient.GetStreamAsync($"api/office"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Office> GetOfficeDetails(int officeId)
        {
            return await JsonSerializer.DeserializeAsync<Office>
                 (await _httpClient.GetStreamAsync($"api/office/{officeId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateOffice(Office office)
        {
            var officeJson = new StringContent(JsonSerializer.Serialize(office), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/office", officeJson);
        }
    }
}
