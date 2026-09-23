namespace TrackIt.Application.DTOs
{
    public class CreateIssueRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public int ReporterId { get; set; }
        public int? AssigneeId { get; set; }
        public int ProjectId { get; set; }
    }
}
