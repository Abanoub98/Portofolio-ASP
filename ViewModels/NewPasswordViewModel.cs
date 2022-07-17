using System.ComponentModel.DataAnnotations;
namespace Portofolio.ViewModels
{
    public class NewPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Please make sure passwords match!")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }

        public string Email { get; set; }

    }
}