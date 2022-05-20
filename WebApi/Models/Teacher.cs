using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Address { get; set; }
        public List<Skill>? Skills { get; set; }
    }
}