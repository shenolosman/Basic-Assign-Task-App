using So.ToDo.DataAccessLayer.Interfaces;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;
using System.Linq.Expressions;

namespace SO.ToDo.BusinessLayer.Concrete
{
    public class MyTaskManager : IMyTaskService
    {
        private readonly IMyTaskDAL _myTaskDal;

        public MyTaskManager(IMyTaskDAL myTaskDal)
        {
            _myTaskDal = myTaskDal;
        }
        public void Add(MyTask table)
        {
            _myTaskDal.Add(table);
        }

        public void Delete(MyTask table)
        {
            _myTaskDal.Delete(table);
        }

        public void Edit(MyTask table)
        {
            _myTaskDal.Update(table);
        }

        public MyTask GetById(int id)
        {
            return _myTaskDal.GetById(id);
        }

        public List<MyTask> GetAll()
        {
            return _myTaskDal.GetAll();
        }

        public Task<List<MyTask>> GetUnDoneStatesofUrgent()
        {
            return _myTaskDal.GetUnDoneStatesofUrgent();
        }

        public Task<List<MyTask>> GetAllTables()
        {
            return _myTaskDal.GetAllTables();
        }

        public Task<MyTask> GetStateOfUrgentWithId(int id)
        {
            return _myTaskDal.GetStateOfUrgentWithId(id);
        }

        public Task<List<MyTask>> GetByAppUserId(int userId)
        {
            return _myTaskDal.GetByAppUserId(userId);
        }

        public Task<MyTask> GetByReportId(int reportId)
        {
            return _myTaskDal.GetByReportId(reportId);
        }

        public Task<List<MyTask>> GetAllTables(Expression<Func<MyTask, bool>> filter)
        {
            return _myTaskDal.GetAllTables(filter);
        }

        public List<MyTask> GetAllTablesWithNotDone(out int totalPage, int userId, int activePage)
        {
            return _myTaskDal.GetAllTablesWithNotDone(out totalPage, userId, activePage);
        }

        public int GetTaskCountCompletedWithUserId(int id)
        {
            return _myTaskDal.GetTaskCountCompletedWithUserId(id);
        }

        public int GetTaskCountMustCompleteByUserId(int id)
        {
            return _myTaskDal.GetTaskCountMustCompleteByUserId(id);
        }
    }
}
