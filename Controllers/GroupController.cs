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

    public class GroupController: Controller
    {
        private readonly TodoContext _context;

        public GroupController(TodoContext context)
        {
            _context = context;
        }

        // Route api/Group/{user}
        [HttpGet("{user}")]
        public async Task<IActionResult> GetGroupsByUser(string user)
        {
            List<TodoGroupModel> groups = await _context.GroupList.Where(x => x.userId == user).ToListAsync();

            if (groups != null)
            {
                return Json(groups);
            }

            return NotFound();
        }

        // Route api/Group
        [HttpPost]
        public async Task<IActionResult> AddNewGroup([FromBody]TodoGroupModel group)
        {
            _context.GroupList.Add(group);
            await _context.SaveChangesAsync();
            // return new ObjectResult(group);
            return new ObjectResult(new TodoGroupModel { id = group.id, groupName = group.groupName });
        }

        // Route api/Group/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroup(int id, [FromBody] TodoGroupModel updatedGroup)
        {
            var group = await _context.GroupList.FirstOrDefaultAsync(g => g.id == id);
            
            if (group != null)
            {
                group.groupName = updatedGroup.groupName;
                await _context.SaveChangesAsync();
                return new ObjectResult(new TodoGroupModel { id = group.id, groupName = group.groupName });
            }

            return NotFound();
        }

        // Route api/Group/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var group = await _context.GroupList.FirstOrDefaultAsync(g => g.id == id);
            
            if (group != null)
            {
                _context.GroupList.Remove(group);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }
    }
}