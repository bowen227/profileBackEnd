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

    public class CompanyContactsController: Controller
    {
        private readonly TodoContext _context;

        public CompanyContactsController(TodoContext context)
        {
            _context = context;
        }

        // Route api/CompanyContacts/{user}
        [HttpGet("{user}/{company}")]
        public async Task<IActionResult> GetCompanyContactsByCompany(string user, string company)
        {
            var contacts = await _context.CompanyContactList.Where(x => x.userId == user && x.companyName == company).ToListAsync();
            
            if (contacts != null)
            {
                return Json(contacts);
            }

            return NotFound();
        }

        // Route api/CompanyContacts
        [HttpPost]
        public async Task<IActionResult> AddNewCompanyContact([FromBody]CompanyContactsModel contact)
        {
            _context.CompanyContactList.Add(contact);
            await _context.SaveChangesAsync();
            return new ObjectResult(contact);
        }

        // Route api/CompanyContacts
        [HttpPut]
        public async Task<IActionResult> UpdateCompanyContact([FromBody]CompanyContactsModel updatedContact)
        {
            var contact = await _context.CompanyContactList.FirstOrDefaultAsync(c => c.id == updatedContact.id);

            if (contact != null)
            {
                contact.companyName = updatedContact.companyName;
                contact.firstName = updatedContact.firstName;
                contact.lastName = updatedContact.lastName;
                contact.phone = updatedContact.phone;
                contact.email = updatedContact.email;
                contact.title = updatedContact.title;
                await _context.SaveChangesAsync();
                return new ObjectResult(updatedContact);
            }

            return NotFound();
        }

        // Route api/CompanyContacts/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyContact(int id)
        {
            var contact = await _context.CompanyContactList.FirstOrDefaultAsync(c => c.id == id);
            
            if (contact != null)
            {
                _context.CompanyContactList.Remove(contact);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }
    }
}