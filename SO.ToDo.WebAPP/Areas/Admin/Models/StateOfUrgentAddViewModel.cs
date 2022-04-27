
using System.ComponentModel.DataAnnotations;

namespace SO.ToDo.WebAPP.Areas.Admin.Models
{
    public class StateOfUrgentAddViewModel
    {
        [Display(Name = "Type of state")]
        [Required(ErrorMessage = "You can't leave empty this field")]
        public string Type { get; set; }
    }
}
