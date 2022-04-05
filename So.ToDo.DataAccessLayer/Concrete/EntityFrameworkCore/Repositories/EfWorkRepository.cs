using So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Contexts;
using So.ToDo.DataAccessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;

namespace So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories
{
    public class EfWorkRepository : IWorkDAL
    {
        public void Save(Work work)
        {
            using var context = new ToDoContext();
            context.Works.Add(work);
            context.SaveChanges();
        }

        public void Delete(Work work)
        {
            using var context = new ToDoContext();
            context.Works.Remove(work);
            context.SaveChanges();
        }

        public void Update(Work work)
        {
            using var context = new ToDoContext();
            context.Works.Update(work);
            context.SaveChanges();
        }

        public Work GetById(int id)
        {
            using var context = new ToDoContext();
            return context.Works.Find(id) ?? throw new InvalidOperationException();
        }

        public List<Work> GetAll()
        {
            using var context = new ToDoContext();
            return context.Works.ToList();
        }
    }
}
