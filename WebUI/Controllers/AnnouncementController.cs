using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace WebUI.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService announcementService;
        public AnnouncementController(IAnnouncementService announcementService)
        {
            this.announcementService = announcementService;
        }

        public IActionResult Index()
        {
            var value = announcementService.GetAll();

            ViewBag.Announcements = announcementService.GetAll().Count;

            value.Reverse();

            var announcements = value.ToPagedList(1, 3);

            return View(announcements);
        }

        [HttpPost]
        public IActionResult Search(string word)
        {
            var value = announcementService.Search(word);

            ViewBag.Announcements = announcementService.Search(word).Count;

            value.Reverse();

            var announcements = value.ToPagedList(1, 3);

            return View(announcements);
        }
    }
}
