using So.ToDo.DataAccessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;

namespace So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class EfStateOfUrgentRepository : EfGenericRepository<StateOfUrgent>, IStateOfUrgentDal
    {
    }
}
