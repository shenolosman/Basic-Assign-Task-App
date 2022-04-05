using SO.ToDo.Entities.Interfaces;

namespace SO.ToDo.Entities.Concrete
{
    public class Work : ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDone { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
