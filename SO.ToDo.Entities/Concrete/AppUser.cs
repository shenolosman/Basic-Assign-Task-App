using Microsoft.AspNetCore.Identity;
using SO.ToDo.Entities.Interfaces;

namespace SO.ToDo.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, ITable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Picture { get; set; } = "default.png";
        public List<MyTask> MyTasks { get; set; }
        public List<Notification> Notifications { get; set; }

    }
}
