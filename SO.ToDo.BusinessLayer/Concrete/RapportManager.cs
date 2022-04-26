using So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.BusinessLayer.Concrete
{
    public class RapportManager : IRapportService
    {
        private readonly EfRapportRepository _rapportRepository;

        public RapportManager(EfRapportRepository rapportRepository)
        {
            _rapportRepository = rapportRepository;
        }
        public void Add(Rapport table)
        {
            _rapportRepository.Save(table);
        }

        public void Remove(Rapport table)
        {
            _rapportRepository.Delete(table);
        }

        public void Update(Rapport table)
        {
            _rapportRepository.Update(table);
        }

        public Rapport GetById(int id)
        {
            return _rapportRepository.GetById(id);
        }

        public List<Rapport> GetAll()
        {
            return _rapportRepository.GetAll();
        }
    }
}
