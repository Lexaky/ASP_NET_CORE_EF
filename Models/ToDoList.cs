// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
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
