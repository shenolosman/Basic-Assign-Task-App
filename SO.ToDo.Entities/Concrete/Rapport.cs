using SO.ToDo.Entities.Interfaces;

namespace SO.ToDo.Entities.Concrete
{
    public class Rapport : ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public int MyTaskId { get; set; }
        public MyTask MyTask { get; set; }
    }
}
