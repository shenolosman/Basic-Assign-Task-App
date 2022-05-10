using SO.ToDo.Entities.Concrete;

namespace So.ToDo.DataAccessLayer.Interfaces
{
    public interface INotificationDal : IGenericDAL<Notification>
    {
        List<Notification> GetNotRead(int AppUserId);
        int GetNotReadCountByUserId(int id);
    }
}
