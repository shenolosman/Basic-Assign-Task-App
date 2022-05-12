using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace SO.ToDo.DTO.DTOs.AppUserDtos
{
    public class AppUserListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // [Display(Name = "Surname")]
        public string Surname { get; set; }
        //  [Display(Name = "Username")]
        public string UserName { get; set; }
        //   [Display(Name = "Email")]
        public string Email { get; set; }
        public string? Picture { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
