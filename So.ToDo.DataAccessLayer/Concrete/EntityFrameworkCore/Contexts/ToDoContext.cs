using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Mapping;
using SO.ToDo.Entities.Concrete;

namespace So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Contexts
{
    public class ToDoContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=BasicToDo;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MyTaskMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new RapportMap());
            modelBuilder.ApplyConfiguration(new StateofUrgentMap());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<MyTask> MyTasks { get; set; }
        public DbSet<StateOfUrgent> StateOfUrgents { get; set; }
        public DbSet<Rapport> Rapports { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
