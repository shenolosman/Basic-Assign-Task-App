using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.WebAPP.Areas.Admin.Models
{
    public class MyTaskListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDone { get; set; }
        public StateOfUrgent StateOfUrgent { get; set; }
        public int StateOfUrgentId { get; set; }

    }
}
