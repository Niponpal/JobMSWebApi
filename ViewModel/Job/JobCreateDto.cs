using System.ComponentModel.DataAnnotations;

namespace JobMSWebApi.ViewModel.Job
{
    public class JobCreateDto
    {
        [Required(ErrorMessage = "Job ID is required.")]
        [MaxLength(12, ErrorMessage = "JobID cannot exceed 12 characters.")]
        public string JobID { get; set; } = null!;

        [Required(ErrorMessage = "Job Title is required.")]
        [MinLength(3, ErrorMessage = "Job Title must be at least 3 characters.")]
        [MaxLength(200, ErrorMessage = "Job Title cannot exceed 200 characters.")]
        public string JobTitle { get; set; } = null!;

        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        public string? SalaryRange { get; set; }

        public DateTime? Deadline { get; set; }

        public string Status { get; set; } = "Active";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}