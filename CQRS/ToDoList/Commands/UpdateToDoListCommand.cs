namespace ASP_NET_CORE_EF.CQRS.ToDoList.Commands
{
    public class UpdateToDoListCommand : ICommand<ASP_NET_CORE_EF.Models.ToDoList>
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int taskID { get; set; }
    }
}
