namespace ASP_NET_CORE_EF.CQRS.User.Queries
{
    public class GetUserQuery : IQuery<ASP_NET_CORE_EF.Models.User>
    {
        public int Id { get; set; }
    }
}
