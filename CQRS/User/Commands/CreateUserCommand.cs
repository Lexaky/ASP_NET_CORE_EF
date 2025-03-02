namespace ASP_NET_CORE_EF.CQRS.User.Commands
{
    public class CreateUserCommand : ICommand<ASP_NET_CORE_EF.Models.User>
    {
        public string Name { get; set; }
    }
}
