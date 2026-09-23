using TrackIt.Application.DTOs;
using TrackIt.Domain.Entities;

namespace TrackIt.Application.Services
{
    public interface IIssueService
    {
        Task<List<IssueResponse>> GetAllAsync();
        Task<IssueResponse> AddAsync(CreateIssueRequest request);
        Task<IssueResponse?> GetAsync(int id);
        Task<IssueResponse?> UpdateAsync(int id, UpdateIssueRequest request);
        Task<bool> DeleteAsync(int id); 
    }
}
