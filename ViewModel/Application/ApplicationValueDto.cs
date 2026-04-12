namespace JobMSWebApi.ViewModel.Application
{
    public class ApplicationValueDto
    {
        public long Id { get; set; }

        public string ApplicationId { get; set; }

        public string Name { get; set; }

        public decimal? PresentSalary { get; set; }

        public decimal? ExpectionSalary { get; set; }

        public string Degree { get; set; }

        public string University { get; set; }

        public decimal? CGPA { get; set; }

        public int? CompletionYear { get; set; }

        public string ResumePath { get; set; }

        public long? JobId { get; set; }

        // Optional (if you want job info)
        public string? JobTitle { get; set; }
    }
}