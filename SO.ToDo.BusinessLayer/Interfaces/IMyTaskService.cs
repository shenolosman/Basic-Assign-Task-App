using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.BusinessLayer.Interfaces
{
    public interface IMyTaskService : IGenericService<MyTask>
    {
        Task<List<MyTask>> GetUnDoneStatesofUrgent();
        Task<List<MyTask>> GetAllTables();
    }
}
