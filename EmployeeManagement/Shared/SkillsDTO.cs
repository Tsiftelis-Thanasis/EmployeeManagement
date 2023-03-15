#nullable disable

namespace EmployeeManagement.Shared
{
    public class SkillsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class SelectedSkillsDTO : SkillsDTO
    {
        public bool IsSelected { get; set; }
    }
}