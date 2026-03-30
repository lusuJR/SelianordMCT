using System.ComponentModel.DataAnnotations;

namespace SelianordMCT.Web.Models
{
    public class ContactEnquiry
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full name is required.")]
        [MaxLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
        public string FullName { get; set; } =string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        [MaxLength(150, ErrorMessage = "Email address cannot exceed 150 characters.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please select a service.")]
        [MaxLength(100)]
        public string ServiceRequired { get; set; }

        [Required(ErrorMessage = "Message is required.")]
        [MaxLength(1000, ErrorMessage = "Message cannot exceed 1000 characters.")]
        public string Message { get; set; } = string.Empty;

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}