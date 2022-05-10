namespace SO.ToDo.DTO.DTOs.RapportDtos
{
    public class RapportUpdateDto
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public string Title { get; set; }
        public int MyTaskId { get; set; }
        // public MyTask MyTask { get; set; }
    }
}
