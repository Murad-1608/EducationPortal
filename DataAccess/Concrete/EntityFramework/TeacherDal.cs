using Core.DataAccess.MsSql;
using Core.Entity.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class TeacherDal : EfRepositoryBase<Teacher, AppDbContext>, ITeacherDal
    {
        public List<Teacher> GetAllWithUser(Expression<Func<Teacher, bool>> filter = null)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return filter == null
                ? context.Teachers.Include(x => x.AppUser).ToList()
                : context.Teachers.Where(filter).Include(x => x.AppUser).ToList();
            }
        }

        public Teacher GetByUserId(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Teachers.Include(x => x.AppUser).FirstOrDefault(x => x.AppUserId == id);
            }
        }
    }
}
