using ASP_NET_CORE_EF.CQRS.ToDo.Commands;
using ASP_NET_CORE_EF.Data;

namespace ASP_NET_CORE_EF.CQRS.ToDo.Handlers
{
    public class DeleteToDoHandler : ICommandHandler<DeleteToDoCommand, bool>
    {
        private readonly MyDbContext _context;

        public DeleteToDoHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteToDoCommand command)
        {
            var task = await _context.ToDos.FindAsync(command.Id);

            if (task == null)
            {
                return false;
            }

            _context.ToDos.Remove(task);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
