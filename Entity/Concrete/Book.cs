using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Book : BaseEntity, IEntity
    {
        public int AppUserId { get; set; }
        public string Name { get; set; }
        public string BookUrl { get; set; }


        public AppUser Appuser { get; set; }
    }
}
