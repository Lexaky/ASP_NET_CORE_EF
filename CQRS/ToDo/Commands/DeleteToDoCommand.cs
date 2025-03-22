namespace ASP_NET_CORE_EF.CQRS.ToDo.Commands
{
    public class DeleteToDoCommand : ICommand<bool>
    {
        public int Id { get; set; }
    }
}
