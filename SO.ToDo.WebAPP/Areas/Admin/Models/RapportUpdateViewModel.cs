using SO.ToDo.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace SO.ToDo.WebAPP.Areas.Admin.Models
{
    public class RapportUpdateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public string Defination { get; set; }
        public int MyTaskId { get; set; }
        public MyTask MyTask { get; set; }
    }
}
