using So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Contexts;
using So.ToDo.DataAccessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;

namespace So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class EfNotificationRepository : EfGenericRepository<Notification>, INotificationDal
    {
        public List<Notification> GetNotRead(int AppUserId)
        {
            using var context = new ToDoContext();
            return context.Notifications.Where(x => x.AppUserId == AppUserId && !x.State).ToList();
        }

        public int GetNotReadCountByUserId(int id)
        {
            using var context = new ToDoContext();
            return context.Notifications.Count(x => x.AppUserId == id && !x.State);
        }
    }
}
