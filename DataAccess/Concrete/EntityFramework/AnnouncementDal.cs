using Core.DataAccess.MsSql;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class AnnouncementDal : EfRepositoryBase<Announcement, AppDbContext>, IAnnouncementDal
    {
        public List<Announcement> GetWithAppUser(Expression<Func<Announcement, bool>> filter = null)
        {
            using (AppDbContext context = new())
            {
                return filter == null ? context.Announcements.Include(x => x.AppUser).ToList() :
                                        context.Announcements.Where(filter).Include(x => x.AppUser).ToList();
            }
        }
    }
}
