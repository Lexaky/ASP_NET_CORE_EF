// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using ASP_NET_CORE_EF.CQRS.ToDo.Commands;
using ASP_NET_CORE_EF.CQRS.ToDo.Queries;
using ASP_NET_CORE_EF.CQRS;
using ASP_NET_CORE_EF.Data;
using ASP_NET_CORE_EF.DTO;
using ASP_NET_CORE_EF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_CORE_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly ICommandHandler<CreateToDoCommand, ToDo> _createToDoHandler;
        private readonly ICommandHandler<UpdateToDoCommand, ToDo> _updateToDoHandler;
        private readonly ICommandHandler<DeleteToDoCommand, bool> _deleteToDoHandler;
        private readonly IQueryHandler<GetToDoQuery, ToDo> _getToDoHandler;
        private readonly IQueryHandler<GetAllToDosQuery, IEnumerable<ToDo>> _getAllToDosHandler;

        public ToDoController(MyDbContext context,
            ICommandHandler<CreateToDoCommand, ToDo> createToDoHandler,
            ICommandHandler<UpdateToDoCommand, ToDo> updateToDoHandler,
            ICommandHandler<DeleteToDoCommand, bool> deleteToDoHandler,
            IQueryHandler<GetToDoQuery, ToDo> getToDoHandler,
            IQueryHandler<GetAllToDosQuery, IEnumerable<ToDo>> getAllToDosHandler)
        {
            _context = context;
            _createToDoHandler = createToDoHandler;
            _updateToDoHandler = updateToDoHandler;
            _deleteToDoHandler = deleteToDoHandler;
            _getToDoHandler = getToDoHandler;
            _getAllToDosHandler = getAllToDosHandler;
        }

        [HttpGet]
        [Authorize(Roles = "user, admin")]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetTaskAll()
        {
            var query = new GetAllToDosQuery();
            var tasks = await _getAllToDosHandler.Handle(query);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "user, admin")]
        public async Task<ActionResult<ToDo>> GetTask(int id)
        {
            var query = new GetToDoQuery { Id = id };
            var task = await _getToDoHandler.Handle(query);

            if (task == null)
            {
                return NotFound();
            }
            return task;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<ToDo>> PostTask([FromBody] ToDoDTO taskDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new CreateToDoCommand
            {
                Text = taskDTO.Text,
                CreatedAt = taskDTO.CreatedAt,
                Deadline = taskDTO.Deadline
            };

            var task = await _createToDoHandler.Handle(command);

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutTask(int id, [FromBody] ToDoDTO taskDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new UpdateToDoCommand
            {
                Id = id,
                Text = taskDTO.Text,
                CreatedAt = taskDTO.CreatedAt,
                Deadline = taskDTO.Deadline
            };

            var task = await _updateToDoHandler.Handle(command);

            if (task == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var command = new DeleteToDoCommand { Id = id };
            var result = await _deleteToDoHandler.Handle(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
