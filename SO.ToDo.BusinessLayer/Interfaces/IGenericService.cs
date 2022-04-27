using SO.ToDo.Entities.Interfaces;

namespace SO.ToDo.BusinessLayer.Interfaces
{
    public interface IGenericService<Table> where Table : class, ITable, new()
    {
        void Add(Table table);
        void Delete(Table table);
        void Edit(Table table);
        Table GetById(int id);
        List<Table> GetAll();
    }
}
