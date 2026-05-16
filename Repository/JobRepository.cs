using JobMSWebApi.Data;
using JobMSWebApi.model;
using JobMSWebApi.ViewModel.Job;
using Microsoft.EntityFrameworkCore;

namespace JobMSWebApi.Repository;

public class JobRepository : IJobRepository
{
    private readonly ApplicationDbContext _context;

    public JobRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // CREATE
    public async Task<JobValueDto> AddJobAsync(JobCreateDto dto, CancellationToken cancellationToken)
    {
        var job = new Job
        {
            JobID = dto.JobID,
            JobTitle = dto.JobTitle,
            Description = dto.Description,
            SalaryRange = dto.SalaryRange,
            Deadline = dto.Deadline,
            Status = dto.Status
        };

        await _context.Jobs.AddAsync(job, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return MapToDto(job);
    }

    // GET ALL
    public async Task<IEnumerable<JobValueDto>> GetAllJobsAsync(CancellationToken cancellationToken)
    {
        var data = await _context.Jobs.ToListAsync(cancellationToken);
        return data.Select(x => MapToDto(x)).ToList();

    }

    // GET BY ID
    public async Task<JobValueDto?> GetJobByIdAsync(long id, CancellationToken cancellationToken)
    {
        var data = await _context.Jobs
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (data == null) return null;

        return MapToDto(data);
    }

    // UPDATE
    public async Task<JobValueDto?> UpdateJobAsync(JobUpdateDto dto, CancellationToken cancellationToken)
    {
        var data = await _context.Jobs
            .FirstOrDefaultAsync(x => x.Id == dto.Id, cancellationToken);

        if (data == null) return null;

        data.JobID = dto.JobID;
        data.JobTitle = dto.JobTitle;
        data.Description = dto.Description;
        data.SalaryRange = dto.SalaryRange;
        data.Deadline = dto.Deadline;
        data.Status = dto.Status;

        await _context.SaveChangesAsync(cancellationToken);

        return MapToDto(data);
    }

    // DELETE
    public async Task<bool> DeleteJobAsync(long id, CancellationToken cancellationToken)
    {
        var data = await _context.Jobs
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (data == null) return false;

        _context.Jobs.Remove(data);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    // 🔁 Mapping Method (IMPORTANT)
    private static JobValueDto MapToDto(Job job)
    {
        return new JobValueDto
        {
            Id = job.Id,
            JobID = job.JobID,
            JobTitle = job.JobTitle,
            Description = job.Description,
            SalaryRange = job.SalaryRange,
            Deadline = job.Deadline,
            Status = job.Status,
            CreatedAt = job.CreatedAt
        };
    }
}