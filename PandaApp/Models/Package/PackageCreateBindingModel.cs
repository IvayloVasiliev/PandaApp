using System.ComponentModel.DataAnnotations;

namespace PandaApp.Models.Package
{
    public class PackageCreateBindingModel
    {
        [Required]
        [StringLength(50, ErrorMessage ="Invalid description", MinimumLength = 5)]
        public string Description { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Invalid description", MinimumLength = 5)]
        public string ShippingAddress { get; set; }
         
        [Required]
        public string Recipient { get; set; }

    }
}
