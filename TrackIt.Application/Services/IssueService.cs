using TrackIt.Application.DTOs;
using TrackIt.Application.Interfaces;
using TrackIt.Domain.Entities;

namespace TrackIt.Application.Services;

public class IssueService : IIssueService
{
    private readonly IIssueRepository _issueRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProjectRepository _projectRepository;

    public IssueService(IIssueRepository issueRepository, IUserRepository userRepository, IProjectRepository projectRepository)
    {
        _issueRepository = issueRepository;
        _userRepository = userRepository;
        _projectRepository = projectRepository;
    }

    public async Task<List<IssueResponse>> GetAllAsync()
    {
        var issues = await _issueRepository.GetAllAsync();

        return issues.Select(issue => new IssueResponse
        {
            Id = issue.Id,
            TicketId = issue.TicketId,
            Title = issue.Title,
            Description = issue.Description,
            Status = issue.Status,
            Priority = issue.Priority,
            Type = issue.Type,

            ReporterId = issue.ReporterId,
            ReporterEmail = issue.Reporter?.Email,

            AssigneeId = issue.AssigneeId,
            AssigneeEmail = issue.Assignee?.Email,

            ProjectId = issue.ProjectId,
            ProjectName = issue.Project?.Name ?? string.Empty,

            CreatedAt = issue.CreatedAt,
            UpdatedAt = issue.UpdatedAt,
            ResolvedAt = issue.ResolvedAt
        }).ToList();
    }

    public async Task<IssueResponse> AddAsync(CreateIssueRequest request)
    {
        var project = await _projectRepository.GetAsync(request.ProjectId);

        if (project == null)
        {
            throw new InvalidOperationException("Project not found.");
        }

        var reporter = await _userRepository.GetAsync(request.ReporterId);

        if (reporter == null)
        {
            throw new InvalidOperationException("Reporter not found.");
        }

        if (request.AssigneeId.HasValue)
        {
            var assignee = await _userRepository.GetAsync(request.AssigneeId.Value);

            if (assignee == null)
            {
                throw new InvalidOperationException("Assignee not found.");
            }
        }

        var issue = new Issue
        {
            Title = request.Title,
            Description = request.Description,
            Status = "Open",
            Priority = request.Priority,
            Type = request.Type,
            ReporterId = request.ReporterId,
            AssigneeId = request.AssigneeId,
            ProjectId = request.ProjectId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var createdIssue = await _issueRepository.AddAsync(issue);

        var issueWithDetails = await _issueRepository.GetAsync(createdIssue.Id);

        if(issueWithDetails == null)
        {
            throw new InvalidOperationException("Failed to retrieve the created issue.");
        }

        return new IssueResponse
        {
            Id = createdIssue.Id,
            Title = createdIssue.Title,
            Description = createdIssue.Description,
            Status = createdIssue.Status,
            Priority = createdIssue.Priority,
            Type = createdIssue.Type,
            ReporterId = createdIssue.ReporterId,
            ReporterEmail = createdIssue.Reporter?.Email,
            AssigneeId = createdIssue.AssigneeId,
            AssigneeEmail = createdIssue.Assignee?.Email,
            ProjectId = createdIssue.ProjectId,
            ProjectName = createdIssue.Project?.Name ?? string.Empty,
            CreatedAt = createdIssue.CreatedAt,
            UpdatedAt = createdIssue.UpdatedAt,
            ResolvedAt = createdIssue.ResolvedAt
        };
    }

    public async Task<IssueResponse?> GetAsync(int id)
    {
        var issue = await _issueRepository.GetAsync(id);

        if (issue == null)
        {
            return null;
        }

        return new IssueResponse
        {
            Id = issue.Id,
            Title = issue.Title,
            Description = issue.Description,
            Status = issue.Status,
            Priority = issue.Priority,
            Type = issue.Type,
            ReporterId = issue.ReporterId,
            ReporterEmail = issue.Reporter?.Email,
            AssigneeId = issue.AssigneeId,
            AssigneeEmail = issue.Assignee?.Email,
            ProjectId = issue.ProjectId,
            ProjectName = issue.Project?.Name ?? string.Empty,
            CreatedAt = issue.CreatedAt,
            UpdatedAt = issue.UpdatedAt,
            ResolvedAt = issue.ResolvedAt
        };
    }

    public async Task<IssueResponse?> UpdateAsync(int id, UpdateIssueRequest request)
    {
        var issue = await _issueRepository.GetAsync(id);

        if (issue == null)
        {
            return null;
        }

        issue.Title = request.Title;
        issue.Description = request.Description;
        issue.Status = request.Status;
        issue.Priority = request.Priority;
        issue.Type = request.Type;
        issue.AssigneeId = request.AssigneeId;
        issue.UpdatedAt = DateTime.UtcNow;

        await _issueRepository.UpdateAsync(issue);

        return new IssueResponse
        {
            Id = issue.Id,
            Title = issue.Title,
            Description = issue.Description,
            Status = issue.Status,
            Priority = issue.Priority,
            Type = issue.Type,
            ReporterId = issue.ReporterId,
            ReporterEmail = issue.Reporter?.Email,
            AssigneeId = issue.AssigneeId,
            AssigneeEmail = issue.Assignee?.Email,
            ProjectId = issue.ProjectId,
            ProjectName = issue.Project?.Name ?? string.Empty,
            CreatedAt = issue.CreatedAt,
            UpdatedAt = issue.UpdatedAt,
            ResolvedAt = issue.ResolvedAt
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _issueRepository.DeleteAsync(id);
    }
}