#nullable disable

using EmployeeManagement.Server.Data;
using EmployeeManagement.Server.Models;
using EmployeeManagement.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorClientAD.Server.Controllers
{
    [Authorize]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ProductContext _context;
        private readonly ILogger<SkillsController> _logger;

        public SkillsController(ProductContext context, ILogger<SkillsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/Skills/GetAsync")]
        public async Task<List<SkillsDTO>> GetAsync()
        {
            List<SkillsDTO> res = new List<SkillsDTO>();

            try
            {
                var result = await _context.Skills.AsNoTracking().ToListAsync();

                foreach (var item in result)
                {
                    SkillsDTO skillsDTO = new SkillsDTO();
                    skillsDTO.Id = item.Id;
                    skillsDTO.Name = item.Name;
                    skillsDTO.Description = item.Description;
                    res.Add(skillsDTO);
                }
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return res;
            }
        }

        [HttpGet]
        [Route("api/Skills/GetAsyncByEmployeeId")]
        public async Task<List<SelectedSkillsDTO>> GetAsyncByEmployeeId(int employeeId)
        {
            List<SelectedSkillsDTO> res = new List<SelectedSkillsDTO>();

            try
            {
                var skills = await _context.Skills.AsNoTracking().ToListAsync();
                var employyeandskills = await _context.EmployeesAndSkills.Where(x => x.EmployeeId.Equals(employeeId)).AsNoTracking().ToListAsync();

                foreach (var skill in skills)
                {
                    SelectedSkillsDTO newSkill = new SelectedSkillsDTO()
                    {
                        Id = skill.Id,
                        Name = skill.Name,
                        Description = skill.Description,
                        IsSelected = employyeandskills.Any(y => y.SkillId == skill.Id)
                    };
                    res.Add(newSkill);
                }

                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return res;
            }
        }

        [HttpPost]
        [Route("api/Skills/Post")]
        public void Post([FromBody] SkillsDTO paramSkills)
        {
            try
            {
                Skills objSkills = new Skills();
                objSkills.Id = paramSkills.Id;
                objSkills.Name = paramSkills.Name;
                objSkills.Description = paramSkills.Description;
                _context.Skills.Add(objSkills);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/Skills/Put")]
        public void Put([FromBody] SkillsDTO objSkills)
        {
            try
            {
                var ExistingSkills = _context.Skills.Where(x => x.Id == objSkills.Id).FirstOrDefault();
                if (ExistingSkills != null)
                {
                    ExistingSkills.Name = objSkills.Name;
                    ExistingSkills.Description = objSkills.Description;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/Skills/Delete/{id}")]
        public void Delete(int id)
        {
            try
            {
                var ExistingSkills = _context.Skills.Where(x => x.Id == id).FirstOrDefault();

                if (ExistingSkills != null)
                {
                    _context.Skills.Remove(ExistingSkills);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}