using TrackIt.Application.DTOs;
using TrackIt.Application.Interfaces;
using TrackIt.Domain.Entities;

namespace TrackIt.Application.Services
{ 
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _projectRepository.GetAllAsync();
        }

        public async Task<Project> AddAsync(CreateProjectRequest request)
        {
            var project = new Project
            {
                Name = request.Name,
                Description = request.Description,
                OwnerId = request.OwnerId
            };

           return await _projectRepository.AddAsync(project);
        }

        public async Task<Project> GetAsync(int id)
        {
            return await _projectRepository.GetAsync(id);
        }

        public async Task<Project> UpdateAsync(int id, UpdateProjectRequest request)
        {
            var project = await _projectRepository.GetAsync(id);

            if (project == null)
            {
                return null;
            }

            project.Name = request.Name;
            project.Description = request.Description;
            project.OwnerId = request.OwnerId;
            return await _projectRepository.UpdateAsync(project);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _projectRepository.DeleteAsync(id);
        }
    }
}
