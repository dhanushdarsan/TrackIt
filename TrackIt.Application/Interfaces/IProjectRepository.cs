using TrackIt.Domain.Entities;

namespace TrackIt.Application.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> AddAsync(Project project);
        Task<Project?> GetAsync(int id);
        Task<Project> UpdateAsync(Project project);
        Task<bool> DeleteAsync(int id);
    }
}
