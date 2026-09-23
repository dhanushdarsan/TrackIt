using TrackIt.Application.DTOs;
using TrackIt.Domain.Entities;

namespace TrackIt.Application.Services
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> AddAsync(CreateProjectRequest request);
        Task<Project?> GetAsync(int id);
        Task<Project?> UpdateAsync(int id, UpdateProjectRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
