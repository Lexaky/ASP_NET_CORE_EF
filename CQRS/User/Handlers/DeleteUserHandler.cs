using ASP_NET_CORE_EF.CQRS.User.Commands;
using ASP_NET_CORE_EF.Data;

namespace ASP_NET_CORE_EF.CQRS.User.Handlers
{
    public class DeleteUserHandler : ICommandHandler<DeleteUserCommand, bool>
    {
        private readonly MyDbContext _context;

        public DeleteUserHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteUserCommand command)
        {
            var user = await _context.Users.FindAsync(command.Id);

            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
