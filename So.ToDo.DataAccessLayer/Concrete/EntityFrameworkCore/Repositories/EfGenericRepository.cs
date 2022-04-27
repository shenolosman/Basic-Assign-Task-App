using So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Contexts;
using So.ToDo.DataAccessLayer.Interfaces;
using SO.ToDo.Entities.Interfaces;

namespace So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<EfRepository> : IGenericDAL<EfRepository> where EfRepository : class, ITable, new()
    {
        public void Add(EfRepository repo)
        {
            using var context = new ToDoContext();
            context.Set<EfRepository>().Add(repo);
            context.SaveChanges();
        }

        public void Delete(EfRepository repo)
        {
            using var context = new ToDoContext();
            context.Set<EfRepository>().Remove(repo);
            context.SaveChanges();
        }

        public void Update(EfRepository repo)
        {
            using var context = new ToDoContext();
            context.Set<EfRepository>().Update(repo);
            context.SaveChanges();
        }

        public EfRepository GetById(int id)
        {
            using var context = new ToDoContext();
            return context.Set<EfRepository>().Find(id);
        }

        public List<EfRepository> GetAll()
        {
            using var context = new ToDoContext();
            return context.Set<EfRepository>().ToList();
        }
    }
}
