namespace Entity.Concrete
{
    public class UserRole
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int AppRoleId { get; set; }
        public AppUser AppUser { get; set; }
        public AppRole AppRole { get; set; }
    }
}
