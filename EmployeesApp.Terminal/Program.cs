using EmployeesApp.Application.Employees.Services;
using EmployeesApp.Domain.Entities;
using EmployeesApp.Infrastructure.Persistance.Repositories;
using EmployeesApp.Infrastructure.Persistance; // For ApplicationContext
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Terminal;

internal class Program
{
    static void Main(string[] args)
    {
        // Configure Entity Framework
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EmployeeDB;Trusted_Connection=True;")
            .Options;

        // Create context and service
        using var context = new ApplicationContext(options);
        var employeeRepository = new EmployeeRepository(context);
        var employeeService = new EmployeeService(employeeRepository);

        // Apply migrations automatically on startup
        context.Database.Migrate();

        // Execute tests
        ListAllEmployees(employeeService);
        ListEmployee(employeeService, 562);

        // Example of adding a new employee
        AddNewEmployee(employeeService);

        // List again to see the new employee
        Console.WriteLine("After adding new employee:");
        ListAllEmployees(employeeService);
    }

    private static void ListAllEmployees(EmployeeService employeeService)
    {
        Console.WriteLine("=== ALL EMPLOYEES ===");
        var employees = employeeService.GetAll();

        if (!employees.Any())
        {
            Console.WriteLine("No employees found in database.");
        }
        else
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Name}");
            }
        }
        Console.WriteLine("------------------------------");
    }

    private static void ListEmployee(EmployeeService employeeService, int employeeId)
    {
        Console.WriteLine($"=== EMPLOYEE ID: {employeeId} ===");
        try
        {
            var employee = employeeService.GetById(employeeId);
            Console.WriteLine($"{employee?.Name}: {employee?.Email}");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"EXCEPTION: {e.Message}");
        }
        Console.WriteLine("------------------------------");
    }

    
    
}