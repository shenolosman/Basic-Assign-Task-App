using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.WebAPP.Areas.Admin.Models
{
    public class MyTaskAllListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public AppUser? AppUser { get; set; }
        public StateOfUrgent StateOfUrgent { get; set; }
        public List<Rapport> Rapports { get; set; }
    }
}
