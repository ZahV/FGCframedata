using System.ComponentModel.DataAnnotations;

namespace FGCFrameData.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}