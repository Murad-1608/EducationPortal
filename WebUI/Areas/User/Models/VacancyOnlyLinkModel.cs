using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.User.Models
{
    public class VacancyOnlyLinkModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string CompanyName { get; set; }        
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Appeal { get; set; }
    }
}
