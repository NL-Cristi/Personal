using BethanysPieShopHRM.Server.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Pages
{
    public class EmployeeEditBase: ComponentBase
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        [Inject]
        public ICountryDataService CountryDataService { get; set; }
        [Inject]
        public IJobCategoryDataService JobCategoryDataService { get; set; }

        [Inject]
        public IRegionDataService RegionDataService { get; set; }
        [Inject]
        public IOfficeDataService OfficeDataService { get; set; }
        [Inject]
        public IPodDataService PodDataService { get; set; }
        [Inject]
        public ICityDataService CityDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }


        [Parameter]
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();
        public List<City> Cities { get; set; } = new List<City>();
        public List<Country> Countries { get; set; } = new List<Country>();
        public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();
        public List<Office> Offices { get; set; } = new List<Office>();
        public List<Pod> Pods { get; set; } = new List<Pod>();
        public List<Region> Regions { get; set; } = new List<Region>();


        protected string OfficeId = string.Empty;
        protected string JobCategoryId = string.Empty;
        protected string RegionId = string.Empty;
        protected string PodId = string.Empty;


        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            Cities = (await CityDataService.GetAllCities()).ToList();
            Countries = (await CountryDataService.GetAllCountries()).ToList();
            JobCategories = (await JobCategoryDataService.GetAllJobCategories()).ToList();
            Offices = (await OfficeDataService.GetAllOffices()).ToList();
            Pods = (await PodDataService.GetAllPods()).ToList();
            Regions = (await RegionDataService.GetAllRegions()).ToList();



            int.TryParse(EmployeeId, out var employeeId);

            if (employeeId == 0) //new employee is being created
            {
                //add some defaults
                Employee = new Employee { OfficeId = 1, JobCategoryId = 1, RegionId = 3 };
            }
            else
            {
                Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            }

            OfficeId = Employee.OfficeId.ToString();
            RegionId = Employee.RegionId.ToString();

            JobCategoryId = Employee.JobCategoryId.ToString();
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;
            Employee.OfficeId = int.Parse(OfficeId);
            Employee.RegionId = int.Parse(RegionId);

            Employee.JobCategoryId = int.Parse(JobCategoryId);

            if (Employee.EmployeeId == 0) //new
            {
                var addedEmployee = await EmployeeDataService.AddEmployee(Employee);
                if (addedEmployee != null)
                {
                    StatusClass = "alert-success";
                    Message = "New employee added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new employee. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await EmployeeDataService.UpdateEmployee(Employee);
                StatusClass = "alert-success";
                Message = "Employee updated successfully.";
                Saved = true;
            }
        }

        protected async Task DeleteEmployee()
        {
            await EmployeeDataService.DeleteEmployee(Employee.EmployeeId);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }
    }
}
