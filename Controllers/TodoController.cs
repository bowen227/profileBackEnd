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
    public class TodoController: Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }

        // Route api/Todo/{user}/{group}
        [HttpGet("{user}/{group}")]
        public async Task<IActionResult> GetTodosByGroup(string user, string group)
        {
            var todos = await _context.ItemList.Where(x => x.userId == user && x.groupName == group).ToListAsync();

            if (todos != null)
            {
                return Json(todos);
            }

            return NotFound();
        }

        // Route api/Todo/
        [HttpPost]
        public async Task<IActionResult> AddNewTodo([FromBody]TodoItemModel todo)
        {
            _context.ItemList.Add(todo);
            await _context.SaveChangesAsync();
            return new ObjectResult(todo);
        }

        // Route api/Todo/
        [HttpPut]
        public async Task<IActionResult> UpdateTodo([FromBody]TodoItemModel updatedTodo)
        {
            var todo = await _context.ItemList.FirstOrDefaultAsync(t => t.id == updatedTodo.id);

            if (todo != null)
            {
                todo.todo = updatedTodo.todo;
                todo.completed = updatedTodo.completed;
                await _context.SaveChangesAsync();
                return new ObjectResult(todo);
            }

            return NotFound();
        }

        // Route api/Todo/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var todo = await _context.ItemList.FirstOrDefaultAsync(t => t.id == id);

            if (todo != null)
            {
                _context.ItemList.Remove(todo);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }
    }
}