using ASP_NET_CORE_EF.CQRS.ToDo.Commands;
using Microsoft.EntityFrameworkCore;
using ASP_NET_CORE_EF.Data;
using ASP_NET_CORE_EF.Models;
using static System.Net.Mime.MediaTypeNames;
namespace ASP_NET_CORE_EF.CQRS.ToDo.Handlers
{
    public class UpdateToDoHandler : ICommandHandler<UpdateToDoCommand, ASP_NET_CORE_EF.Models.ToDo>
    {
        private readonly MyDbContext _context;

        public UpdateToDoHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<ASP_NET_CORE_EF.Models.ToDo> Handle(UpdateToDoCommand command)
        {
            var task = await _context.ToDos.FindAsync(command.Id);

            if (task == null)
            {
                return null;
            }

            task.Text = command.Text;
            task.Deadline = command.Deadline;

            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return task;
        }
    }
}
