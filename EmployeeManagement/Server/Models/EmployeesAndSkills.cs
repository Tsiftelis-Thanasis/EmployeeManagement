using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Server.Models
{
    public class EmployeesAndSkills
    {
        public int Id { get; set; }

        [ForeignKey("Employees")]
        public int EmployeeId { get; set; }

        [ForeignKey("Skills")]
        public int SkillId { get; set; }
    }
}