using System.ComponentModel.DataAnnotations;

namespace POSSystem.Models.DtoModels
{
    public class RegisterUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public bool IsActive { get; set; } = false;
    }
}
