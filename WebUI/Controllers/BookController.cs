using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace WebUI.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult Index(int page = 1)
        {
            var books = bookService.GetBooksWithUser().ToPagedList(page, 8);

            ViewBag.BooksCount = bookService.GetBooksWithUser().Count;

            books.Reverse();

            return View(books);
        }
        public async Task<IActionResult> Download(int id)
        {
            var book = bookService.GetById(id);

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Books", book.BookUrl);
            var memory = new MemoryStream();

            try
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {

                    await stream.CopyToAsync(memory);
                }

            }
            catch (Exception)
            {
            }

            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";
            var fileName = Path.GetFileName(path);

            return File(memory, contentType, fileName);
        }


        [HttpPost]
        public ActionResult Search(string word)
        {
            var books = bookService.Search(word).ToPagedList(1, 4);

            ViewBag.BooksCount = bookService.Search(word).Count;

            books.Reverse();

            return View(books);
        }

    }
}
