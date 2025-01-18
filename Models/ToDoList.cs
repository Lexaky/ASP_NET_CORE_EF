namespace ASP_NET_CORE_EF.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<ToDo> ToDos { get; set; }
        public int UserId { get; set; }
    }
}
