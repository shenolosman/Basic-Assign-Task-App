using SO.ToDo.Entities.Interfaces;

namespace SO.ToDo.BusinessLayer.Interfaces
{
    public interface IGenericService<Table> where Table : class, ITable, new()
    {
        void Add(Table table);
        void Remove(Table table);
        void Update(Table table);
        Table GetById(int id);
        List<Table> GetAll();
    }
}
