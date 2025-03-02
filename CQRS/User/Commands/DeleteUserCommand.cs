namespace ASP_NET_CORE_EF.CQRS.User.Commands
{
    public class DeleteUserCommand : ICommand<bool>
    {
        public int Id { get; set; }
    }
}
