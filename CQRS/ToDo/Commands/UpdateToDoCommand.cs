using ASP_NET_CORE_EF.Models;
namespace ASP_NET_CORE_EF.CQRS.ToDo.Commands
{
    public class UpdateToDoCommand : ICommand<ASP_NET_CORE_EF.Models.ToDo>
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? Deadline { get; set; }
    }
}
