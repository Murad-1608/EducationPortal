using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Vacancy : BaseEntity, IEntity
    {
        public int AppUserId { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string? JobInformation { get; set; }
        public string? Requirements { get; set; }
        public string Appeal { get; set; }
        public DateTime CreateDate { get; set; }

        public AppUser AppUser { get; set; }
    }
}
