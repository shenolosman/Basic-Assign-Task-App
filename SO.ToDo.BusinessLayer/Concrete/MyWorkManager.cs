using So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.BusinessLayer.Concrete
{
    internal class MyWorkManager : IMyTaskService
    {
        private readonly EfMyTaskRepository _efWorkRepository;

        public MyWorkManager(EfMyTaskRepository efWorkRepository)
        {
            _efWorkRepository = efWorkRepository;
        }
        public void Add(MyTask table)
        {
            _efWorkRepository.Save(table);
        }

        public void Remove(MyTask table)
        {
            _efWorkRepository.Delete(table);
        }

        public void Update(MyTask table)
        {
            _efWorkRepository.Update(table);
        }

        public MyTask GetById(int id)
        {
            return _efWorkRepository.GetById(id);
        }

        public List<MyTask> GetAll()
        {
            return _efWorkRepository.GetAll();
        }
    }
}
