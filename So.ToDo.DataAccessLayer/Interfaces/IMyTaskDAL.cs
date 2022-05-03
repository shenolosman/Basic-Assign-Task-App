using SO.ToDo.Entities.Concrete;

namespace So.ToDo.DataAccessLayer.Interfaces
{
    public interface IMyTaskDAL : IGenericDAL<MyTask>
    {
        Task<List<MyTask>> GetUnDoneStatesofUrgent();
        Task<List<MyTask>> GetAllTables();
        Task<MyTask> GetStateOfUrgentWithId(int id);

        Task<List<MyTask>> GetByAppUserId(int userId);

        Task<MyTask> GetByReportId(int reportId);
    }
}
