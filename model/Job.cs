using JobMSWebApi.Auth_IdentityModel;
using System.ComponentModel.DataAnnotations;

namespace JobMSWebApi.model
{
    public class Job
    {
        [Key]
        public long Id { get; set; }

        [StringLength(12)]
        public string JobID { get; set; } = string.Empty;

        // =========================
        // FIXED USER RELATION
        // =========================
      
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;

        // =========================
        // JOB INFO
        // =========================
        [Required]
        [StringLength(200)]
        public string JobTitle { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        public string? SalaryRange { get; set; }

        public DateTime? Deadline { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Active";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Application> Applications { get; set; }
            = new HashSet<Application>();
    }
}