using ASP_NET_CORE_EF.CQRS.User.Commands;
using ASP_NET_CORE_EF.Data;
using ASP_NET_CORE_EF.Models;
namespace ASP_NET_CORE_EF.CQRS.User.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUserCommand, ASP_NET_CORE_EF.Models.User>
    {
        private readonly MyDbContext _context;

        public CreateUserHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<ASP_NET_CORE_EF.Models.User> Handle(CreateUserCommand command)
        {
            var user = new ASP_NET_CORE_EF.Models.User
            {
                Name = command.Name
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
