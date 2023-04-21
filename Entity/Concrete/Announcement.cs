using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Announcement : BaseEntity, IEntity
    {
        public int AppUserId { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public string? Image { get; set; }
        public string? MeetingUrl { get; set; }
        public DateTime Date { get; set; }

        public AppUser AppUser { get; set; }
    }
}
