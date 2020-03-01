using BethanysPieShopHRM.ComponentsLibrary.Map;
using BethanysPieShopHRM.Server.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Pages
{
    public class EmployeeDetailBase: ComponentBase
    {
        [Parameter]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();
        public Office EmployeeOffice { get; set; } = new Office();
        public Country EmployeeCountry { get; set; } = new Country();
        public City EmployeeCity { get; set; } = new City();
        public Region EmployeeRegion { get; set; } = new Region();
        public JobCategory EmpoloyeeJob { get; set; } = new JobCategory();
        public Pod EmployeePod { get; set; } = new Pod();
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        public List<Marker> MapMarkers { get; set; } = new List<Marker>();


        protected override async Task OnInitializedAsync()
        //protected override async Task OnAfterRenderAsync(bool firstRender)

        {
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            EmployeeOffice = Employee.Office;
            EmployeeCountry = Employee.Office.Country;
            EmployeeCity = Employee.Office.City;
            EmployeeRegion = Employee.Region;
            EmpoloyeeJob = Employee.JobCategory;
            EmployeePod = Employee.Pod;
            
            MapMarkers = new List<Marker>
            {
                new Marker{Description = $"{EmployeeCity.Name}-{EmployeeOffice.Name}",  ShowPopup = true, X = Employee.Office.Longitude, Y = Employee.Office.Latitude}
            };
        }

    }
}
