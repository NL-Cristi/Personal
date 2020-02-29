using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Api.Models
{
    public class JobCategoryRepository: IJobCategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public JobCategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public JobCategory AddJobCategory(JobCategory jobCategory)
        {
            var addedEntity = _appDbContext.JobCategories.Add(jobCategory);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public void DeleteJobCategory(int jobCategoryId)
        {
            var foundJobCategory = _appDbContext.JobCategories.FirstOrDefault(e => e.JobCategoryId == jobCategoryId);
            if (foundJobCategory == null) return;

            _appDbContext.JobCategories.Remove(foundJobCategory);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<JobCategory> GetAllJobCategories()
        {
            return _appDbContext.JobCategories;
        }

        public JobCategory GetJobCategoryById(int jobCategoryId)
        {
            return _appDbContext.JobCategories.FirstOrDefault(c => c.JobCategoryId == jobCategoryId);
        }

        public JobCategory UpdateJobCategory(JobCategory jobCategory)
        {
            var foundJobCategory = _appDbContext.JobCategories.FirstOrDefault(e => e.JobCategoryId == jobCategory.JobCategoryId);

            if (foundJobCategory != null)
            {
                foundJobCategory.JobCategoryName = jobCategory.JobCategoryName;
                foundJobCategory.JobCategoryId = jobCategory.JobCategoryId;
                
                _appDbContext.SaveChanges();

                return foundJobCategory;
            }

            return null;
        }
    }
}
