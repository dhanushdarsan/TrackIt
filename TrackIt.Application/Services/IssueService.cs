using TrackIt.Application.DTOs;
using TrackIt.Application.Interfaces;
using TrackIt.Domain.Entities;

namespace TrackIt.Application.Services;

public class IssueService : IIssueService
{
    private readonly IIssueRepository _issueRepository;

    public IssueService(IIssueRepository issueRepository)
    {
        _issueRepository = issueRepository;
    }

    public async Task<List<Issue>> GetAllAsync()
    {
        return await _issueRepository.GetAllAsync();
    }

    public async Task<Issue> AddAsync(CreateIssueRequest request)
    {
        var issue = new Issue
        {
            Title = request.Title,
            Description = request.Description,
            Priority = request.Priority,
            Type = request.Type,

            ReporterId = request.ReporterId,
            AssigneeId = request.AssigneeId,
            ProjectId = request.ProjectId,

            Status = "Open",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        return await _issueRepository.AddAsync(issue);
    }

    public async Task<Issue?> GetAsync(int id)
    {
        return await _issueRepository.GetAsync(id);
    }

    public async Task<Issue?> UpdateAsync(
        int id,
        UpdateIssueRequest request)
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

        return await _issueRepository.UpdateAsync(issue);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _issueRepository.DeleteAsync(id);
    }
}