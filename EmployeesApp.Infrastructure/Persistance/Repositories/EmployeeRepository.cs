using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Infrastructure.Persistance.Repositories
{
    public class EmployeeRepository(ApplicationContext context) : IEmployeeRepository
    {
        // Old hardcoded list - now commented out since we use database
        //readonly List<Employee> employees =
        //[
        //    new Employee()
        //{
        //    Id = 562,
        //    Name = "Anders Hejlsberg",
        //    Email = "Anders.Hejlsberg@outlook.com",
        //    Salary = 120000.00m
        //},
        //new Employee()
        //{
        //    Id = 62,
        //    Name = "Kathleen Dollard",
        //    Email = "k.d@outlook.com",
        //    Salary = 95000.00m
        //},
        //new Employee()
        //{
        //    Id = 15662,
        //    Name = "Mads Torgersen",
        //    Email = "Admin.Torgersen@outlook.com",
        //    Salary = 110000.00m
        //},
        //new Employee()
        //{
        //    Id = 52,
        //    Name = "Scott Hanselman",
        //    Email = "s.h@outlook.com",
        //    Salary = 105000.00m
        //},
        //new Employee()
        //{
        //    Id = 563,
        //    Name = "Jon Skeet",
        //    Email = "j.s@outlook.com",
        //    Salary = 130000.00m
        //},
        //];

        public void Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        // Classic C# syntax for GetAll()
        public Employee[] GetAll()
        {
            return [.. context.Employees];
        }

        public Employee? GetById(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                throw new ArgumentException($"No employee found with ID: {id}");
            }
            return employee;
        }

       
    }
}