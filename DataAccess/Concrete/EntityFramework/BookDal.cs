using Core.DataAccess.MsSql;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class BookDal : EfRepositoryBase<Book, AppDbContext>, IBookDal
    {
        public List<Book> GetBooksWithUser(Expression<Func<Book, bool>> filter = null)
        {
            using (AppDbContext context = new())
            {
                return filter == null
                ? context.Books.Include(x => x.Appuser).ToList()
                : context.Books.Where(filter).Include(x => x.Appuser).ToList();
            }
        }
    }
}
