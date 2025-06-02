using EmployeesApp.Domain;
using EmployeesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AspNetDemo.Infrastructure.Persistance;
public class ApplicationContext(DbContextOptions<ApplicationContext> options)
    : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; } = null!;

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);

    //    modelBuilder.Entity<Company>().HasData(
    //        new Company { Id = 1, CompanyName = "Ica", City = "Stockholm" },
    //        new Company { Id = 22, CompanyName = "Coop", City = "Stockholm" },
    //        new Company { Id = 3, CompanyName = "Hemköp", City = "Göteborg" }
    //    );
    //}
}
