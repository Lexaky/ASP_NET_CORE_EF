namespace ASP_NET_CORE_EF.CQRS.ToDoList.Queries
{
    public class GetToDoListQuery : IQuery<ASP_NET_CORE_EF.Models.ToDoList>
    {
        public int Id { get; set; }
    }
}
