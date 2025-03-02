using ASP_NET_CORE_EF.CQRS.ToDoList.Queries;
using ASP_NET_CORE_EF.Data;
using ASP_NET_CORE_EF.Models;
namespace ASP_NET_CORE_EF.CQRS.ToDoList.Handlers
{
    public class GetToDoListHandler : IQueryHandler<GetToDoListQuery, ASP_NET_CORE_EF.Models.ToDoList>
    {
        private readonly MyDbContext _context;

        public GetToDoListHandler(MyDbContext context)
        {
            _context = context;
        }

        public async Task<ASP_NET_CORE_EF.Models.ToDoList> Handle(GetToDoListQuery query)
        {
            return await _context.ToDoLists.FindAsync(query.Id);
        }
    }
}
