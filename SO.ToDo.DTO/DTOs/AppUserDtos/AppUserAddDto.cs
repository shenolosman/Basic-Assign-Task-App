namespace SO.ToDo.DTO.DTOs.AppUserDtos
{
    public class AppUserAddDto
    {
        public string Username { get; set; }
        // [DataType(DataType.Password)]
        public string Password { get; set; }
        //  [DataType(DataType.Password)]
        //  [Display(Name = "Reply Password")]
        public string RePassword { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
