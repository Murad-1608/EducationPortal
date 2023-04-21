using Core.DataAccess;
using Entity.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IBookDal : IRepositoryBase<Book>
    {
        List<Book> GetBooksWithUser(Expression<Func<Book, bool>> filter = null);
    }
}
