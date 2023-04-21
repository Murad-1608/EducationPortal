using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult Index(int page = 1)
        {
            var books = bookService.GetBooksWithUser().ToPagedList(page, 20);

            books.Reverse();

            return View(books);
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
