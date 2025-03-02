using ASP_NET_CORE_EF.CQRS.ToDo.Queries;
using ASP_NET_CORE_EF.Data;
using ASP_NET_CORE_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_CORE_EF.CQRS.ToDo.Handlers
{
    public class GetAllToDoHandler : IQueryHandler<GetAllToDosQuery, IEnumerable<ASP_NET_CORE_EF.Models.ToDo>>
    {
        private readonly MyDbContext _context;

        public GetAllToDoHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ASP_NET_CORE_EF.Models.ToDo>> Handle(GetAllToDosQuery query)
        {
            return await _context.ToDos.ToListAsync();
        }
    }
}
