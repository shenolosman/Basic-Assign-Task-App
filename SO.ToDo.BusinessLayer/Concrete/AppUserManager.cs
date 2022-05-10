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

        public List<AppUser> GetUsersNotInAdminRole(out int totalpage, string searchword, int activepage = 1)
        {
            return _userDal.GetUsersNotInAdminRole(out totalpage, searchword, activepage);
        }

        public List<DualHelper> GetUsersMostDoneTask()
        {
            return _userDal.GetUsersMostDoneTask();
        }

        public List<DualHelper> GetUsersMostTaskHave()
        {
            return _userDal.GetUsersMostTaskHave();
        }
    }
}
