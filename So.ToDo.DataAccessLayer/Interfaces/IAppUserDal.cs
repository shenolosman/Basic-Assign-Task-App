using SO.ToDo.Entities.Concrete;

namespace So.ToDo.DataAccessLayer.Interfaces
{
    public interface IAppUserDal
    {
        List<AppUser> GetUsersNotInAdminRole();
    }
}
