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
    public class EmployeesController : ControllerBase
    {
        private readonly ProductContext _context;

        public EmployeesController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/Employees/GetAsync")]
        public async Task<List<EmployeesDTO>> GetAsync()
        {
            var result = await _context.Employees.AsNoTracking().ToListAsync();
            List<EmployeesDTO> res = new List<EmployeesDTO>();

            foreach (var item in result)
            {
                EmployeesDTO objEmployeesDTO = new EmployeesDTO();
                objEmployeesDTO.Id = item.Id;
                objEmployeesDTO.LastName = item.LastName;
                objEmployeesDTO.FirstName = item.FirstName;
                objEmployeesDTO.HiringDate = item.HiringDate;

                res.Add(objEmployeesDTO);
            }
            return res;
        }

        [HttpPost]
        [Route("api/Employees/Post")]
        public void Post([FromBody] EmployeesDTO paramEmployees)
        {
            Employees objEmployees = new Employees();
            objEmployees.Id = paramEmployees.Id;
            objEmployees.LastName = paramEmployees.LastName;
            objEmployees.FirstName = paramEmployees.FirstName;
            objEmployees.HiringDate = paramEmployees.HiringDate;

            _context.Employees.Add(objEmployees);
            _context.SaveChanges();
        }

        [HttpPost]
        [Route("api/Employees/PostSkills")]
        public void PostSkills([FromBody] List<SkillsDTO> selectedSkills, int employeeId)
        {
            var existingSkills = _context.EmployeesAndSkills.Where(x => x.EmployeeId == employeeId).ToList();
            foreach (var existingSkill in existingSkills)
            {
                _context.EmployeesAndSkills.Remove(existingSkill);
                _context.SaveChanges();
            }

            foreach (var skill in selectedSkills)
            {
                EmployeesAndSkills newSkill = new EmployeesAndSkills();
                newSkill.EmployeeId = employeeId;
                newSkill.SkillId = skill.Id;
                _context.EmployeesAndSkills.Add(newSkill);
                _context.SaveChanges();
            }
        }

        [HttpPut]
        [Route("api/Employees/Put")]
        public void Put([FromBody] EmployeesDTO objEmployees)
        {
            var ExistingEmployees = _context.Employees.Where(x => x.Id == objEmployees.Id).FirstOrDefault();
            if (ExistingEmployees != null)
            {
                ExistingEmployees.LastName = objEmployees.LastName;
                ExistingEmployees.FirstName = objEmployees.FirstName;
                ExistingEmployees.HiringDate = objEmployees.HiringDate;
                _context.SaveChanges();
            }
        }

        [HttpDelete]
        [Route("api/Employees/Delete/{id}")]
        public void Delete(int id)
        {
            var ExistingEmployees = _context.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (ExistingEmployees != null)
            {
                _context.Employees
                    .Remove(ExistingEmployees);
                _context.SaveChanges();
            }
        }
    }
}