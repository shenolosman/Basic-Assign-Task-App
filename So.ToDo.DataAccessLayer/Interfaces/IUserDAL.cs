using SO.ToDo.Entities.Concrete;

namespace So.ToDo.DataAccessLayer.Interfaces
{
    public interface IUserDAL
    {
        void Save(User user);
        void Delete(User user);
        void Update(User user);
        User GetById(int id);
        List<User> GetAll();
    }
}
