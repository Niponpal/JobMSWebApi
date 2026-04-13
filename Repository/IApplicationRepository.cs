using JobMSWebApi.ViewModel.Application;

namespace JobMSWebApi.Repository;

public interface IApplicationRepository
{
    // Create
    Task<long> CreateAsync(ApplicationCreateDto dto, CancellationToken cancellationToken);

    // Update
    Task<bool> UpdateAsync(ApplicationUpdateDto dto, CancellationToken cancellationToken);

    // Delete
    Task<bool> DeleteAsync(long id, CancellationToken cancellationToken);

    // Get by Id
    Task<ApplicationValueDto?> GetByIdAsync(long id, CancellationToken cancellationToken);

    // Get all
    Task<IEnumerable<ApplicationValueDto>> GetAllAsync(CancellationToken cancellationToken);

    
}
