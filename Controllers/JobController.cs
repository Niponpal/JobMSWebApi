using JobMSWebApi.model;
using JobMSWebApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JobMSWebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class JobController : Controller
{
    private readonly IJobRepository _repo;

    public JobController(IJobRepository repo)
    {
        _repo = repo;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var data = await _repo.GetAllJobsAsync(cancellationToken);
        return Ok(data);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id, CancellationToken cancellationToken)
    {
        var data = await _repo.GetJobByIdAsync(id, cancellationToken);
        if (data == null)
            return NotFound();
        return Ok(data);
    }
    [HttpPost]
    public async Task<IActionResult> Create(Job job, CancellationToken cancellationToken)
    {
        var data = await _repo.AddJobAsync(job, cancellationToken);
        return Ok(data);
    }
    [HttpPut("{id}")]
    
    public async Task<IActionResult> Update(long id, Job job, CancellationToken cancellationToken)
    {
        if (id != job.Id)
            return BadRequest();
        var data = await _repo.UpdateJobAsync(job, cancellationToken);
        if (data == null)
            return NotFound();
        return Ok(data);
    }

}
