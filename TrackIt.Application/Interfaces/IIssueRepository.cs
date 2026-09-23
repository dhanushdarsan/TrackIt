using TrackIt.Domain.Entities;

namespace TrackIt.Application.Interfaces
{
    public interface IIssueRepository
    {
        Task<List<Issue>> GetAllAsync();
        Task<Issue> AddAsync(Issue issue);
        Task<Issue?> GetAsync(int id);
        Task<Issue> UpdateAsync(Issue issue);
        Task<bool> DeleteAsync(int id);
    }
}
