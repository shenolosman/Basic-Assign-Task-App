using AutoMapper;
using SO.ToDo.DTO.DTOs.AppUserDtos;
using SO.ToDo.DTO.DTOs.NotificationDtos;
using SO.ToDo.DTO.DTOs.RapportDtos;
using SO.ToDo.DTO.DTOs.StateOfUrgentDtos;
using SO.ToDo.DTO.DTOs.TaskDtos;
using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.WebAPP.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Stateofurgent-StateofurgentDto
            CreateMap<StateOfUrgentAddDto, StateOfUrgent>();
            CreateMap<StateOfUrgent, StateOfUrgentAddDto>();
            CreateMap<StateOfUrgentUpdateDto, StateOfUrgent>();
            CreateMap<StateOfUrgent, StateOfUrgentUpdateDto>();
            CreateMap<StateOfUrgentListDto, StateOfUrgent>();
            CreateMap<StateOfUrgent, StateOfUrgentListDto>();
            #endregion

            #region AppUser-AppUserDto
            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
            CreateMap<AppUserSignInDto, AppUser>();
            CreateMap<AppUser, AppUserSignInDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            #endregion

            #region Notification-NotificationDto
            CreateMap<NotificationListDto, Notification>();
            CreateMap<Notification, NotificationListDto>();
            #endregion

            #region MyTask-MyTaskDto
            CreateMap<MyTaskAddDto, MyTask>();
            CreateMap<MyTask, MyTaskAddDto>();
            CreateMap<MyTaskListDto, MyTask>();
            CreateMap<MyTask, MyTaskListDto>();
            CreateMap<MyTaskUpdateDto, MyTask>();
            CreateMap<MyTask, MyTaskUpdateDto>();
            CreateMap<MyTaskAllListDto, MyTask>();
            CreateMap<MyTask, MyTaskAllListDto>();
            #endregion

            #region Rapport-RapportDto
            CreateMap<RapportAddDto, Rapport>();
            CreateMap<Rapport, RapportAddDto>();
            CreateMap<RapportUpdateDto, Rapport>();
            CreateMap<Rapport, RapportUpdateDto>();
            #endregion
        }
    }
}
