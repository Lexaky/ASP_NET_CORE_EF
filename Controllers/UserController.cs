// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using ASP_NET_CORE_EF.Data;
using ASP_NET_CORE_EF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ASP_NET_CORE_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _context;

        public UsersController(MyDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "adm")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        [Authorize(Roles = "visitor, adm")]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }
        [Authorize(Roles = "visitor, adm")]
        [HttpPut]
        public async Task<IActionResult> PutUser(int id, string name)
        {
            if (await _context.Users.AnyAsync(u => u.Id == id))
            {
                return BadRequest("User with the same ID already exists.");
            }

            if (!Regex.IsMatch(name, "^[a-zA-Z]+$"))
            {
                return BadRequest("Name must contain only english letters.");
            }

            // Добавляем нового пользователя
            var user = new User
            {
                Id = id,
                Name = name
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PutUser), new { id = user.Id }, user);
        }


    }
}
