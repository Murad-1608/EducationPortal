using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.User.Models
{
    public class TeacherModel
    {
        public int AppUserId { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string AcademicDegree { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string PhoneNumber { get; set; }
        public IFormFile? Image { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Bio { get; set; }
        public string? ImageString { get; set; }
    }
}
