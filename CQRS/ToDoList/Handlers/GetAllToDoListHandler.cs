using ASP_NET_CORE_EF.CQRS.ToDoList.Queries;
using ASP_NET_CORE_EF.Data;
using ASP_NET_CORE_EF.Models;
using Microsoft.EntityFrameworkCore;
namespace ASP_NET_CORE_EF.CQRS.ToDoList.Handlers
{
    public class GetAllToDoListsHandler : IQueryHandler<GetAllToDoListsQuery, IEnumerable<ASP_NET_CORE_EF.Models.ToDoList>>
    {
        private readonly MyDbContext _context;

        public GetAllToDoListsHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ASP_NET_CORE_EF.Models.ToDoList>> Handle(GetAllToDoListsQuery query)
        {
            return await _context.ToDoLists.ToListAsync();
        }
    }
}
