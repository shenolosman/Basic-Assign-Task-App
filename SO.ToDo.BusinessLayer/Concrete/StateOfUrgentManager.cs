using So.ToDo.DataAccessLayer.Interfaces;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.BusinessLayer.Concrete
{
    public class StateOfUrgentManager : IStateOfUrgentService
    {
        private readonly IStateOfUrgentDal _stateOfUrgentDal;

        public StateOfUrgentManager(IStateOfUrgentDal stateOfUrgentDal)
        {
            _stateOfUrgentDal = stateOfUrgentDal;
        }
        public void Add(StateOfUrgent table)
        {
            _stateOfUrgentDal.Add(table);
        }

        public void Delete(StateOfUrgent table)
        {
            _stateOfUrgentDal.Delete(table);
        }

        public void Edit(StateOfUrgent table)
        {
            _stateOfUrgentDal.Update(table);
        }

        public StateOfUrgent GetById(int id)
        {
            return _stateOfUrgentDal.GetById(id);
        }

        public List<StateOfUrgent> GetAll()
        {
            return _stateOfUrgentDal.GetAll();
        }
    }
}
