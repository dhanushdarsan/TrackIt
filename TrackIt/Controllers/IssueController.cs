using Microsoft.AspNetCore.Mvc;
using TrackIt.Application.DTOs;
using TrackIt.Application.Services;

namespace TrackIt.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IssueController : ControllerBase
{
    private readonly IIssueService _issueService;

    public IssueController(IIssueService issueService)
    {
        _issueService = issueService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var issues = await _issueService.GetAllAsync();
        return Ok(issues);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var issue = await _issueService.GetAsync(id);
        if (issue == null)
        {
            return NotFound();
        }
        return Ok(issue);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateIssueRequest request)
    {
        var issue = await _issueService.AddAsync(request);
        return CreatedAtAction(nameof(Get), new { id = issue.Id }, issue);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateIssueRequest request)
    {
        var issue = await _issueService.UpdateAsync(id, request);
        if (issue == null)
        {
            return NotFound();
        }
        return Ok(issue);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _issueService.DeleteAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}