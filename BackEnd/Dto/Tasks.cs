namespace CRUD.Dto
{
    public class Tasks
    {
        public int TaskUserId { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string? TaskDescription { get; set; } = string.Empty;
        public int TaskIsActive { get; set; }
        public DateTime TaskCreTime { get; set; }
    }
}