using System.ComponentModel.DataAnnotations;

namespace SO.ToDo.WebAPP.Areas.Admin.Models
{
    public class StateOfUrgentUpdateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Must be filled!")]
        public string Type { get; set; }
    }
}
