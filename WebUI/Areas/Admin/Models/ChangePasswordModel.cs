using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.Models
{
    public class ChangePasswordModel
    {
        public int AppUserId { get; set; }
        [Required(ErrorMessage = "Boş ola bilməz")]
        [MinLength(6, ErrorMessage = "Ən az 6 simvol ola bilər")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Boş ola bilməz")]
        [Compare(nameof(NewPassword), ErrorMessage = "Eyniliyi yoxlayın")]
        public string ConfrimPassword { get; set; }
    }
}
