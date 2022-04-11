using So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.BusinessLayer.Concrete
{
    internal class MyUserManager : IUserService
    {
        private readonly EfUserRepository _efUserRepository;

        public MyUserManager(EfUserRepository efUserRepository)
        {
            _efUserRepository = efUserRepository;
        }
        public void Add(User table)
        {
            _efUserRepository.Save(table);
        }

        public void Remove(User table)
        {
            _efUserRepository.Delete(table);
        }

        public void Update(User table)
        {
            _efUserRepository.Update(table);
        }

        public User GetById(int id)
        {
            return _efUserRepository.GetById(id);
        }

        public List<User> GetAll()
        {
            return _efUserRepository.GetAll();
        }
    }
}
