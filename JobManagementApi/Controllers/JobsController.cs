using JobManagementApi.Models;
using JobManagementApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JobManagementApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobsController : ControllerBase
{
    private readonly IJobRepository _jobRepository;

    public JobsController(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Job>>> GetJobs()
    {
        var jobs = await _jobRepository.GetAllJobsAsync();
        return Ok(jobs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Job>> GetJobById(string id)
    {
        var job = await _jobRepository.GetJobByIdAsync(id);
        if (job == null)
        {
            return NotFound();
        }

        return Ok(job);
    }

    [HttpPost]
    public async Task<ActionResult<Job>> CreateJob([FromBody] Job job)
    {
        if (job == null)
        {
            return BadRequest();
        }

        await _jobRepository.AddJobAsync(job);
        return CreatedAtAction(nameof(GetJobById), new { id = job.Id }, job);
    }
}