namespace CRUD.Dto
{
    public class Feedback
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string? FeedbackSuggestion { get; set; } = string.Empty;
    }
}
