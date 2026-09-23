using System;
using System.Collections.Generic;
using System.Text;

namespace TrackIt.Application.DTOs
{
    public class IssueResponse
    {
        public int Id { get; set; }
        public string TicketId { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public int ReporterId { get; set; }
        public string ReporterEmail { get; set; } = string.Empty;

        public int? AssigneeId { get; set; }
        public string? AssigneeEmail { get; set; }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
    }
}

