namespace TrackIt.Application.DTOs
{
    public class UpdateIssueRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public int? AssigneeId { get; set; }
    }
}
