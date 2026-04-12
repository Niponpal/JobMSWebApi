using JobMSWebApi.model;

namespace JobMSWebApi.Repository;

public interface IJobRepository
{
         // CRUD operations for Job entity
        Task<IEnumerable<Job>> GetAllJobsAsync(CancellationToken cancellationToken);
        Task<Job> GetJobByIdAsync(long id, CancellationToken cancellationToken);
        Task<Job> AddJobAsync(Job job, CancellationToken cancellationToken);
        Task<Job> UpdateJobAsync(Job job, CancellationToken cancellationToken);
        Task<Job> DeleteJobAsync(long id, CancellationToken cancellationToken);
}
