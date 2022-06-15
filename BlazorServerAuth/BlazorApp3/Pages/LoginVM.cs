using System.ComponentModel.DataAnnotations;

namespace BlazorApp3.Pages
{
    public class LoginVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }


        [Display(Name = "Remember me?")]
        public bool? RememberMe { get; set; }
    }
}
