using SO.ToDo.Entities.Interfaces;

namespace SO.ToDo.Entities.Concrete
{
    public class MyTask : ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDone { get; set; }

        public int? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public int StateOfUrgentId { get; set; }
        public StateOfUrgent StateOfUrgent { get; set; }

        public List<Rapport> Rapports { get; set; }
    }
}
