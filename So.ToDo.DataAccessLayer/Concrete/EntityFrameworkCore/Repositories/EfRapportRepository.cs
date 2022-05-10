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

        public int GetReportsByUserId(int id)
        {
            using var context = new ToDoContext();
            var result = context.MyTasks.Include(x => x.Rapports).Where(x => x.AppUserId == id);
            return result.SelectMany(x => x.Rapports).Count();
        }

        public int GetReportCount()
        {
            using var context = new ToDoContext();
            return context.Rapports.Count();
        }
    }
}
