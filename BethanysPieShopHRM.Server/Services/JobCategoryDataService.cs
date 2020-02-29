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
    public class JobCategoryDataService : IJobCategoryDataService
    {
        private readonly HttpClient _httpClient;

        public JobCategoryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<JobCategory> AddJobCategory(JobCategory jobcategory)
        {
            var jobcategoryJson =
                        new StringContent(JsonSerializer.Serialize(jobcategory), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/jobcategory", jobcategoryJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<JobCategory>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeleteJobCategory(int jobcategoryId)
        {
            await _httpClient.DeleteAsync($"api/jobcategory/{jobcategoryId}");
        }

        public async Task<IEnumerable<JobCategory>> GetAllJobCategories()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<JobCategory>>
                (await _httpClient.GetStreamAsync($"api/jobcategory"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }


        public async Task<JobCategory> GetJobCategoryDetails(int jobCategoryId)
        {
            return await JsonSerializer.DeserializeAsync<JobCategory>
                (await _httpClient.GetStreamAsync($"api/jobcategory/{jobCategoryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateJobCategory(JobCategory jobcategory)
        {
            var jobcategoryJson =
                            new StringContent(JsonSerializer.Serialize(jobcategory), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/jobcategory", jobcategoryJson);
        }
    }
}
