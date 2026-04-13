using JobMSWebApi.ViewModel.Job;

namespace JobMSWebApi.Repository;

public interface IJobRepository
{
    // GET ALL
    Task<IEnumerable<JobValueDto>> GetAllJobsAsync(CancellationToken cancellationToken);

    // GET BY ID
    Task<JobValueDto?> GetJobByIdAsync(long id, CancellationToken cancellationToken);

    // CREATE
    Task<JobValueDto> AddJobAsync(JobCreateDto dto, CancellationToken cancellationToken);

    // UPDATE
    Task<JobValueDto?> UpdateJobAsync(JobUpdateDto dto, CancellationToken cancellationToken);

    // DELETE
    Task<bool> DeleteJobAsync(long id, CancellationToken cancellationToken);
}