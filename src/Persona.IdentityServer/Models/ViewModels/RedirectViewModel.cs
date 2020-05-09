using System.ComponentModel.DataAnnotations;

namespace Persona.IdentityServer.Models.ViewModels
{
    public class RedirectViewModel
    {
        [Required]
        public string RedirectUrl { get; set; }
    }
}
