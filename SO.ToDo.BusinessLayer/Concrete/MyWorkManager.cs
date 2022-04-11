using So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.BusinessLayer.Concrete
{
    internal class MyWorkManager : IWorkService
    {
        private readonly EfWorkRepository _efWorkRepository;

        public MyWorkManager(EfWorkRepository efWorkRepository)
        {
            _efWorkRepository = efWorkRepository;
        }
        public void Add(Work table)
        {
            _efWorkRepository.Save(table);
        }

        public void Remove(Work table)
        {
            _efWorkRepository.Delete(table);
        }

        public void Update(Work table)
        {
            _efWorkRepository.Update(table);
        }

        public Work GetById(int id)
        {
            return _efWorkRepository.GetById(id);
        }

        public List<Work> GetAll()
        {
            return _efWorkRepository.GetAll();
        }
    }
}
