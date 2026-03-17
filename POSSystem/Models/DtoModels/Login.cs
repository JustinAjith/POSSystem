using System.ComponentModel.DataAnnotations;

namespace POSSystem.Models.DtoModels
{
    public class Login
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
