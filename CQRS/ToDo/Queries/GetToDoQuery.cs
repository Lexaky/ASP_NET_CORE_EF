namespace ASP_NET_CORE_EF.CQRS.ToDo.Queries
{
    public class GetToDoQuery : IQuery<ASP_NET_CORE_EF.Models.ToDo>
    {
        public int Id { get; set; }
    }
}
