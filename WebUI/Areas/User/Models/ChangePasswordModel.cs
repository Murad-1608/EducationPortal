using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.User.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Boş ola bilməz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz")]
        [MinLength(6, ErrorMessage = "Ən az 6 simvol ola bilər")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz")]
        [Compare(nameof(NewPassword), ErrorMessage = "Eyniliyi yoxlayın")]
        public string ConfrimPassword { get; set; }
    }
}
