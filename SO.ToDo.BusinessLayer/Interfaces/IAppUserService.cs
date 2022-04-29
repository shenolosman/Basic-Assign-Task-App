using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.BusinessLayer.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> GetUsersNotInAdminRole();
        List<AppUser> GetUsersNotInAdminRole(string searchword, int activepage = 1);
    }
}
