using Microsoft.EntityFrameworkCore;
using So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Contexts;
using So.ToDo.DataAccessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;
using System.Linq.Expressions;

namespace So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class EfMyTaskRepository : EfGenericRepository<MyTask>, IMyTaskDAL
    {
        //for eager loading!
        public async Task<List<MyTask>> GetUnDoneStatesofUrgent()
        {
            await using var context = new ToDoContext();
            return await context.MyTasks.Include(x => x.StateOfUrgent).Where(x => !x.IsDone)
                .OrderByDescending(x => x.CreatedTime).ToListAsync();
        }

        public async Task<List<MyTask>> GetAllTables()
        {
            await using var context = new ToDoContext();
            return await context.MyTasks.Include(x => x.StateOfUrgent).Include(x => x.Rapports).Include(x => x.AppUser).Where(x => !x.IsDone)
                .OrderByDescending(x => x.CreatedTime).ToListAsync();
        }

        public async Task<List<MyTask>> GetAllTables(Expression<Func<MyTask, bool>> filter)
        {
            await using var context = new ToDoContext();
            return await context.MyTasks.Include(x => x.StateOfUrgent).Include(x => x.Rapports).Include(x => x.AppUser).Where(filter)
                .OrderByDescending(x => x.CreatedTime).ToListAsync();
        }

        public async Task<MyTask> GetStateOfUrgentWithId(int id)
        {
            await using var context = new ToDoContext();
            return await context.MyTasks.Include(x => x.StateOfUrgent).FirstOrDefaultAsync(x => x.Id == id && !x.IsDone);
        }

        public async Task<List<MyTask>> GetByAppUserId(int userId)
        {
            await using var context = new ToDoContext();
            return await context.MyTasks.Where(x => x.AppUserId == userId).ToListAsync();
        }

        public async Task<MyTask> GetByReportId(int reportId)
        {
            await using var context = new ToDoContext();
            return (await context.MyTasks.Include(x => x.Rapports).Include(x => x.AppUser).Where(x => x.Id == reportId).FirstOrDefaultAsync())!;
        }
    }
}
