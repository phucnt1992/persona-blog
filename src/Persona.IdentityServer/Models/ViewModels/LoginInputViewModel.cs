using System.ComponentModel.DataAnnotations;

namespace Persona.IdentityServer.Models.ViewModels
{
    public class LoginInputViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }

    }
}
