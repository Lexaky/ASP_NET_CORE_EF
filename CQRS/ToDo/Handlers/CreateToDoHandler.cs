using ASP_NET_CORE_EF.CQRS.ToDo.Commands;
using ASP_NET_CORE_EF.Data;
using ASP_NET_CORE_EF.Models;
using Microsoft.EntityFrameworkCore;
namespace ASP_NET_CORE_EF.CQRS.ToDo.Handlers
{
    public class CreateToDoHandler : ICommandHandler<CreateToDoCommand, ASP_NET_CORE_EF.Models.ToDo>
    {
        private readonly MyDbContext _context;

        public CreateToDoHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<ASP_NET_CORE_EF.Models.ToDo> Handle(CreateToDoCommand command)
        {
            var task = new ASP_NET_CORE_EF.Models.ToDo
            {
                Text = command.Text,
                Deadline = command.Deadline
            };
            _context.ToDos.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }
    }
}
