using JobMSWebApi.Data;
using JobMSWebApi.model;
using Microsoft.EntityFrameworkCore;

namespace JobMSWebApi.Repository;

public class JobRepository : IJobRepository
{
    private readonly ApplicationDbContext _context;
    public JobRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Job> AddJobAsync(Job job, CancellationToken cancellationToken)
    {
      await _context.Jobs.AddAsync(job, cancellationToken);
      await _context.SaveChangesAsync(cancellationToken);
      return job;
    }

    public async Task<Job> DeleteJobAsync(long id, CancellationToken cancellationToken)
    {
       var data = await _context.Jobs.FindAsync(id, cancellationToken);

        if(data != null)
        {
            _context.Jobs.Remove(data);
            await _context.SaveChangesAsync(cancellationToken);
            return data;
        }
        return null;
    }

    public async Task<IEnumerable<Job>> GetAllJobsAsync(CancellationToken cancellationToken)
    {
        var data = await _context.Jobs.ToListAsync(cancellationToken);
        if(data != null)
        {
            return data;
        }
        return null;

    }

    public async Task<Job> GetJobByIdAsync(long id, CancellationToken cancellationToken)
    {
       var data = await _context.Jobs.FindAsync(id, cancellationToken);
        if(data != null)
        {
            return data;
        }
        return null;
    }

    public async Task<Job> UpdateJobAsync(Job job, CancellationToken cancellationToken)
    {
       var data = await  _context.Jobs.FindAsync(job.Id, cancellationToken);
        if(data != null)
        {
            data.JobID = job.JobID;
            data.JobTitle = job.JobTitle;
            data.Description = job.Description;
            data.SalaryRange = job.SalaryRange;
            data.Deadline = job.Deadline;
            data.Status = job.Status;
            await _context.SaveChangesAsync(cancellationToken);
            return data;
        }
        return null;
    }
}
