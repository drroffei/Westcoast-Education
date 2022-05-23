namespace webapi.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string? SkillName { get; set; }
        public List<Teacher> SkillTeachers { get; set; }
    }
}