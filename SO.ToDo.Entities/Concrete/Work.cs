﻿namespace SO.ToDo.Entities.Concrete
{
    public class Work
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
