using EmployeesApp.Domain;
using EmployeesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EmployeesApp.Infrastructure.Persistance;
public class ApplicationContext(DbContextOptions<ApplicationContext> options)
    : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>().HasData(
             new Employee()
             {
                 Id = 562,
                 Name = "Anders Hejlsberg",
                 Email = "Anders.Hejlsberg@outlook.com",
                 Salary = 75000.00m,
             },
        new Employee()
        {
            Id = 62,
            Name = "Kathleen Dollard",
            Email = "k.d@outlook.com",
            Salary = 38000.00m,
        },
        new Employee()
        {
            Id = 15662,
            Name = "Mads Torgersen",
            Email = "Admin.Torgersen@outlook.com",
            Salary = 82000.00m,
        },
        new Employee()
        {
            Id = 52,
            Name = "Scott Hanselman",
            Email = "s.h@outlook.com",
            Salary = 50000.00m,
        },
        new Employee()
        {
            Id = 563,
            Name = "Jon Skeet",
            Email = "j.s@outlook.com",
            Salary = 60000.00m,
        }
        );
    }
}
