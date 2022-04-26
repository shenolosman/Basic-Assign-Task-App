namespace SO.ToDo.Entities.Concrete
{
    public class StateOfUrgent
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<MyTask> MyTasks { get; set; }
    }
}
