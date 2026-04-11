using JobMSWebApi.Data;
using JobMSWebApi.model;
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

        public async Task<Application> AddApplicationAsync(Application application, CancellationToken cancellationToken)
        {
            await _context.Applications.AddAsync(application, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return application;
        }

        public async Task<Application> DeleteApplicationAsync(long id, CancellationToken cancellationToken)
        {
            var data = await _context.Applications.FindAsync(new object[] { id }, cancellationToken);

            if (data == null) return null;

            _context.Applications.Remove(data);
            await _context.SaveChangesAsync(cancellationToken);
            return data;
        }

        public async Task<IEnumerable<Application>> GetAllApplicationsAsync(CancellationToken cancellationToken)
        {
            return await _context.Applications.ToListAsync(cancellationToken);
        }

        public async Task<Application?> GetApplicationByIdAsync(long id, CancellationToken cancellationToken)
        {
            return await _context.Applications.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<Application?> UpdateApplicationAsync(Application application, CancellationToken cancellationToken)
        {
            var data = await _context.Applications.FirstOrDefaultAsync(x => x.Id == application.Id, cancellationToken);

            if (data == null) return null;

            data.ApplicationId = application.ApplicationId;
            data.Name = application.Name;
            data.PresentSalary = application.PresentSalary;
            data.ExpectionSalary = application.ExpectionSalary;
            data.Degree = application.Degree;
            data.University = application.University;
            data.CGPA = application.CGPA;
            data.CompletionYear = application.CompletionYear;
            data.ResumePath = application.ResumePath;

            await _context.SaveChangesAsync(cancellationToken);
            return data;
        }
    }
}