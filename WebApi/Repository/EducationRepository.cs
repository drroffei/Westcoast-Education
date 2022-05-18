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

        public Task CreateCourseAsync(Course model)
        {
            throw new NotImplementedException();
        }

        public void DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> GetCoursesByCategoryAsync(string category)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Course>> ListAllCourseAsync()
        {
            return await _context.Courses.ToListAsync(); 
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateCourse(int id, Course model)
        {
            throw new NotImplementedException();
        }
    }
}