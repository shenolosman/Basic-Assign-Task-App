using System.ComponentModel.DataAnnotations;

namespace SO.ToDo.WebAPP.Models
{
    public class AppUserAddViewModel
    {
        [Required(ErrorMessage = "Please Fill this Field!")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Fill this Field!")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Fill this Field!")]
        [Display(Name = "Reply Password")]
        [Compare("Password", ErrorMessage = "Passwords does not match!")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Please Fill this Field!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Fill this Field!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Fill this Field!")]
        public string Surname { get; set; }
    }
}
