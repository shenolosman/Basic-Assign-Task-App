using So.ToDo.DataAccessLayer.Interfaces;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.BusinessLayer.Concrete
{
    public class RapportManager : IRapportService
    {
        private readonly IRapportDal _rapportDal;

        public RapportManager(IRapportDal rapportDal)
        {
            _rapportDal = rapportDal;
        }
        public void Add(Rapport table)
        {
            _rapportDal.Save(table);
        }

        public void Remove(Rapport table)
        {
            _rapportDal.Delete(table);
        }

        public void Update(Rapport table)
        {
            _rapportDal.Update(table);
        }

        public Rapport GetById(int id)
        {
            return _rapportDal.GetById(id);
        }

        public List<Rapport> GetAll()
        {
            return _rapportDal.GetAll();
        }
    }
}
