using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Services
{
    public interface IOfficeDataService
    {
        Task<IEnumerable<Office>> GetAllOffices();
        Task<Office> GetOfficeDetails(int officeId);
        Task<Office> AddOffice(Office office);
        Task UpdateOffice(Office office);
        Task DeleteOffice(int officeId);

    }
}
