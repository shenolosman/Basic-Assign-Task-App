using SO.ToDo.Entities.Interfaces;

namespace SO.ToDo.Entities.Concrete
{
    public class StateOfUrgent : ITable
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<MyTask> MyTasks { get; set; }
    }
}
