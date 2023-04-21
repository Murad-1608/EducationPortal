using Entity.Concrete;

namespace Business.Abstract
{
    public interface IBookService
    {
        List<Book> GetBooksWithUser();
        List<Book> GetBooksByUserId(int userId);
        List<Book> GetWithTeacher(int id);
        void Add(Book book);
        Book GetById(int id);
        void Delete(int id);    
        List<Book> Search(string word);

    }
}
