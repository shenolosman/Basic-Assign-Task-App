namespace SO.ToDo.DTO.DTOs.AppUserDtos
{
    public class AppUserListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // [Display(Name = "Surname")]
        public string SurName { get; set; }
        //  [Display(Name = "Username")]
        public string UserName { get; set; }
        //   [Display(Name = "Email")]
        public string Email { get; set; }
        public string? Picture { get; set; }
    }
}
