using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HardwareReservationAndAccountingSystem.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "El. pašto adresas")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Kodas")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Prisiminti naršyklę?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "El. pašto adresas")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "El. pašto adresas")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Slaptažodis")]
        public string Password { get; set; }

        [Display(Name = "Prisiminti?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "El. pašto adresas")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} turi būti bent {2} simbolių ilgio.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Slaptažodis")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Pakartoti slaptažodį")]
        [Compare("Password", ErrorMessage = "Slaptažodžiai nesutampa.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "El. pašto adresas")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} turi būti bent {2} simbolių ilgio.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Slaptažodis")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Pakartoti slaptažodį")]
        [Compare("Password", ErrorMessage = "Slaptažodžiai nesutampa.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "El. pašto adresas")]
        public string Email { get; set; }
    }
}
