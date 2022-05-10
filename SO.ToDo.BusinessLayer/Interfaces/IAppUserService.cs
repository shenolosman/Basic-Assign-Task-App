using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.BusinessLayer.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> GetUsersNotInAdminRole();
        List<AppUser> GetUsersNotInAdminRole(out int totalpage, string searchword, int activepage = 1);

        List<DualHelper> GetUsersMostDoneTask();
        List<DualHelper> GetUsersMostTaskHave();
    }
}
