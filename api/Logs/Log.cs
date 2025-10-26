using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Logs
{
    [Table("Logs")]
    public class Log
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public Guid? UserId { get; set; }
        public string? SourceIp { get; set; }

        [Required]
        [MaxLength(50)] //CREATE, UPDATE, DELETE, ETC
        public string Action { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)] //SUCESS, FAILURE
        public string Status { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Table { get; set; }

        public Guid? RecordId { get; set; }
        public string? BeforeState {  get; set; }
        public string? AfterState { get; set; }
        public string? Details { get; set; }

    }
}
