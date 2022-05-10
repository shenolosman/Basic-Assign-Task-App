namespace SO.ToDo.DTO.DTOs.AppUserDtos
{
    public class AppUserSignInDto
    {
        public string UserName { get; set; }
        //[DataType(DataType.Password)]
        public string Password { get; set; }
        // [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
