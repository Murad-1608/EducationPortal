using Business.Abstract;
using Business.Helper;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookDal bookDal;
        public BookManager(IBookDal bookDal)
        {
            this.bookDal = bookDal;
        }

        public void Add(Book book)
        {
            bookDal.Add(book);
        }

        public void Delete(int id)
        {
            var book = bookDal.Get(x => x.Id == id);

            SystemIOOperations.DeletePhoto("Books", book.BookUrl);

            bookDal.Delete(book);
        }

        public List<Book> GetBooksByUserId(int userId)
        {
            return bookDal.GetBooksWithUser(x => x.AppUserId == userId);
        }

        public List<Book> GetBooksWithUser()
        {
            return bookDal.GetBooksWithUser();
        }

        public Book GetById(int id)
        {
            return bookDal.Get(x => x.Id == id);
        }

        public List<Book> GetWithTeacher(int id)
        {
            return bookDal.GetAll(x => x.AppUserId == id);
        }

        public List<Book> Search(string word)
        {
            return bookDal.GetAll(x => x.Name.Contains(word));
        }
    }
}
