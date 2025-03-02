namespace ASP_NET_CORE_EF.CQRS.User.Commands
{
    public class UpdateUserCommand : ICommand<ASP_NET_CORE_EF.Models.User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
