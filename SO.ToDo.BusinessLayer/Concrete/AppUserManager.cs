using So.ToDo.DataAccessLayer.Interfaces;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _userDal;

        public AppUserManager(IAppUserDal userDal)
        {
            _userDal = userDal;
        }
        public List<AppUser> GetUsersNotInAdminRole()
        {
            return _userDal.GetUsersNotInAdminRole();
        }
    }
}
