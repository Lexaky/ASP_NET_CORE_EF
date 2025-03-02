using ASP_NET_CORE_EF.CQRS.ToDo.Queries;
using ASP_NET_CORE_EF.Data;
using ASP_NET_CORE_EF.Models;
using Microsoft.EntityFrameworkCore;
namespace ASP_NET_CORE_EF.CQRS.ToDo.Handlers
{
    public class GetToDoHandler : IQueryHandler<GetToDoQuery, ASP_NET_CORE_EF.Models.ToDo>
    {
        private readonly MyDbContext _context;

        public GetToDoHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<ASP_NET_CORE_EF.Models.ToDo> Handle(GetToDoQuery query)
        {
            return await _context.ToDos.FindAsync(query.Id);
        }
    }
}
