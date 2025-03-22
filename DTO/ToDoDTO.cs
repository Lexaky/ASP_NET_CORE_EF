using System.ComponentModel.DataAnnotations;

namespace ASP_NET_CORE_EF.DTO
{
    public class ToDoDTO
    {
        [Required]
        [MaxLength(1000)]
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? Deadline { get; set; }
    }
}
