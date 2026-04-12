using JobMSWebApi.model;
using JobMSWebApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JobMSWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationController : ControllerBase
{
    private readonly IApplicationRepository _repo;

    public ApplicationController(IApplicationRepository repo)
    {
        _repo = repo;
    }

    [HttpGet ]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var data = await _repo.GetAllApplicationsAsync(cancellationToken);
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id, CancellationToken cancellationToken)
    {
        var data = await _repo.GetApplicationByIdAsync(id, cancellationToken);

        if (data == null)
            return NotFound();

        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Application application, CancellationToken cancellationToken)
    {
        var data = await _repo.AddApplicationAsync(application, cancellationToken);
        return Ok(data);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, Application application, CancellationToken cancellationToken)
    {
        if (id != application.Id)
            return BadRequest();

        var data = await _repo.UpdateApplicationAsync(application, cancellationToken);

        if (data == null)
            return NotFound();

        return Ok(data);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        var data = await _repo.DeleteApplicationAsync(id, cancellationToken);

        if (data == null)
            return NotFound();

        return Ok(data);
    }
}