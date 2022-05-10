using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.DTO.DTOs.RapportDtos
{
    public class RapportAddDto
    {
        public string Details { get; set; }
        public string Title { get; set; }
        public int MyTaskId { get; set; }
        public MyTask MyTask { get; set; }
    }
}
