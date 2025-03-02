using ASP_NET_CORE_EF.CQRS.User.Queries;
using ASP_NET_CORE_EF.Data;

namespace ASP_NET_CORE_EF.CQRS.User.Handlers
{
    public class GetUserHandler : IQueryHandler<GetUserQuery, ASP_NET_CORE_EF.Models.User>
    {
        private readonly MyDbContext _context;

        public GetUserHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<ASP_NET_CORE_EF.Models.User> Handle(GetUserQuery query)
        {
            return await _context.Users.FindAsync(query.Id);
        }
    }
}
