namespace SideQuest.api.DTOs
{
    public class CreateQuestDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Repeating { get; set; }
        public int? RepeatInterval { get; set; }
    }
}