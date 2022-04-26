using So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.BusinessLayer.Concrete
{
    public class StateOfUrgentManager : IStateOfUrgentService
    {
        private readonly EfStateOfUrgentRepository _stateOfUrgentRepository;

        public StateOfUrgentManager(EfStateOfUrgentRepository stateOfUrgentRepository)
        {
            _stateOfUrgentRepository = stateOfUrgentRepository;
        }
        public void Add(StateOfUrgent table)
        {
            _stateOfUrgentRepository.Save(table);
        }

        public void Remove(StateOfUrgent table)
        {
            _stateOfUrgentRepository.Delete(table);
        }

        public void Update(StateOfUrgent table)
        {
            _stateOfUrgentRepository.Update(table);
        }

        public StateOfUrgent GetById(int id)
        {
            return _stateOfUrgentRepository.GetById(id);
        }

        public List<StateOfUrgent> GetAll()
        {
            return _stateOfUrgentRepository.GetAll();
        }
    }
}
