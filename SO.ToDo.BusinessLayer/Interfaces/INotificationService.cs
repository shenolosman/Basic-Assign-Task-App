using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.BusinessLayer.Interfaces
{
    public interface INotificationService : IGenericService<Notification>
    {
        List<Notification> GetNotRead(int AppUserId);
    }
}
