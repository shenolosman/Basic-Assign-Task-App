using SO.ToDo.Entities.Concrete;
using System.Linq.Expressions;

namespace So.ToDo.DataAccessLayer.Interfaces
{
    public interface IMyTaskDAL : IGenericDAL<MyTask>
    {
        Task<List<MyTask>> GetUnDoneStatesofUrgent();
        Task<List<MyTask>> GetAllTables();
        Task<List<MyTask>> GetAllTables(Expression<Func<MyTask, bool>> filter);
        Task<MyTask> GetStateOfUrgentWithId(int id);

        Task<List<MyTask>> GetByAppUserId(int userId);

        Task<MyTask> GetByReportId(int reportId);

    }
}
