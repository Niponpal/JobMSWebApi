using JobMSWebApi.Repository;
using JobMSWebApi.ViewModel.Job;
using Microsoft.AspNetCore.Mvc;

namespace JobMSWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobController : ControllerBase
{
    private readonly IJobRepository _repo;

    public JobController(IJobRepository repo)
    {
        _repo = repo;
    }

    // GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var data = await _repo.GetAllJobsAsync(cancellationToken);
        return Ok(data);
    }

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id, CancellationToken cancellationToken)
    {
        var data = await _repo.GetJobByIdAsync(id, cancellationToken);

        if (data == null)
            return NotFound(new { message = "Job not found" });

        return Ok(data);
    }

    // CREATE
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] JobCreateDto dto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var data = await _repo.AddJobAsync(dto, cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = data.Id }, data);
    }

    // UPDATE
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] JobUpdateDto dto, CancellationToken cancellationToken)
    {
        if (id != dto.Id)
            return BadRequest(new { message = "Id mismatch" });

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var data = await _repo.UpdateJobAsync(dto, cancellationToken);

        if (data == null)
            return NotFound(new { message = "Job not found" });

        return Ok(data);
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        var result = await _repo.DeleteJobAsync(id, cancellationToken);

        if (!result)
            return NotFound(new { message = "Job not found" });

        return Ok(new { message = "Job deleted successfully" });
    }
}