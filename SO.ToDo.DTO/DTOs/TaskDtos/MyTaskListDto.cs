namespace SO.ToDo.DTO.DTOs.TaskDtos
{
    public class MyTaskListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDone { get; set; }
        //public StateOfUrgent StateOfUrgent { get; set; }
        public int StateOfUrgentId { get; set; }
    }
}
