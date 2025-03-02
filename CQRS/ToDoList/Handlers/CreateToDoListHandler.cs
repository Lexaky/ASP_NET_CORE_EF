using ASP_NET_CORE_EF.CQRS.ToDoList.Commands;
using ASP_NET_CORE_EF.Data;
using ASP_NET_CORE_EF.Models;

namespace ASP_NET_CORE_EF.CQRS.ToDoList.Handlers
{
    public class CreateToDoListHandler : ICommandHandler<CreateToDoListCommand, ASP_NET_CORE_EF.Models.ToDoList>
    {
        private readonly MyDbContext _context;

        public CreateToDoListHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<ASP_NET_CORE_EF.Models.ToDoList> Handle(CreateToDoListCommand command)
        {
            var list = new ASP_NET_CORE_EF.Models.ToDoList
            {
                UserId = command.UserId,
                Id = command.Id
            };

            _context.ToDoLists.Add(list);
            await _context.SaveChangesAsync();

            return list;
        }
    }
}
