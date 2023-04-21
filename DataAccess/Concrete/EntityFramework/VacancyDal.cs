using Core.DataAccess.MsSql;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class VacancyDal : EfRepositoryBase<Vacancy, AppDbContext>, IVacancyDal
    {
        public List<Vacancy> GetWithAppUser(Expression<Func<Vacancy, bool>> filter = null)
        {
            using (AppDbContext context = new())
            {
                return filter == null
                ? context.Vacancies.Include(x => x.AppUser).ToList()
                : context.Vacancies.Where(filter).Include(x => x.AppUser).ToList();
            }
            
        }
    }
}
