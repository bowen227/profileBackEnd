using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<TodoGroupModel> GroupList { get; set; }
        public DbSet<TodoItemModel> ItemList { get; set; }
        public DbSet<CompanyModel> CompanyList { get; set; }
        public DbSet<CompanyContactsModel> CompanyContactList { get; set; }
        public DbSet<TaskModel> TaskList { get; set; }
    }
}