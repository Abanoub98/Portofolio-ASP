using System.ComponentModel.DataAnnotations;
namespace Portofolio.ViewModels
{
    public class ChangePasswordViewModel : DashboardViewModel
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword", ErrorMessage = "Please make sure passwords match!")]
        public string ConfirmPassword { get; set; }
    }
}