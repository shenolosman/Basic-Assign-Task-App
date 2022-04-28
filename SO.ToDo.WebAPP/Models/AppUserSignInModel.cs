using System.ComponentModel.DataAnnotations;

namespace SO.ToDo.WebAPP.Models
{
    public class AppUserSignInModel
    {
        [Required(ErrorMessage = "Please Fill this Field!")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Fill this Field!")]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        //[Required(ErrorMessage = "Please Fill this Field!")]
        //[DataType(DataType.EmailAddress)]
        //public string Email { get; set; }
    }
}
