namespace ASP_NET_CORE_EF.CQRS.ToDoList.Commands
{
    public class CreateToDoListCommand : ICommand<ASP_NET_CORE_EF.Models.ToDoList>
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
