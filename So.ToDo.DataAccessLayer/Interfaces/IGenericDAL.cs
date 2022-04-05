using SO.ToDo.Entities.Interfaces;

namespace So.ToDo.DataAccessLayer.Interfaces
{
    public interface IGenericDAL<TEntityObj> where TEntityObj : class, ITable, new()
    {
        void Save(TEntityObj work);
        void Delete(TEntityObj work);
        void Update(TEntityObj work);
        TEntityObj GetById(int id);
        List<TEntityObj> GetAll();
    }
}
