namespace TrackIt.Domain.Entities
{
    public class Issue
    {
        public int Id { get; set; }

        public string TicketId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public int ReporterId { get; set; }
        public int? AssigneeId { get; set; }
        public int ProjectId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }

        public User Reporter { get; set; } = null!;
        public User? Assignee { get; set; }
        public Project Project { get; set; } = null!;
    }
}
