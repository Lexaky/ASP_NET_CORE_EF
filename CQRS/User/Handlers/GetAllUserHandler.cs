using ASP_NET_CORE_EF.CQRS.User.Queries;
using ASP_NET_CORE_EF.Data;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_CORE_EF.CQRS.User.Handlers
{
    public class GetAllUsersHandler : IQueryHandler<GetAllUserQuery, IEnumerable<ASP_NET_CORE_EF.Models.User>>
    {
        private readonly MyDbContext _context;

        public GetAllUsersHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ASP_NET_CORE_EF.Models.User>> Handle(GetAllUserQuery query)
        {
            return await _context.Users.ToListAsync();
        }
    }
}
