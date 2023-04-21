using Business.Abstract;
using Business.Helper;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.User.Models;
using X.PagedList;

namespace WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class BookController : BaseController
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(userManager, signInManager)
        {
            this.bookService = bookService;
        }

        public IActionResult Index(int page = 1)
        {
            var books = bookService.GetBooksByUserId(appuser.Id).ToPagedList(page, 20);

            books.Reverse();

            return View(books);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.FindByNameAsync(User.Identity.Name).Result;

                Book book = new Book()
                {
                    AppUserId = user.Id,
                    Name = bookModel.Name,
                    BookUrl = SystemIOOperations.AddPhoto(bookModel.BookUrl, "Books")
                };

                bookService.Add(book);

                return RedirectToAction("Index");
            }
            return View(bookModel);
        }

        public IActionResult Delete(int id)
        {
            bookService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}

