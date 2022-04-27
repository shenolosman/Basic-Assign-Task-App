using System.ComponentModel.DataAnnotations;

namespace SO.ToDo.WebAPP.Areas.Admin.Models
{
    public class MyTaskAddViewModel
    {
        [Required(ErrorMessage = "This field can't be empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        public string Description { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        [Range(0, int.MaxValue, ErrorMessage = "Please select one of state of urgent!")]
        public int StateOfUrgentId { get; set; }
    }
}
