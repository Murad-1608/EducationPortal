using Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=EducationAppDb; Integrated Security=true;");
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Book> Books { get; set; }
    }

}
