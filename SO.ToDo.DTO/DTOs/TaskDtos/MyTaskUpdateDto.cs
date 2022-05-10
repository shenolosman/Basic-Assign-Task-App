namespace SO.ToDo.DTO.DTOs.TaskDtos
{
    public class MyTaskUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StateOfUrgentId { get; set; }
    }
}
