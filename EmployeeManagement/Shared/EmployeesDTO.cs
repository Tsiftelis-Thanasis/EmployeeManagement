#nullable disable

namespace EmployeeManagement.Shared
{
    public class EmployeesDTO
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? HiringDate { get; set; }

        public List<SkillsDTO> Skills { get; set; }
    }
}