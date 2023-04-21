using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.User.Models
{
    public class MeetingModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Url { get; set; }
    }
}
