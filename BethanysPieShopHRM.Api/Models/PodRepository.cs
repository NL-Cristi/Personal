using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Api.Models
{
    public class PodRepository : IPodRepository
    {
        private readonly AppDbContext _appDbContext;

        public PodRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Pod AddPod(Pod pod)
        {
            var addedEntity = _appDbContext.Pods.Add(pod);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public void DeletePod(int podId)
        {
            var foundPod = _appDbContext.Pods.FirstOrDefault(e => e.PodId == podId);
            if (foundPod == null) return;

            _appDbContext.Pods.Remove(foundPod);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Pod> GetAllPods()
        {
            return _appDbContext.Pods;
        }

        public Pod GetPodById(int podId)
        {
            return _appDbContext.Pods.FirstOrDefault(c => c.PodId == podId);
        }

        public Pod UpdatePod(Pod pod)
        {
            var foundPod = _appDbContext.Pods.FirstOrDefault(e => e.PodId == pod.PodId);

            if (foundPod != null)
            {
                foundPod.PodId = pod.PodId;
                foundPod.Name = pod.Name;
                _appDbContext.SaveChanges();

                return foundPod;
            }

            return null;
        }
    }
}
