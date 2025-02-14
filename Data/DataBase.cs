// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using ASP_NET_CORE_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_CORE_EF.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<ToDo>().ToTable("ToDos");
            //modelBuilder.Entity<User>().ToTable("Users");
            //modelBuilder.Entity<ToDoList>().ToTable("ToDoLists");
        }
    }

}
