using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.BusinessLayer.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> GetUsersNotInAdminRole();
    }
}
