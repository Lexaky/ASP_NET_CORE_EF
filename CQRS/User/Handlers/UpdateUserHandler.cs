using ASP_NET_CORE_EF.CQRS.User.Commands;
using ASP_NET_CORE_EF.Data;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_CORE_EF.CQRS.User.Handlers
{
    public class UpdateUserHandler : ICommandHandler<UpdateUserCommand, ASP_NET_CORE_EF.Models.User>
    {
        private readonly MyDbContext _context;

        public UpdateUserHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<ASP_NET_CORE_EF.Models.User> Handle(UpdateUserCommand command)
        {
            var user = await _context.Users.FindAsync(command.Id);

            if (user == null)
            {
                return null; // Или выбросить исключение
            }

            user.Name = command.Name;

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
