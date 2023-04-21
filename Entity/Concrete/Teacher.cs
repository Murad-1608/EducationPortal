using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Teacher : BaseEntity, IEntity
    {
        public int AppUserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string AcademicDegree { get; set; }
        public string? Image { get; set; }
        public string Bio { get; set; }

        public AppUser AppUser { get; set; }
    }
}
