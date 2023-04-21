using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "İstifadəçi adı və ya email boş ola bilməz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Parol boş ola bilməz")]
        public string Password { get; set; }
    }
}
