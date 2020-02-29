using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Api.Models
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly AppDbContext _appDbContext;

        public OfficeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Office AddOffice(Office office)
        {
            var addedEntity = _appDbContext.Offices.Add(office);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public void DeleteOffice(int officeId)
        {
            var foundOffice = _appDbContext.Offices.FirstOrDefault(e => e.OfficeId == officeId);
            if (foundOffice == null) return;

            _appDbContext.Offices.Remove(foundOffice);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Office> GetAllOffices()
        {
            return _appDbContext.Offices;
        }

        public Office GetOfficeById(int officeId)
        {
            return _appDbContext.Offices.FirstOrDefault(c => c.OfficeId == officeId);
        }

        public Office UpdateOffice(Office office)
        {
            var foundOffice = _appDbContext.Offices.FirstOrDefault(e => e.OfficeId == office.OfficeId);

            if (foundOffice != null)
            {
                foundOffice.OfficeId = office.OfficeId;
                foundOffice.Name = office.Name;
                foundOffice.CountryId = office.CountryId;
                foundOffice.CityId = office.CityId;
                foundOffice.Latitude = office.Latitude;
                foundOffice.Longitude = office.Longitude;
                _appDbContext.SaveChanges();

                return foundOffice;
            }

            return null;
        }
    }
}
