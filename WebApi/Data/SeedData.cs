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

        public static async Task SeedDb(EducationContext _context)
        {
            if (await SeedTeachers(_context))
            {
                Console.WriteLine("Teachers seeded");
            }
            else
            {
                Console.WriteLine("Teachers not seeded");
            }

            if (await SeedCourses(_context))
            {
                Console.WriteLine("Courses seeded");
            }
            else
            {
                Console.WriteLine("Courses not seeded");
            }

            if (await SeedCustomers(_context))
            {
                Console.WriteLine("Customers seeded");
            }
            else
            {
                Console.WriteLine("Customers not seeded");
            }
        }

        private static async Task<bool> SeedCustomers(EducationContext _context)
        {
            if (await _context.Customers.AnyAsync())
            {
                return false;
            }

            var coursesList = await _context.Courses.ToListAsync();
            var listOfCustomers = new List<Customer>();

            Customer customer1 = new Customer
            {
                FirstName = "Adam",
                LastName = "Adamsson",
                Email = "Adam.Adamsson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Gångvägen 1",
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            listOfCustomers.Add(customer1);

            Customer customer2 = new Customer
            {
                FirstName = "Berit",
                LastName = "Beritsson",
                Email = "Berit.Beritsson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Markstigen 2",
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            listOfCustomers.Add(customer2);

            Customer customer3 = new Customer
            {
                FirstName = "Charlie",
                LastName = "Charliesson",
                Email = "Charlie.Charliesson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Bostadsvägen 3",
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            listOfCustomers.Add(customer3);

            Customer customer4 = new Customer
            {
                FirstName = "Daniella",
                LastName = "Daniellassson",
                Email = "Daniella.Daniellasson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Huvudleden 4",
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            listOfCustomers.Add(customer4);

            Customer customer5 = new Customer
            {
                FirstName = "Erik",
                LastName = "Eriksson",
                Email = "Erik.Eriksson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Sidbanan 5",
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            listOfCustomers.Add(customer5);

            Customer customer6 = new Customer
            {
                FirstName = "Filip",
                LastName = "Filipsson",
                Email = "Filip.Filipsson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Parkområdet 6",
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            listOfCustomers.Add(customer6);

            Customer customer7 = new Customer
            {
                FirstName = "Gabriella",
                LastName = "Gabriellasson",
                Email = "Gabriella.Gabriellasson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Skogsberget 7",
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            listOfCustomers.Add(customer7);

            Customer customer8 = new Customer
            {
                FirstName = "Henry",
                LastName = "Henrysson",
                Email = "Henry.Henrysson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Gatuleden 8",
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            listOfCustomers.Add(customer8);

            Customer customer9 = new Customer
            {
                FirstName = "Ingrid",
                LastName = "Ingridsson",
                Email = "Ingrid.Ingridsson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Hamnleden 9",
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            listOfCustomers.Add(customer9);

            Customer customer10 = new Customer
            {
                FirstName = "Johan",
                LastName = "Johansson",
                Email = "Johan.Johansson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Stiggatan 10",
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            listOfCustomers.Add(customer10);

            Customer customer11 = new Customer
            {
                FirstName = "Karl",
                LastName = "Karlsson",
                Email = "Karl.Karlsson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Platstorget 11",
                FinishedCourses = new List<CourseCustomerFinished>()

            };
            listOfCustomers.Add(customer11);

            Customer customer12 = new Customer
            {
                FirstName = "Lennart",
                LastName = "Lennartsson",
                Email = "Lennart.Lennartsson@mail.com",
                PhoneNumber = "07098765432",
                Address = "Storstigen 12",
                FinishedCourses = new List<CourseCustomerFinished>()
            };
            listOfCustomers.Add(customer12);

            foreach (var course in coursesList)
            {
                if (course.CourseName == "Webbutveckling")
                {
                    customer10.CurrentCourse = new CourseCustomerCurrent{CustomerId = customer10.Id, CourseId = course.CourseId};
                    customer11.CurrentCourse = new CourseCustomerCurrent{CustomerId = customer11.Id, CourseId = course.CourseId};
                    customer12.CurrentCourse = new CourseCustomerCurrent{CustomerId = customer12.Id, CourseId = course.CourseId};
                    customer7.FinishedCourses.Add(new CourseCustomerFinished{CustomerId = customer7.Id, CourseId = course.CourseId});
                    customer5.FinishedCourses.Add(new CourseCustomerFinished{CustomerId = customer5.Id, CourseId = course.CourseId});
                    break;
                }
            }

            foreach (var course in coursesList)
            {
                if (course.CourseName == "SQL")
                {
                    customer7.CurrentCourse = new CourseCustomerCurrent{CustomerId = customer7.Id, CourseId = course.CourseId};
                    customer8.CurrentCourse = new CourseCustomerCurrent{CustomerId = customer8.Id, CourseId = course.CourseId};
                    customer9.CurrentCourse = new CourseCustomerCurrent{CustomerId = customer9.Id, CourseId = course.CourseId};
                    customer1.FinishedCourses.Add(new CourseCustomerFinished{CustomerId = customer1.Id, CourseId = course.CourseId});
                    customer4.FinishedCourses.Add(new CourseCustomerFinished{CustomerId = customer4.Id, CourseId = course.CourseId});
                    customer5.FinishedCourses.Add(new CourseCustomerFinished{CustomerId = customer5.Id, CourseId = course.CourseId});
                    customer3.FinishedCourses.Add(new CourseCustomerFinished{CustomerId = customer3.Id, CourseId = course.CourseId});
                    break;
                }
            }

            foreach (var course in coursesList)
            {
                if (course.CourseName == "Java Fullstack")
                {
                    customer4.CurrentCourse = new CourseCustomerCurrent{CustomerId = customer4.Id, CourseId = course.CourseId};
                    customer5.CurrentCourse = new CourseCustomerCurrent{CustomerId = customer5.Id, CourseId = course.CourseId};
                    customer6.CurrentCourse = new CourseCustomerCurrent{CustomerId = customer6.Id, CourseId = course.CourseId};
                    customer1.FinishedCourses.Add(new CourseCustomerFinished{CustomerId = customer1.Id, CourseId = course.CourseId});
                    break;
                }
            }

            foreach (var course in coursesList)
            {
                if (course.CourseName == ".NET Fullstack")
                {
                    customer1.CurrentCourse = new CourseCustomerCurrent{CustomerId = customer1.Id, CourseId = course.CourseId};
                    customer2.CurrentCourse = new CourseCustomerCurrent{CustomerId = customer2.Id, CourseId = course.CourseId};
                    customer3.CurrentCourse = new CourseCustomerCurrent{CustomerId = customer3.Id, CourseId = course.CourseId};
                    customer6.FinishedCourses.Add(new CourseCustomerFinished{CustomerId = customer6.Id, CourseId = course.CourseId});
                    break;
                }
            }

            await _context.Customers.AddRangeAsync(listOfCustomers);
            await _context.SaveChangesAsync();

            return true;

        }

        public static async Task<bool> SeedTeachers(EducationContext _context)
        {
            if (await _context.Teachers.AnyAsync())
            {
                return false;
            }

            var listOfTeachers = new List<Teacher>();

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
            listOfTeachers.Add(teacher1);

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
            listOfTeachers.Add(teacher2);

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
            listOfTeachers.Add(teacher3);

            await _context.Teachers.AddRangeAsync(listOfTeachers);
            await _context.SaveChangesAsync();

            return true;
        }

        public static async Task<bool> SeedCourses(EducationContext _context)
        {
            if (await _context.Courses.AnyAsync())
            {
                return false;
            }

            var listOfCourses = await _context.Courses.ToListAsync();

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
            listOfCourses.Add(course1);

            Course course2 = new Course
            {
                CourseNumber = 1002,
                CourseName = "Java Fullstack",
                Duration = 24,
                Category = "Java",
                Description = "Lorem ipsum dolor",
                Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            };
            course2.Teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.FirstName == "Bengt");
            listOfCourses.Add(course2);

            Course course3 = new Course
            {
                CourseNumber = 1003,
                CourseName = "SQL",
                Duration = 24,
                Category = "Databas",
                Description = "Lorem ipsum dolor",
                Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            };
            course3.Teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.FirstName == "Calle");
            listOfCourses.Add(course3);

            Course course4 = new Course
            {
                CourseNumber = 1004,
                CourseName = "Webbutveckling",
                Duration = 24,
                Category = "Webbutveckling",
                Description = "Lorem ipsum dolor",
                Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            };
            course4.Teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.FirstName == "Bengt");
            listOfCourses.Add(course4);

            await _context.Courses.AddRangeAsync(listOfCourses);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}