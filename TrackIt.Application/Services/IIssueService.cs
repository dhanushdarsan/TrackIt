using TrackIt.Application.DTOs;
using TrackIt.Domain.Entities;

namespace TrackIt.Application.Services
{
    public interface IIssueService
    {
        Task<List<Issue>> GetAllAsync();
        Task<Issue> AddAsync(CreateIssueRequest request);
        Task<Issue?> GetAsync(int id);
        Task<Issue?> UpdateAsync(int id, UpdateIssueRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
