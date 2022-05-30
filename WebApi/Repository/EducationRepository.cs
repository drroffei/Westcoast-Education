using AutoMapper;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;
using webapi.ViewModels;
using webapi.ViewModels.Teachers;
using WebApi.ViewModels.Courses;

namespace webapi.Repository
{
  public class EducationRepository : IEducationRepository
  {
    private readonly EducationContext _context;
    private readonly IMapper _mapper;
    public EducationRepository(EducationContext context, IMapper mapper)
    {
      _mapper = mapper;
      _context = context;
    }

    public async Task CreateCourseAsync(PostCourseViewModel model)
    {
      var response = await _context.Courses.FirstOrDefaultAsync(c => c.CourseNumber == model.CourseNumber);
      if (response != null)
      {
        Console.WriteLine("Coursenumber already exist");
        return;
      }

      var course = _mapper.Map<Course>(model);
      var teacherToAdd = await _context.Teachers.FirstOrDefaultAsync(t => t.Id == model.TeacherId);
      course.Teacher = teacherToAdd;

      await _context.Courses.AddAsync(course);
    }

    public async Task<string> DeleteCourse(int id)
    {
      var response = await _context.Courses.FindAsync(id);
      if (response == null)
      {
        return ($"No course with id {id} was found, nothing was removed");
      }
      else
      {
        _context.Courses.Remove(response);
        return ($"Course with id {id} was removed from the database");
      }
    }

    public async Task<List<CourseViewModel>> GetCoursesByCategoryAsync(string category)
    {
      var result = await _context.Courses.Where(c => c.Category!.ToLower().Contains(category.ToLower())).ToListAsync();

      List<CourseViewModel> listOfCoursesVM = new List<CourseViewModel>();
      foreach (var course in result)
      {
        CourseViewModel courseVM = new CourseViewModel
        {
          CourseId = course.CourseId,
          CourseNumber = course.CourseNumber,
          CourseName = course.CourseName,
          Duration = course.Duration
        };

        listOfCoursesVM.Add(courseVM);
      }
      return listOfCoursesVM;
    }
    public async Task<CourseDetailedViewModel> GetCourseByCoursenumberAsync(int courseNumber)
    {
      var response = await _context.Courses.FirstOrDefaultAsync(c => c.CourseNumber == courseNumber);

      if (response == null)
      {
        throw new Exception($"No course with coursenumber {courseNumber} was found");
      }

      CourseDetailedViewModel courseDetailedVM = new CourseDetailedViewModel
      {
        CourseId = response.CourseId,
        CourseNumber = response.CourseNumber,
        CourseName = response.CourseName,
        Duration = response.Duration,
        Category = response.Category,
        Description = response.Description,
        Details = response.Details
      };

      return courseDetailedVM;
    }

    public async Task<List<CourseViewModel>> ListAllCourseAsync()
    {
      var response = await _context.Courses.ToListAsync();

      List<CourseViewModel> listCourseVM = new List<CourseViewModel>();

      foreach (var course in response)
      {
        CourseViewModel courseVM = new CourseViewModel
        {
          CourseId = course.CourseId,
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

    public async Task UpdateCourse(int id, PostCourseViewModel model)
    {
      var course = await _context.Courses.FindAsync(id);
      if (course == null)
      {
        return;
      }

      _mapper.Map<PostCourseViewModel, Course>(model, course);

      _context.Courses.Update(course);
    }
  }
}