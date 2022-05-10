using So.ToDo.DataAccessLayer.Interfaces;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }
        public void Add(Notification table)
        {
            _notificationDal.Add(table);
        }

        public void Delete(Notification table)
        {
            _notificationDal.Delete(table);
        }

        public void Edit(Notification table)
        {
            _notificationDal.Update(table);
        }

        public Notification GetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.GetAll();
        }

        public List<Notification> GetNotRead(int AppUserId)
        {
            return _notificationDal.GetNotRead(AppUserId);
        }
    }
}
