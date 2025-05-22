using System.ComponentModel.DataAnnotations;

namespace InnovaTubeAPI.DTOs
{
    public class CredencialesUsuarioDTO
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
