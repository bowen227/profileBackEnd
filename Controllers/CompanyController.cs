using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]

    public class CompanyController: Controller
    {
        private readonly TodoContext _context;

        public CompanyController(TodoContext context)
        {
            _context = context;
        }

        // Route api/Company/{user}
        [HttpGet("{user}")]
        public async Task<IActionResult> GetCompaniesByUser(string user)
        {
            List<CompanyModel> companies = await _context.CompanyList.Where(x => x.userId == user).ToListAsync();

            if (companies != null)
            {
                return Json(companies);
            }

            return NotFound();
        }
        
        // Route api/Company/{id}
        [HttpGet("byId/{id:int}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await _context.CompanyList.FirstOrDefaultAsync(c => c.id == id);

            if (company != null)
            {
                return Json(company);
            }

            return NotFound();
        }

        // Route api/Company
        [HttpPost]
        public async Task<IActionResult> AddNewCompany([FromBody]CompanyModel company)
        {
            if (company != null)
            {
                _context.CompanyList.Add(company);
                await _context.SaveChangesAsync();
                return new ObjectResult(company);
            }

            return StatusCode(400, "Company was null...");
            
        }

        // Route api/Company
        [HttpPut]
        public async Task<IActionResult> UpdateCompany([FromBody] CompanyModel updatedCompany)
        {
            var company = await _context.CompanyList.FirstOrDefaultAsync(c => c.id == updatedCompany.id);

            if (company != null)
            {
                company.companyName = updatedCompany.companyName;
                company.street = updatedCompany.street;
                company.city = updatedCompany.city;
                company.state = updatedCompany.state;
                company.zip = updatedCompany.zip;
                company.phone = updatedCompany.phone;
                company.fax = updatedCompany.fax;
                await _context.SaveChangesAsync();
                return new ObjectResult(updatedCompany);
            }

            return NotFound();
        }

        // Route api/Company
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _context.CompanyList.FirstOrDefaultAsync(c => c.id == id);

            if (company != null)
            {
                _context.CompanyList.Remove(company);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }
    }
}