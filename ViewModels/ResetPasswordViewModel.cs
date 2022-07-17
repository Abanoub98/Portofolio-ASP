using System.ComponentModel.DataAnnotations;
namespace Portofolio.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}