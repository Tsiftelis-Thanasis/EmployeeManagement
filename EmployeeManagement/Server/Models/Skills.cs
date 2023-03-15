using EmployeeManagement.Shared;

namespace EmployeeManagement.Server.Models
{
    public class Skills
    {
        //[Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }

        public SkillsDTO ToSkillsDTO()
        {
            SkillsDTO skillsDTO = new SkillsDTO();
            skillsDTO.Id = this.Id;
            skillsDTO.Name = this.Name;
            skillsDTO.Description = this.Description;
            return skillsDTO;
        }
    }

    public class SelectedSkills : Skills
    {
        public bool IsSelected { get; set; }
    }
}