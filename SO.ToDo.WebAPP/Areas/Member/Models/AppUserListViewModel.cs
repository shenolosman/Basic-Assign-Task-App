using System.ComponentModel.DataAnnotations;

namespace SO.ToDo.WebAPP.Areas.Member.Models
{
    public class AppUserListViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Fill the place")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Fill the place")]
        [Display(Name = "Surname")]
        public string SurName { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Fill the place")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Fill the place")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        public string? Picture { get; set; }
    }
}
