using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Api.Models
{
    public interface IPodRepository
    {
        IEnumerable<Pod> GetAllPods();
        Pod GetPodById(int podId);
        Pod AddPod(Pod pod);
        Pod UpdatePod(Pod pod);
        void DeletePod(int podId);
    }
}
