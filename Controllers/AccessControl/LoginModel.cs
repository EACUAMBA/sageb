using System.ComponentModel.DataAnnotations;

namespace sageb.Controllers.AccessControl
{
    public class LoginModel
    {
        [Required]
        public string Email {  get; set; } = String.Empty;

        [Required]
        public string Password { get; set; } = String.Empty;

        [Required]
        public bool RememberMe { get; set; } = false;
    }
}
