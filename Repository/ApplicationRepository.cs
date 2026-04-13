using JobMSWebApi.Data;
using JobMSWebApi.model;
using JobMSWebApi.ViewModel.Application;
using Microsoft.EntityFrameworkCore;

namespace JobMSWebApi.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // CREATE
        public async Task<long> CreateAsync(ApplicationCreateDto dto, CancellationToken cancellationToken)
        {
            var entity = new Application
            {
                ApplicationId = dto.ApplicationId,
                Name = dto.Name,
                PresentSalary = dto.PresentSalary,
                ExpectionSalary = dto.ExpectionSalary,
                Degree = dto.Degree,
                University = dto.University,
                CGPA = dto.CGPA,
                CompletionYear = dto.CompletionYear,
                ResumePath = dto.ResumePath,
                JobId = dto.JobId
            };

            await _context.Applications.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        // DELETE
        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken)
        {
            var data = await _context.Applications.FindAsync(id, cancellationToken);

            if (data == null) return false;

            _context.Applications.Remove(data);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        // GET ALL
        public async Task<IEnumerable<ApplicationValueDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Applications
                .AsNoTracking()
                .Select(x => new ApplicationValueDto
                {
                    Id = x.Id,
                    ApplicationId = x.ApplicationId,
                    Name = x.Name,
                    PresentSalary = x.PresentSalary,
                    ExpectionSalary = x.ExpectionSalary,
                    Degree = x.Degree,
                    University = x.University,
                    CGPA = x.CGPA,
                    CompletionYear = x.CompletionYear,
                    ResumePath = x.ResumePath,
                    JobId = x.JobId
                })
                .ToListAsync(cancellationToken);
        }

        // GET BY ID
        public async Task<ApplicationValueDto?> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            return await _context.Applications
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new ApplicationValueDto
                {
                    Id = x.Id,
                    ApplicationId = x.ApplicationId,
                    Name = x.Name,
                    PresentSalary = x.PresentSalary,
                    ExpectionSalary = x.ExpectionSalary,
                    Degree = x.Degree,
                    University = x.University,
                    CGPA = x.CGPA,
                    CompletionYear = x.CompletionYear,
                    ResumePath = x.ResumePath,
                    JobId = x.JobId
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        // UPDATE
        public async Task<bool> UpdateAsync(ApplicationUpdateDto dto, CancellationToken cancellationToken)
        {
            var data = await _context.Applications
                .FirstOrDefaultAsync(x => x.Id == dto.Id, cancellationToken);

            if (data == null) return false;

            data.ApplicationId = dto.ApplicationId;
            data.Name = dto.Name;
            data.PresentSalary = dto.PresentSalary;
            data.ExpectionSalary = dto.ExpectionSalary;
            data.Degree = dto.Degree;
            data.University = dto.University;
            data.CGPA = dto.CGPA;
            data.CompletionYear = dto.CompletionYear;
            data.ResumePath = dto.ResumePath;
            data.JobId = dto.JobId;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}