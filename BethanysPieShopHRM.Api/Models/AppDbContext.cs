using System;
using BethanysPieShopHRM.Shared;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Pod> Pods { get; set; }


        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed Countries
            modelBuilder.Entity<City>().HasData(new City { CityId = 1, Name = "Lisbon", Latitude = 38.736946, Longitude = -9.142685 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 2, Name = "Porto", Latitude = 41.14961, Longitude = -8.61099 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 3, Name = "Bucharest", Latitude = 44.439663, Longitude = 26.096306 });
            modelBuilder.Entity<City>().HasData(new City { CityId = 4, Name = "Timisoara", Latitude = 45.760696, Longitude = 21.226788 });


            //seed Countries
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, Name = "Portugal", Latitude = 39.332589, Longitude = -7.511318 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, Name = "Romania", Latitude = 45.843615, Longitude = 24.969258 });

            //seed Offices
            modelBuilder.Entity<Office>().HasData(new Office { OfficeId = 1, Name = "Virtual", CountryId = 1, CityId = 1, Latitude = 38.761041, Longitude = -9.094536 });
            modelBuilder.Entity<Office>().HasData(new Office { OfficeId = 2, Name = "Amoreiras", CountryId = 1, CityId = 1, Latitude = 38.723094, Longitude = -9.162429 });
            modelBuilder.Entity<Office>().HasData(new Office { OfficeId = 3, Name = "Tudor", CountryId = 2, CityId = 3, Latitude = 44.437367, Longitude = 26.104955 });
            modelBuilder.Entity<Office>().HasData(new Office { OfficeId = 4, Name = "CITY", CountryId = 2, CityId = 3, Latitude = 44.477758, Longitude = 26.071567 });
            modelBuilder.Entity<Office>().HasData(new Office { OfficeId = 5, Name = "Globalworth", CountryId = 2, CityId = 3, Latitude = 44.480354, Longitude = 26.103968 });
            modelBuilder.Entity<Office>().HasData(new Office { OfficeId = 6, Name = "OPENVILLE", CountryId = 2, CityId = 4, Latitude = 45.766202, Longitude = 21.230267 });


            //seed JobCategories

            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 1, JobCategoryName = "SE" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 2, JobCategoryName = "SEE" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 3, JobCategoryName = "EE" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 4, JobCategoryName = "EEE" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 5, JobCategoryName = "TA" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 6, JobCategoryName = "M1" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 7, JobCategoryName = "M2" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 8, JobCategoryName = "M3" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 9, JobCategoryName = "M4" });

            //seed JobCategories
            modelBuilder.Entity<Region>().HasData(new Region() { RegionId = 1, Name = "Americas" });
            modelBuilder.Entity<Region>().HasData(new Region() { RegionId = 2, Name = "Asia Pacific" });
            modelBuilder.Entity<Region>().HasData(new Region() { RegionId = 3, Name = "EMEA" });


            //seed Pods

            modelBuilder.Entity<Pod>().HasData(new Pod() { PodId = 1, Name = "Web Apps" });
            modelBuilder.Entity<Pod>().HasData(new Pod() { PodId = 2, Name = "DevOps" });
            modelBuilder.Entity<Pod>().HasData(new Pod() { PodId = 3, Name = "Client Apps" });
            modelBuilder.Entity<Pod>().HasData(new Pod() { PodId = 4, Name = "Visual Studio and Languages" });
            modelBuilder.Entity<Pod>().HasData(new Pod() { PodId = 5, Name = "Browsers" });



            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Cristian",
                LastName = "Negulescu",
                Email = "crnegule@microsoft.com",
                ManagerFirstName = "Alex",
                ManagerLastName = "Vulcan",
                ManagerEmail = "alvulcan@microsoft.com",
                JobCategoryId = 2,
                OfficeId = 1,
                RegionId = 3,
                PodId = 1,
                Comment = "Details for Cristian Negulescu"

            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "João Paulo",
                LastName = "Rodrigues",
                Email = "Joao.Paulo.Rodrigues@microsoft.com",
                ManagerFirstName = "Alex",
                ManagerLastName = "Vulcan",
                ManagerEmail = "alvulcan@microsoft.com",
                JobCategoryId = 3,
                OfficeId = 1,
                RegionId = 3,
                PodId = 2,
                Comment = "Details for JP"

            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "Paul",
                LastName = "Cociuba",
                Email = "paulboc@microsoft.com",
                ManagerFirstName = "Alex",
                ManagerLastName = "Vulcan",
                ManagerEmail = "alvulcan@microsoft.com",
                JobCategoryId = 3,
                OfficeId = 2,
                RegionId = 3,
                PodId = 2,
                Comment = "Details for Paul Cociuba"

            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 4,
                FirstName = "Alex",
                LastName = "Vulcan",
                Email = "avulcan@microsoft.com",
                ManagerFirstName = "Karla",
                ManagerLastName = "Stoker",
                ManagerEmail = "karlalyn@microsoft.com",
                JobCategoryId = 6,
                OfficeId = 5,
                RegionId = 3,
                PodId = 2,
                Comment = "Details for Alex Vulcan"

            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 5,
                FirstName = "Dragos",
                LastName = "Soare",
                Email = "flsoare@microsoft.com",
                ManagerFirstName = "Karla",
                ManagerLastName = "Stoker",
                ManagerEmail = "karlalyn@microsoft.com",
                JobCategoryId = 6,
                OfficeId = 5,
                RegionId = 3,
                PodId = 5,
                Comment = "Details for Dragos Soare"

            });
        }
        #endregion
    }
}
