using SO.ToDo.Entities.Concrete;

namespace So.ToDo.DataAccessLayer.Interfaces
{
    public interface IWorkDAL
    {
        void Save(Work work);
        void Delete(Work work);
        void Update(Work work);
        Work GetById(int id);
        List<Work> GetAll();
    }
}
