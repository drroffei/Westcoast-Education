using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;
using webapi.ViewModels;

namespace webapi.Repository
{
    public class EducationRepository : IEducationRepository
    {
        private readonly EducationContext _context;
        public EducationRepository(EducationContext context)
        {
            _context = context;
        }

        public async Task CreateCourseAsync(PostCourseViewModel model)
        {
            Course course = new Course{
                CourseNumber = model.CourseNumber,
                CourseName = model.CourseName,
                Duration = model.Duration,
                Category = model.Category,
                Description = model.Description,
                Details = model.Details,
                CurrentCustomers = new List<CourseCustomerCurrent>(),
                FinishedCustomers = new List<CourseCustomerFinished>(),                
            };

            await _context.Courses.AddAsync(course);
        }

        public void DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CourseViewModel>> GetCoursesByCategoryAsync(string category)
        {
            var result = await _context.Courses.Where(c => c.Category!.ToLower().Contains(category.ToLower())).ToListAsync();
            List<CourseViewModel> listOfCourses = new List<CourseViewModel>();
            foreach (var course in result)
            {   
                CourseViewModel courseVM = new CourseViewModel{
                    CourseNumber = course.CourseNumber,
                    CourseName = course.CourseName,
                    Duration = course.Duration                
                };

                listOfCourses.Add(courseVM);                
            }
            return listOfCourses;
        }
        public Task<CourseViewModel> GetCourseByCoursenumberAsync(int courseNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CourseViewModel>> ListAllCourseAsync()
        {
            var response = await _context.Courses.ToListAsync();

            List<CourseViewModel> listCourseVM = new List<CourseViewModel>();

            foreach (var course in response)
            {
                CourseViewModel courseVM = new CourseViewModel{
                    CourseNumber = course.CourseNumber,
                    CourseName = course.CourseName,
                    Duration = course.Duration,
                    };
                listCourseVM.Add(courseVM);
            }

            return listCourseVM;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateCourse(int id, PostCourseViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TeacherViewModel>> ListAllTeachersAsync()
        {
            var response = await _context.Teachers.ToListAsync();
            var listTeacherVM = new List<TeacherViewModel>();
            foreach (var teacher in response)
            {
                TeacherViewModel teacherVM = new TeacherViewModel{
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    Skills = teacher.TeacherSkill
                };
                listTeacherVM.Add(teacherVM);
            }

            return listTeacherVM;
        }
        public async Task<List<CustomerViewModel>> ListAllCustomersAsync()
        {
            var response = await _context.Customers.ToListAsync();
            var listCustomerVM = new List<CustomerViewModel>();
            foreach (var customer in response)
            {
                CustomerViewModel customerVM = new CustomerViewModel
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    Address = customer.Address
                };
            }

            return listCustomerVM;
        }
    }
}