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
    public class PodDataService : IPodDataService
    {
        private readonly HttpClient _httpClient;

        public PodDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Pod> AddPod(Pod pod)
        {
            var podJson = new StringContent(JsonSerializer.Serialize(pod), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/pod", podJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Pod>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeletePod(int podId)
        {
            await _httpClient.DeleteAsync($"api/pod/{podId}");
        }

        public async Task<IEnumerable<Pod>> GetAllPods()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Pod>>
                            (await _httpClient.GetStreamAsync($"api/pod"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Pod> GetPodDetails(int podId)
        {
            return await JsonSerializer.DeserializeAsync<Pod>
                            (await _httpClient.GetStreamAsync($"api/pod/{podId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdatePod(Pod pod)
        {
            var podJson = new StringContent(JsonSerializer.Serialize(pod), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/pod", podJson);
        }
    }
}
