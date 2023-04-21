using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.User.Models
{
    public class AnnouncementModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Content { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageString { get; set; }
    }
}
