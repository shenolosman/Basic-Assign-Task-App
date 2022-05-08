using Microsoft.EntityFrameworkCore;
using So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Contexts;
using So.ToDo.DataAccessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;

namespace So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class EfRapportRepository : EfGenericRepository<Rapport>, IRapportDal
    {
        public Rapport GetByTaskId(int id)
        {
            using var context = new ToDoContext();
            return context.Rapports.Include(x => x.MyTask).ThenInclude(x => x.StateOfUrgent).Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
