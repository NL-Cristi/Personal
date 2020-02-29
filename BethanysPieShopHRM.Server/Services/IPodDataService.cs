using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Services
{
    public interface IPodDataService
    {
        Task<IEnumerable<Pod>> GetAllPods();
        Task<Pod> GetPodDetails(int podId);
        Task<Pod> AddPod(Pod pod);
        Task UpdatePod(Pod pod);
        Task DeletePod(int podId);
    }
}
