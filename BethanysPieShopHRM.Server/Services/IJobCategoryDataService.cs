using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Services
{
    public interface IJobCategoryDataService
    {
        Task<IEnumerable<JobCategory>> GetAllJobCategories();
        Task<JobCategory> GetJobCategoryDetails(int jobcategoryId);
        Task<JobCategory> AddJobCategory(JobCategory jobcategory);
        Task UpdateJobCategory(JobCategory jobcategory);
        Task DeleteJobCategory(int jobcategoryId);
    }
}
