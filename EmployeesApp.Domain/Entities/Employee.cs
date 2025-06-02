using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesApp.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        [Column(TypeName = "money")]
        public decimal Salary { get; set; }
    }
}
