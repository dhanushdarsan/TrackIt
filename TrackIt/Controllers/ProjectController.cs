using Microsoft.AspNetCore.Mvc;
using TrackIt.Application.DTOs;
using TrackIt.Application.Services;

namespace TrackIt.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _projectService.GetAllAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var projects = await _projectService.GetAsync(id);

            if (projects == null)
            {
                return NotFound();
            }

            return Ok(projects);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectRequest request)
        {
            var project = await _projectService.AddAsync(request);
            return CreatedAtAction(nameof(Get),new { project.Id }, project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProjectRequest request)
        {
            var project = await _projectService.UpdateAsync(id, request);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _projectService.DeleteAsync(id);

            if(!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
