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
            if (await SeedTeachers()) Console.WriteLine("Teachers seeded");
            Console.WriteLine("Teachers not seeded");


            if (await SeedCourses()) Console.WriteLine("Courses seeded");
            Console.WriteLine("Courses not seeded");

            if (await SeedCustomers()) Console.WriteLine("Customers seeded");
            Console.WriteLine("Customers not seeded");
        }

        private async Task<bool> SeedCustomers()
        {
            if (await _context.Customers.AnyAsync()) return false;

            var listOfCourses = await _context.Courses.ToListAsync();


            Customer customer1 = new Customer
            {
                FirstName = "Adam",
                LastName = "Adamsson",
                Email = "Adam.Adamsson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Gångvägen 1",
                CurrentCourse = new CourseCustomerCurrent { },
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            Customer customer2 = new Customer
            {
                FirstName = "Berit",
                LastName = "Beritsson",
                Email = "Berit.Beritsson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Markstigen 2",
                CurrentCourse = new CourseCustomerCurrent { },
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            Customer customer3 = new Customer
            {
                FirstName = "Charlie",
                LastName = "Charliesson",
                Email = "Charlie.Charliesson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Bostadsvägen 3",
                CurrentCourse = new CourseCustomerCurrent { },
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            Customer customer4 = new Customer
            {
                FirstName = "Daniella",
                LastName = "Daniellassson",
                Email = "Daniella.Daniellasson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Huvudleden 4",
                CurrentCourse = new CourseCustomerCurrent { },
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            Customer customer5 = new Customer
            {
                FirstName = "Erik",
                LastName = "Eriksson",
                Email = "Erik.Eriksson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Sidbanan 5",
                CurrentCourse = new CourseCustomerCurrent { },
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            Customer customer6 = new Customer
            {
                FirstName = "Filip",
                LastName = "Filipsson",
                Email = "Filip.Filipsson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Parkområdet 6",
                CurrentCourse = new CourseCustomerCurrent { },
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            Customer customer7 = new Customer
            {
                FirstName = "Gabriella",
                LastName = "Gabriellasson",
                Email = "Gabriella.Gabriellasson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Skogsberget 7",
                CurrentCourse = new CourseCustomerCurrent { },
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            Customer customer8 = new Customer
            {
                FirstName = "Henry",
                LastName = "Henrysson",
                Email = "Henry.Henrysson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Gatuleden 8",
                CurrentCourse = new CourseCustomerCurrent { },
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            Customer customer9 = new Customer
            {
                FirstName = "Ingrid",
                LastName = "Ingridsson",
                Email = "Ingrid.Ingridsson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Hamnleden 9",
                CurrentCourse = new CourseCustomerCurrent { },
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            Customer customer10 = new Customer
            {
                FirstName = "Johan",
                LastName = "Johansson",
                Email = "Johan.Johansson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Stiggatan 10",
                CurrentCourse = new CourseCustomerCurrent { },
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            Customer customer11 = new Customer
            {
                FirstName = "Karl",
                LastName = "Karlsson",
                Email = "Karl.Karlsson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Platstorget 11",
                CurrentCourse = new CourseCustomerCurrent { },
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            Customer customer12 = new Customer
            {
                FirstName = "Lennart",
                LastName = "Lennartsson",
                Email = "Lennart.Lennartsson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Storstigen 12",
                CurrentCourse = new CourseCustomerCurrent { },
                FinishedCourses = new List<CourseCustomerFinished>()
            };

            foreach (var course in listOfCourses)
            {
                if (course.CourseName == "Webbutveckling")
                {
                    customer10.CurrentCourse.Course = course;
                    customer10.CurrentCourse.Customer = customer10;
                    customer11.CurrentCourse.Course = course;
                    customer11.CurrentCourse.Customer = customer11;
                    customer12.CurrentCourse.Course = course;
                    customer12.CurrentCourse.Customer = customer12;
                    customer1.FinishedCourses.Add(new CourseCustomerFinished{Course = course, Customer = customer1});
                    break;
                }
            }

            foreach (var course in listOfCourses)
            {
                if (course.CourseName == "Databas")
                {
                    customer7.CurrentCourse.Course = course;
                    customer7.CurrentCourse.Customer = customer7;
                    customer8.CurrentCourse.Course = course;
                    customer8.CurrentCourse.Customer = customer8;
                    customer9.CurrentCourse.Course = course;
                    customer9.CurrentCourse.Customer = customer9;
                    customer1.FinishedCourses.Add(new CourseCustomerFinished{Course = course, Customer = customer1});
                    customer3.FinishedCourses.Add(new CourseCustomerFinished{Course = course, Customer = customer3});
                    break;
                }
            }

            foreach (var course in listOfCourses)
            {
                if (course.CourseName == "Java Fullstack")
                {
                    customer4.CurrentCourse.Course = course;
                    customer4.CurrentCourse.Customer = customer4;
                    customer5.CurrentCourse.Course = course;
                    customer5.CurrentCourse.Customer = customer5;
                    customer6.CurrentCourse.Course = course;
                    customer6.CurrentCourse.Customer = customer6;
                    break;
                }
            }

            foreach (var course in listOfCourses)
            {
                if (course.CourseName == ".NET Fullstack")
                {
                    customer1.CurrentCourse.Course = course;
                    customer1.CurrentCourse.Customer = customer1;
                    customer2.CurrentCourse.Course = course;
                    customer2.CurrentCourse.Customer = customer2;
                    customer3.CurrentCourse.Course = course;
                    customer3.CurrentCourse.Customer = customer3;
                    customer5.FinishedCourses.Add(new CourseCustomerFinished{Course = course, Customer = customer5});

                    break;
                }
            }



            return true;

        }

        public async Task<bool> SeedTeachers()
        {
            if (await _context.Teachers.AnyAsync()) return false;

            Teacher teacher1 = new Teacher
            {
                FirstName = "Anna",
                LastName = "Annasson",
                Email = "Anna.Annasson@WCE.com",
                PhoneNumber = "0701234567",
                Address = "Gatan 1",
                TeacherSkill = new List<Skill>{new Skill{SkillName = "Frontend"},
                                            new Skill{SkillName = "Backend"},
                                            new Skill{SkillName = "C#"}}
            };

            Teacher teacher2 = new Teacher
            {
                FirstName = "Bengt",
                LastName = "Bentsson",
                Email = "Bengt.Bentsson@WCE.com",
                PhoneNumber = "0701234567",
                Address = "Vägen 2",
                TeacherSkill = new List<Skill>{new Skill{SkillName = "Backend"},
                                            new Skill{SkillName = "Java"},
                                            new Skill{SkillName = "JavaScript"}}
            };

            Teacher teacher3 = new Teacher
            {
                FirstName = "Calle",
                LastName = "Callesson",
                Email = "Calle.Callesson@WCE.com",
                PhoneNumber = "0701234567",
                Address = "Stigen 3",
                TeacherSkill = new List<Skill>{new Skill{SkillName = "Databas"},
                                            new Skill{SkillName = "C#"}}
            };

            return true;
        }

        public async Task<bool> SeedCourses()
        {
            if (await _context.Courses.AnyAsync()) return false;

            Course course1 = new Course
            {
                CourseNumber = 1001,
                CourseName = ".NET Fullstack",
                Duration = 24,
                Category = ".NET",
                Description = "Lorem ipsum dolor",
                Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            };
            course1.Teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.FirstName == "Anna");

            Course course2 = new Course
            {
                CourseNumber = 1002,
                CourseName = "Java Fullstack",
                Duration = 24,
                Category = ".NET",
                Description = "Lorem ipsum dolor",
                Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            };
            course2.Teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.FirstName == "Bengt");

            Course course3 = new Course
            {
                CourseNumber = 1003,
                CourseName = "Databas",
                Duration = 24,
                Category = ".NET",
                Description = "Lorem ipsum dolor",
                Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            };
            course3.Teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.FirstName == "Calle");

            Course course4 = new Course
            {
                CourseNumber = 1004,
                CourseName = "Webbutveckling",
                Duration = 24,
                Category = ".NET",
                Description = "Lorem ipsum dolor",
                Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            };
            course4.Teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.FirstName == "Bengt");



            return true;
        }
    }
}