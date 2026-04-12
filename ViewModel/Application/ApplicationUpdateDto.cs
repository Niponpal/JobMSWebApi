using System.ComponentModel.DataAnnotations;

namespace JobMSWebApi.ViewModel.Application
{
    public class ApplicationUpdateDto
    {
        [Required]
        public long Id { get; set; }

        [StringLength(12)]
        public string ApplicationId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public decimal? PresentSalary { get; set; }

        public decimal? ExpectionSalary { get; set; }

        [StringLength(100)]
        public string Degree { get; set; }

        [StringLength(200)]
        public string University { get; set; }

        public decimal? CGPA { get; set; }

        public int? CompletionYear { get; set; }

        public string ResumePath { get; set; }

        public long? JobId { get; set; }
    }
}