namespace JobMSWebApi.ViewModel.Job
{
    public class JobValueDto
    {
        public long Id { get; set; }
        public string JobID { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public string? Description { get; set; }
        public string? SalaryRange { get; set; }
        public DateTime? Deadline { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}