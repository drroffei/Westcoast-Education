using AutoMapper;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;
using webapi.ViewModels;
using webapi.ViewModels.Teachers;

namespace webapi.Repository
{
  public class TeacherRepository : ITeacherRepository
  {
    private readonly EducationContext _context;
    private readonly IMapper _mapper;
    public TeacherRepository(EducationContext context, IMapper mapper)
    {
      _mapper = mapper;
      _context = context;      
    }

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

    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }
  }
}