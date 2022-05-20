using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class SeedData
    {
        private readonly EducationContext _context;

        public SeedData(EducationContext context)
        {
            _context = context;

        }

        public async Task SeedDb()
        {
            if (await SeedSkills()) Console.WriteLine("Skills seeded");
                Console.WriteLine("Skills not seeded");


            if (await SeedTeachers()) Console.WriteLine("Teachers seeded");
                Console.WriteLine("Teachers not seeded");                
            

            if (await SeedCourses()) Console.WriteLine("Courses seeded");
                Console.WriteLine("Courses not seeded");
        }

        public async Task<bool> SeedSkills()
        {
            if (await _context.Skills.AnyAsync()) return false;

            Skill skill1 = new Skill{
                SkillName = "Frontend"
            };
            Skill skill2 = new Skill{
                SkillName = "Backend"
            };
            Skill skill3 = new Skill{
                SkillName = "Databas"
            };
            Skill skill4 = new Skill{
                SkillName = "C#"
            };
            Skill skill5 = new Skill{
                SkillName = "Java"
            };
            Skill skill6 = new Skill{
                SkillName = "Javascript"
            };

            return true;
        }

        public async Task<bool> SeedTeachers()
        {
            if (await _context.Teachers.AnyAsync()) return false;

            Teacher teacher1 = new Teacher{
                FirstName = "Anna",
                LastName = "Annasson",
                Email = "Anna.Annasson@WCE.com",
                PhoneNumber = "0701234567",
                Address = "Gatan 1",
                TeacherSkill = new List<Skill>{}
            };

            return true;
        }

        public async Task<bool> SeedCourses()
        {
            if (await _context.Courses.AnyAsync()) return false;

            Course course1 = new Course{
                CourseNumber = 1001,
                CourseName = ".NET Fullstack",
                Duration = 24,
                Category = ".NET",
                Description = "Lorem ipsum dolor",
                Details ="Lorem ipsum dolor sit amet, consectetur adipiscing elit."
                };



            return true;
        }
    }
}