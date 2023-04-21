using Core.DataAccess;
using Core.Entity.Abstract;
using Entity.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IVacancyDal : IRepositoryBase<Vacancy>
    {
        List<Vacancy> GetWithAppUser(Expression<Func<Vacancy, bool>> filter = null);
    }
}
