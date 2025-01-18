using ASP_NET_CORE_EF.Data;
using ASP_NET_CORE_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_CORE_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ToDoListsController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoList>>> GetToDoLists()
        {
            return await _context.ToDoLists
                                 .Include(t => t.ToDos)
                                 .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ToDoList>> PostToDoList(ToDoList toDoList)
        {
            _context.ToDoLists.Add(toDoList);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetToDoLists), new { id = toDoList.Id }, toDoList);
        }

        [HttpPut]
        public async Task<IActionResult> PutToDoList(int userId, int toDoId)
        {
            if (!await _context.Users.AnyAsync(u => u.Id == userId))
            {
                return BadRequest("User not found.");
            }

            if (!await _context.ToDos.AnyAsync(t => t.Id == toDoId))
            {
                return BadRequest("ToDo not found.");
            }

            var toDoList = new ToDoList
            {
                UserId = userId,
                ToDos = new List<ToDo> { await _context.ToDos.FindAsync(toDoId) }
            };

            _context.ToDoLists.Add(toDoList);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PutToDoList), new { id = toDoList.Id }, toDoList);
        }


    }
}
