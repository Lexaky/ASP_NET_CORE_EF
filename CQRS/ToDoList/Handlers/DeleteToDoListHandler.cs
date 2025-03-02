using ASP_NET_CORE_EF.CQRS.ToDoList.Commands;
using ASP_NET_CORE_EF.Data;

namespace ASP_NET_CORE_EF.CQRS.ToDoList.Handlers
{
    public class DeleteToDoListHandler : ICommandHandler<DeleteToDoListCommand, bool>
    {
        private readonly MyDbContext _context;

        public DeleteToDoListHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteToDoListCommand command)
        {
            var list = await _context.ToDoLists.FindAsync(command.Id);

            if (list == null)
            {
                return false;
            }

            _context.ToDoLists.Remove(list);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
