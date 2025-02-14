// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_CORE_EF.Models
{
    public class ToDo
    {
        private const string TemplateEmptyText = "Undefined Task";

        public int Id { get; set; }

        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        public string Text { get; set; }

        public DateTime? Deadline { get; set; }

        public ToDo()
        {
            this.Text = TemplateEmptyText;
        }

        public ToDo(string task)
        {
            this.Text = string.IsNullOrEmpty(task) ? TemplateEmptyText : task;
            this.Deadline = DateTime.Now;
        }
        public ToDo(string task, DateTime createdAt, DateTime deadline)
        {
            this.Text = string.IsNullOrEmpty(task) ? TemplateEmptyText : task;
            this.CreatedAt = createdAt;
            this.Deadline = deadline;
        }
        public bool IsIndefiniteTask()
        {
            return this.CreatedAt == this.Deadline;
        }
    }
}
