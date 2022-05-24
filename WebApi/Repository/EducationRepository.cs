using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;
using webapi.ViewModels;
using webapi.ViewModels.Customers;
using webapi.ViewModels.Teachers;

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


    //------------------------------|  Courses methods here  |------------------------------//

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
				return($"No course with id {id} was found, nothing was removed");
			}
			else
			{
				_context.Courses.Remove(response);
				return($"Course with id {id} was removed from the database");
			}
		}

		public async Task<List<CourseViewModel>> GetCoursesByCategoryAsync(string category)
		{
			var result = await _context.Courses.Where(c => c.Category!.ToLower().Contains(category.ToLower())).ToListAsync();
			List<CourseViewModel> listOfCourses = new List<CourseViewModel>();
			foreach (var course in result)
			{
				CourseViewModel courseVM = new CourseViewModel
				{
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
				CourseViewModel courseVM = new CourseViewModel
				{
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

    //------------------------------|  Teachers Methods here  |------------------------------//

		public async Task<List<TeacherViewModel>> ListAllTeachersAsync()
		{
			var response = await _context.Teachers.Include(t => t.TeacherSkill).ToListAsync();
			var listTeacherVM = new List<TeacherViewModel>();
			foreach (var teacher in response)
			{
				TeacherViewModel teacherVM = new TeacherViewModel
				{
          FirstName = teacher.FirstName,
          LastName = teacher.LastName,
          Skills = new List<SkillViewModel>()
				};
				foreach (var skill in teacher.TeacherSkill)
				{
          teacherVM.Skills.Add(new SkillViewModel { SkillName = skill.SkillName });
				}
				listTeacherVM.Add(teacherVM);
			}
			return listTeacherVM;
		}

    public async Task<TeacherViewModel> GetTeacherWithIdAsync(int id)
    {
      var response = await _context.Teachers.Include(t => t.TeacherSkill).FirstOrDefaultAsync(t => t.Id == id);
      if (response == null)
      {
        throw new Exception($"No teacher with id {id} was found");
      }

      var listSkillsVM = new List<SkillViewModel>();

      foreach (var skill in response.TeacherSkill)
      {
        var skillVM = _mapper.Map<SkillViewModel>(skill);
        listSkillsVM.Add(skillVM);
      }

      TeacherViewModel teacherVM = new TeacherViewModel{
        FirstName = response.FirstName,
        LastName = response.LastName,
        Skills = listSkillsVM
      };
      return teacherVM;
    }

    public async Task CreateNewTeacherAsync(PostTeacherViewModel model)
    {
      var listOfSkillVM = model.TeacherSkill;
      var listOfExistingSkills = await _context.Skills.ToListAsync();
      var listOfSkills = new List<Skill>();

      foreach (var skillVM in listOfSkillVM)
      {
        bool skillExist = false;
        Skill skill = _mapper.Map<Skill>(skillVM);

        foreach (var existingSkill in listOfExistingSkills)
        {
          if (skill.SkillName == existingSkill.SkillName)
          {
            listOfSkills.Add(existingSkill);
            skillExist = true;
            break;
          }
        }
        if (!skillExist)
        {
          await _context.Skills.AddAsync(skill);
          listOfSkills.Add(skill);          
        }
      }

      Teacher teacher = new Teacher{
        FirstName = model.FirstName,
        LastName = model.LastName,
        Email = model.Email,
        PhoneNumber = model.PhoneNumber,
        Address = model.Address,
        TeacherSkill = listOfSkills
      };

      await _context.Teachers.AddAsync(teacher);
    }

    public async Task UpdateTeacherAsync(int id, PostTeacherViewModel model)
    {
      var teacherToUpdate = await _context.Teachers.Include(t => t.TeacherSkill).FirstOrDefaultAsync(t => t.Id == id);
      if (teacherToUpdate == null)
      {
        return;
      }

      var listOfSkillVM = model.TeacherSkill;
      var listOfExistingSkills = await _context.Skills.ToListAsync();
      var listOfSkills = new List<Skill>();

      foreach (var skillVM in listOfSkillVM)
      {
        bool skillExist = false;
        Skill skill = _mapper.Map<Skill>(skillVM);

        foreach (var existingSkill in listOfExistingSkills)
        {
          if (skill.SkillName == existingSkill.SkillName)
          {
            listOfSkills.Add(existingSkill);
            skillExist = true;
            break;
          }
        }
        if (!skillExist)
        {
          await _context.Skills.AddAsync(skill);
          listOfSkills.Add(skill);          
        }
      }
      teacherToUpdate.FirstName = model.FirstName;
      teacherToUpdate.LastName = model.LastName;
      teacherToUpdate.Email = model.Email;
      teacherToUpdate.PhoneNumber = model.PhoneNumber;
      teacherToUpdate.Address = model.Address;
      teacherToUpdate.TeacherSkill = listOfSkills;

      _context.Teachers.Update(teacherToUpdate);
    }


    public async Task DeleteTeacherAsync(int id)
    {
      var response = await _context.Teachers.FindAsync(id);
      if (response == null)
      {
        return;
      }

      _context.Teachers.Remove(response);
    }

    
    //------------------------------|  Customer Methods here  |------------------------------//

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
				listCustomerVM.Add(customerVM);
			}

			return listCustomerVM;
		}

    public async Task<CustomerViewModel> GetCustomerWithIdAsync(int id)
    {
      var response = await _context.Customers.FindAsync(id);
      var customerVM = _mapper.Map<CustomerViewModel>(response);
      return customerVM;
    }


    public async Task CreateCustomerAsync(PostCustomerViewModel model)
    {
      var customerToAdd = _mapper.Map<Customer>(model);
      await _context.Customers.AddAsync(customerToAdd);
    }

    public async Task UpdateCustomerAsync(int id, PostCustomerViewModel model)
    {
      var customer = await _context.Customers.FindAsync(id);
      if (customer == null)
      {        
        return;
      }
      _mapper.Map<PostCustomerViewModel, Customer>(model, customer);

      _context.Customers.Update(customer);
    }

    public async Task DeleteCustomerAsync(int id)
    {
      var response = await _context.Customers.FindAsync(id);
      if (response == null)
      {
        return;
      }
      _context.Customers.Remove(response);      
    }

		public async Task<List<CourseCustomerCurrentViewModel>> ListCustomersAndCurrentCourses()
		{
			var response = await _context.CourseCustomerCurrent.Include(c => c.Customer).Include(c => c.Course).ToListAsync();
			List<CourseCustomerCurrentViewModel> listCCVM = new List<CourseCustomerCurrentViewModel>();

			foreach (var courseCustomer in response)
			{
				var course = courseCustomer.Course;
				var courseVM = _mapper.Map<CourseViewModel>(course);
				var customer = courseCustomer.Customer;
				var customerVM = _mapper.Map<CustomerViewModel>(customer);

				listCCVM.Add(
					new CourseCustomerCurrentViewModel
					{
						CourseVM = courseVM,
						CustomerVM = customerVM
					}
				);
			};

			return listCCVM;
		}
	}
}