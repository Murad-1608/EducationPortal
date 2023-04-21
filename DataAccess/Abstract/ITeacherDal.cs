using Core.DataAccess;
using Core.Entity.Abstract;
using Entity.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ITeacherDal : IRepositoryBase<Teacher>
    {
        List<Teacher> GetAllWithUser(Expression<Func<Teacher, bool>> filter = null);
        Teacher GetByUserId(int id);
    }
}
