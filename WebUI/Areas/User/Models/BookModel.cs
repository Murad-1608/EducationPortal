using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.User.Models
{
    public class BookModel
    {
        [Required(ErrorMessage ="Boş keçilə bilməz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public IFormFile BookUrl { get; set; }
    }
}
