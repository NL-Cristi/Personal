using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Api.Models
{
    public interface IOfficeRepository
    {
        IEnumerable<Office> GetAllOffices();
        Office GetOfficeById(int officeId);
        Office AddOffice(Office office);
        Office UpdateOffice(Office office);
        void DeleteOffice(int officeId);
    }
}
