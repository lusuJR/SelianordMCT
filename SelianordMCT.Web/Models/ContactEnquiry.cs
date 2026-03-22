using System.ComponentModel.DataAnnotations;

namespace SelianordMCT.Web.Models
{
    public class ContactEnquiry
    {
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string? EmailAddress { get; set; }

        [Required(ErrorMessage = "Please select a service.")]
        public string? ServiceRequired { get; set; }

        [Required(ErrorMessage = "Message is required.")]
        [StringLength(1000, ErrorMessage = "Message cannot exceed 1000 characters.")]
        public string? Message { get; set; }
    }
}