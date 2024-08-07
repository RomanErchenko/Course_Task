using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kurs2_bloknot.Models
{
    public class RegisterBindingModel
    {
        [Display(Name = "Login")]
        [Required]
        public string Login { get; set; }= string.Empty;

        [Display(Name = "Password")]
        [UIHint("Password")]
        [MinLength(6)]
        public string Password { get; set; }=string.Empty;

        [Display(Name = "Confirm password")]
        [UIHint("Password")]
        [Compare(nameof(Password))]
        [NotMapped]
        public string PasswordConfirm { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }

    public class LoginBindingModel
    {
        [Display(Name = "Login")]
        [Required]
        public string Login { get; set; } = string.Empty;

        [Display(Name = "Password")]
        [UIHint("Password")]
        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }
}
