using System.Collections.Generic;
using System.Linq;
using BethanysPieShopHRM.Shared;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
           var foundall =  _appDbContext.Employees
                .Include(a => a.Office).Include(b => b.Region).Include(c => c.JobCategory).Include(e => e.Pod).Include(f => f.Office.Country).Include(g => g.Office.City);
            return foundall;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            var foundemployee = 
                _appDbContext.Employees.Include(a => a.Office).Include(b => b.Region).Include(c => c.JobCategory).Include(e => e.Pod)
                .Include(f => f.Office.Country).Include(g => g.Office.City).FirstOrDefault(c => c.EmployeeId == employeeId);
                            

            return foundemployee;
        }

        public Employee AddEmployee(Employee employee)
        {
            var addedEntity = _appDbContext.Employees.Add(employee);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var foundEmployee = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);

            if (foundEmployee != null)
            {
                foundEmployee.EmployeeId = employee.EmployeeId;
                foundEmployee.FirstName = employee.FirstName;
                foundEmployee.LastName = employee.LastName;
                foundEmployee.Email = employee.Email;
                foundEmployee.ManagerFirstName = employee.ManagerFirstName;
                foundEmployee.ManagerLastName = employee.ManagerLastName;
                foundEmployee.ManagerEmail = employee.ManagerEmail;
                foundEmployee.JobCategoryId = employee.JobCategoryId;
                foundEmployee.OfficeId = employee.OfficeId;
                foundEmployee.RegionId = employee.RegionId;
                foundEmployee.PodId = employee.PodId;
                foundEmployee.Comment = employee.Comment;

                _appDbContext.SaveChanges();

                return foundEmployee;
            }

            return null;
        }

        public void DeleteEmployee(int employeeId)
        {
            var foundEmployee = _appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (foundEmployee == null) return;

            _appDbContext.Employees.Remove(foundEmployee);
            _appDbContext.SaveChanges();
        }
    }
}
