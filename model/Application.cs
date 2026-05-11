using JobMSWebApi.Auth_IdentityModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobMSWebApi.model
{
    public class Application
    {
        [Key]
        public long Id { get; set; }

        [StringLength(12)]
        public string ApplicationId { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public decimal? PresentSalary { get; set; }
        public decimal? ExpectionSalary { get; set; }

        [StringLength(100)]
        public string? Degree { get; set; }

        [StringLength(200)]
        public string? University { get; set; }

        public decimal? CGPA { get; set; }
        public int? CompletionYear { get; set; }

        [StringLength(200)]
        public string? ResumePath { get; set; }

        // =====================
        // USER RELATION
        // =====================
        public long UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        // =====================
        // JOB RELATION
        // =====================
        public long? JobId { get; set; }

        public Job? Job { get; set; }
    }
}