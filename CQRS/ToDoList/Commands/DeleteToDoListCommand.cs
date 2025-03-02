namespace ASP_NET_CORE_EF.CQRS.ToDoList.Commands
{
    public class DeleteToDoListCommand : ICommand<bool>
    {
        public int Id { get; set; }
    }
}
