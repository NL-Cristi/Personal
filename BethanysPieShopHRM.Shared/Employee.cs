using System;
using System.ComponentModel.DataAnnotations;

namespace BethanysPieShopHRM.Shared
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name is too long.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name is too long.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public string Comment { get; set; }
        public DateTime? JoinedDate { get; set; }
        
        public int JobCategoryId { get; set; }
        public JobCategory JobCategory { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
