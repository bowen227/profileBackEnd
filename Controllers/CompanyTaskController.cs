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

    public class CompanyTaskController: Controller
    {
        private readonly TodoContext _context;

        public CompanyTaskController(TodoContext context)
        {
            _context = context;
        }

        // Route api/CompanyTask/{user}/{company}
        [HttpGet("{user}/{company}")]
        public async Task<IActionResult> GetTasksByCompany(string user, string company)
        {
            var tasks = await _context.TaskList.Where(x => x.userId == user && x.company == company).ToListAsync();

            if (tasks != null)
            {
                return Json(tasks);
            }

            return NotFound();
        }

        // Route api/CompanyTask
        [HttpPost]
        public async Task<IActionResult> AddNewTaskByCompany([FromBody]TaskModel task)
        {
            _context.TaskList.Add(task);
            await _context.SaveChangesAsync();
            return new ObjectResult(task);
        }

        // Route api/CompanyTask
        [HttpPut]
        public async Task<IActionResult> UpdateTaskByCompany([FromBody]TaskModel updatedTask)
        {
            var task = await _context.TaskList.FirstOrDefaultAsync(t => t.id == updatedTask.id);
            
            if (task != null)
            {
                task.task = updatedTask.task;
                task.completed = updatedTask.completed;
                await _context.SaveChangesAsync();
                return new ObjectResult(updatedTask);
            }

            return NotFound();
        }

        // Route api/CompanyTask/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskById(int id)
        {
            var task = await _context.TaskList.FirstOrDefaultAsync(t => t.id == id);

            if (task != null)
            {
                _context.TaskList.Remove(task);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }
    }
}