using SO.ToDo.Entities.Concrete;

namespace So.ToDo.DataAccessLayer.Interfaces
{
    public interface IWorkDAL
    {
        void SaveWork(Work work);
        void DeleteWork(Work work);
        void UpdateWork(Work work);
        Work GetWork(int id);
        Work GetWorkById(int id);
        List<Work> GetAllWorks();
    }
}
