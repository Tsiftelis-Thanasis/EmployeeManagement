namespace EmployeeManagement.Server.Models
{
    public class Employees
    {
        //[Key]
        public int Id { get; set; }

        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? HiringDate { get; set; }
        // public virtual ICollection<Skills> Skills { get; set; }
    }
}