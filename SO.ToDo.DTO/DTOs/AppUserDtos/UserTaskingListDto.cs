using SO.ToDo.DTO.DTOs.TaskDtos;

namespace SO.ToDo.DTO.DTOs.AppUserDtos
{
    public class UserTaskingListDto
    {
        public AppUserListDto AppUser { get; set; }
        public MyTaskListDto Task { get; set; }
    }
}
