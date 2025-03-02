using ASP_NET_CORE_EF.CQRS.ToDoList.Commands;
using Microsoft.EntityFrameworkCore;
using ASP_NET_CORE_EF.Models;
using ASP_NET_CORE_EF.Data;
namespace ASP_NET_CORE_EF.CQRS.ToDoList.Handlers
{
    public class UpdateToDoListHandler : ICommandHandler<UpdateToDoListCommand, ASP_NET_CORE_EF.Models.ToDoList>
    {
        private readonly MyDbContext _context;

        public UpdateToDoListHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<ASP_NET_CORE_EF.Models.ToDoList> Handle(UpdateToDoListCommand command)
        {
            var list = await _context.ToDoLists.FindAsync(command.Id);

            if (list == null)
            {
                return null; // Или выбросить исключение
            }

            list.UserId = command.UserID;
            list.Id = command.Id;

            _context.Entry(list).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return list;
        }
    }
}
