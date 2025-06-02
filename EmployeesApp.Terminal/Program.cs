using EmployeesApp.Application.Employees.Services;
using EmployeesApp.Domain.Entities;
using EmployeesApp.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using EmployeesApp.Infrastructure.Persistance.Repositories;

namespace EmployeesApp.Terminal;
internal class Program
{
    static readonly EmployeeService employeeService = new(new EmployeeRepository(ApplicationContext context));

    static void Main(string[] args)
    {

        services.AddDbContext<ApplicationContext>(
     o => o.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EmployeeDB;Trusted_Connection=True;"));

        ListAllEmployees();
        ListEmployee(562);
    }

    private static void ListAllEmployees()
    {
        foreach (var item in employeeService.GetAll())
            Console.WriteLine(item.Name);

        Console.WriteLine("------------------------------");
    }

    private static void ListEmployee(int employeeID)
    {
        Employee? employee;

        try
        {
            employee = employeeService.GetById(employeeID);
            Console.WriteLine($"{employee?.Name}: {employee?.Email}");
            Console.WriteLine("------------------------------");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"EXCEPTION: {e.Message}");
        }
    }
}
