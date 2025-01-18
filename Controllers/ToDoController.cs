using ASP_NET_CORE_EF.Data;
using ASP_NET_CORE_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_CORE_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ToDoController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetAllToDos()
        {
            var toDos = await _context.ToDos.ToListAsync();
            return Ok(toDos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDo([FromBody] ToDo newToDo)
        {
            if (newToDo == null)
            {
                return BadRequest();
            }

            _context.ToDos.Add(newToDo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateToDo), new { id = newToDo.Id }, newToDo);
        }

        // Запись юзера в бд без дедлайна
        [HttpPut("simple")]
        public async Task<IActionResult> PutToDoSimple(string text)
        {
            var toDo = new ToDo
            {
                Text = string.IsNullOrEmpty(text) ? "Undefined Task" : text,
                Deadline = DateTime.Now
            };

            _context.ToDos.Add(toDo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PutToDoSimple), new { id = toDo.Id }, toDo);
        }

        // Запись с дедлайном
        [HttpPut("with-deadline")]
        public async Task<IActionResult> PutToDoWithDeadline(string text, DateTime deadline)
        {
            // Создаем задачу с указанным временем Deadline
            var toDo = new ToDo
            {
                Text = string.IsNullOrEmpty(text) ? "Undefined Task" : text,
                Deadline = deadline
            };

            _context.ToDos.Add(toDo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PutToDoWithDeadline), new { id = toDo.Id }, toDo);
        }


    }
}
