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

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, Name = "China" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, Name = "France" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 3, Name = "Germany" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 4, Name = "India" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 5, Name = "Japan" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 6, Name = "Jordan" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 7, Name = "Portugal" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 8, Name = "Romania" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 9, Name = "Spain" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 10, Name = "UK" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 11, Name = "USA" });


            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 1, JobCategoryName = "SE" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 2, JobCategoryName = "SEE" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 3, JobCategoryName = "EE" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 4, JobCategoryName = "EEE" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 5, JobCategoryName = "TA" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 6, JobCategoryName = "M1" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 7, JobCategoryName = "M2" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 8, JobCategoryName = "M3" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 9, JobCategoryName = "M4" });

            modelBuilder.Entity<Region>().HasData(new Region() { RegionId = 1, Name = "Americas" });
            modelBuilder.Entity<Region>().HasData(new Region() { RegionId = 2, Name = "Asia Pacific" });
            modelBuilder.Entity<Region>().HasData(new Region() { RegionId = 3, Name = "EMEA" });


            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                CountryId = 2,
                City = "Paris",
                Email = "paulboc@microsoft.com",
                FirstName = "Paul",
                LastName = "Cociuba",
                JobCategoryId = 3,
                RegionId = 3,
                Comment = "Lorem Ipsum",
                JoinedDate = new DateTime(2015, 3, 1),
                Latitude = 48.864716,
                Longitude = 2.349014
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                CountryId = 7,
                City = "Lisbon",
                Email = "crnegule@microsoft.com",
                FirstName = "Cristian",
                LastName = "Negulescu",
                JobCategoryId = 2,
                RegionId = 3,
                Comment = "Lorem Ipsum",
                JoinedDate = new DateTime(2015, 3, 1),
                Latitude = 38.736946,
                Longitude = -9.142685
            });
        }
    }
}
