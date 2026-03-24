using System.ComponentModel.DataAnnotations;

namespace SelianordMCT.API.Entities
{
    public class Enquiry
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string ServiceRequired { get; set; } = string.Empty;

        [Required]
        [MaxLength(1000)]
        public string Message { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "New";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}