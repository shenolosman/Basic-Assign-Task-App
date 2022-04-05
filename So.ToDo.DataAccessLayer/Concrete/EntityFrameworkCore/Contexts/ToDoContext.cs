using Microsoft.EntityFrameworkCore;
using So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Mapping;
using SO.ToDo.Entities.Concrete;

namespace So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Contexts
{
    public class ToDoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=BasicToDo;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new WorkMap());
        }

        public DbSet<Work> Works { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
