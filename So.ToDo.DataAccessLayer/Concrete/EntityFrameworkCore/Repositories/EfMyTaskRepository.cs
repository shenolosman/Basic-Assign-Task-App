using Microsoft.EntityFrameworkCore;
using So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Contexts;
using So.ToDo.DataAccessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;

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
    }
}
