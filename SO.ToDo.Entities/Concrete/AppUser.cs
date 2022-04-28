using Microsoft.AspNetCore.Identity;
using SO.ToDo.Entities.Interfaces;

namespace SO.ToDo.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, ITable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Picture { get; set; }
        public List<MyTask> MyTasks { get; set; }
    }
}
