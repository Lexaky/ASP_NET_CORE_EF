// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using ASP_NET_CORE_EF.CQRS.User.Commands;
using ASP_NET_CORE_EF.CQRS.User.Queries;
using ASP_NET_CORE_EF.CQRS;
using ASP_NET_CORE_EF.Data;
using ASP_NET_CORE_EF.DTO;
using ASP_NET_CORE_EF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ASP_NET_CORE_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly ICommandHandler<CreateUserCommand, User> _createUserHandler;
        private readonly ICommandHandler<UpdateUserCommand, User> _updateUserHandler;
        private readonly ICommandHandler<DeleteUserCommand, bool> _deleteUserHandler;
        private readonly IQueryHandler<GetUserQuery, User> _getUserHandler;
        private readonly IQueryHandler<GetAllUserQuery, IEnumerable<User>> _getAllUsersHandler;

        public UserController(MyDbContext context,
            ICommandHandler<CreateUserCommand, User> createUserHandler,
            ICommandHandler<UpdateUserCommand, User> updateUserHandler,
        ICommandHandler<DeleteUserCommand, bool> deleteUserHandler,
            IQueryHandler<GetUserQuery, User> getUserHandler,
            IQueryHandler<GetAllUserQuery, IEnumerable<User>> getAllUsersHandler)
        {
            _context = context;
            _createUserHandler = createUserHandler;
            _updateUserHandler = updateUserHandler;
            _deleteUserHandler = deleteUserHandler;
            _getUserHandler = getUserHandler;
            _getAllUsersHandler = getAllUsersHandler;
        }

        [HttpGet]
        [Authorize(Roles = "user, admin")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersAll()
        {
            var query = new GetAllUserQuery();
            var users = await _getAllUsersHandler.Handle(query);
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "user, admin")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var query = new GetUserQuery { Id = id };
            var user = await _getUserHandler.Handle(query);

            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<User>> PostUser([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new CreateUserCommand
            {
                Name = userDTO.UserName
            };

            var user = await _createUserHandler.Handle(command);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutUser(int id, [FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new UpdateUserCommand
            {
                Id = id,
                Name = userDTO.UserName
            };

            var user = await _updateUserHandler.Handle(command);

            if (user == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var command = new DeleteUserCommand { Id = id };
            var result = await _deleteUserHandler.Handle(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
