using Core.DataAccess;
using Core.Entity.Abstract;
using Entity.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IAnnouncementDal : IRepositoryBase<Announcement>
    {
        List<Announcement> GetWithAppUser(Expression<Func<Announcement, bool>> filter = null);
    }
}
