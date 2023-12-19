using Microsoft.EntityFrameworkCore;
using Test.DM;

namespace Test.DAL
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public DbSet<TaskModel> Tasks { get; set; }
    }
}
