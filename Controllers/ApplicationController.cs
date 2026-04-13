using JobMSWebApi.Repository;
using JobMSWebApi.ViewModel.Application;
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

    // GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var data = await _repo.GetAllAsync(cancellationToken);
        return Ok(data);
    }

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id, CancellationToken cancellationToken)
    {
        var data = await _repo.GetByIdAsync(id, cancellationToken);

        if (data == null)
            return NotFound();

        return Ok(data);
    }

    // CREATE
    [HttpPost]
    public async Task<IActionResult> Create(ApplicationCreateDto dto, CancellationToken cancellationToken)
    {
        var id = await _repo.CreateAsync(dto, cancellationToken);
        return Ok(new { Id = id, Message = "Application Created Successfully" });
    }

    // UPDATE
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, ApplicationUpdateDto dto, CancellationToken cancellationToken)
    {
        if (id != dto.Id)
            return BadRequest("ID mismatch");

        var result = await _repo.UpdateAsync(dto, cancellationToken);

        if (!result)
            return NotFound();

        return Ok(new { Message = "Updated Successfully" });
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        var result = await _repo.DeleteAsync(id, cancellationToken);

        if (!result)
            return NotFound();

        return Ok(new { Message = "Deleted Successfully" });
    }
}
