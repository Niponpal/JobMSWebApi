using System.ComponentModel.DataAnnotations;

namespace JobMSWebApi.ViewModel.Job
{
    public class JobUpdateDto
    {
        [Required(ErrorMessage = "Id is required.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Job ID is required.")]
        [MaxLength(12)]
        public string JobID { get; set; } = null!;

        [Required(ErrorMessage = "Job Title is required.")]
        [MinLength(3)]
        [MaxLength(200)]
        public string JobTitle { get; set; } = null!;

        [MaxLength(500)]
        public string? Description { get; set; }

        public string? SalaryRange { get; set; }

        public DateTime? Deadline { get; set; }

        public string Status { get; set; } = "Active";

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}