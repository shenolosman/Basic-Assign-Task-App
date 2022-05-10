using SO.ToDo.Entities.Interfaces;

namespace SO.ToDo.Entities.Concrete
{
    public class Notification : ITable
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public bool State { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
