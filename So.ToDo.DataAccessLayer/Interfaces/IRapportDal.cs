using SO.ToDo.Entities.Concrete;

namespace So.ToDo.DataAccessLayer.Interfaces
{
    public interface IRapportDal : IGenericDAL<Rapport>
    {
        Rapport GetByTaskId(int id);
    }
}
