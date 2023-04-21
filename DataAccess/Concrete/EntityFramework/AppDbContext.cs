using Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SQL8005.site4now.net; Database=db_a98094_murad2701; Integrated Security=false; user id=db_a98094_murad2701_admin; password=murad123");
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Book> Books { get; set; }
    }

}
