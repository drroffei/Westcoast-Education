using AutoMapper;
using webapi.Models;
using webapi.ViewModels;
using webapi.ViewModels.Customers;
using WebApi.ViewModels.Teachers;

namespace webapi.Helpers
{
  public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Course, CourseViewModel>();
            CreateMap<PostCourseViewModel, Course>();

            CreateMap<Teacher, TeacherViewModel>();
            CreateMap<Skill, SkillViewModel>();
            CreateMap<SkillViewModel, Skill>();

            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Customer, CustomerDetailedViewModel>();
            CreateMap<PostCustomerViewModel, Customer>();

            CreateMap<Teacher, TeacherDetailsViewModel>();
        }
    }
}