using Business.Abstract;
using Business.Helper;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using WebUI.Areas.User.Models;
using X.PagedList;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class AnnouncementController : BaseController
    {
        IAnnouncementService announcementService;
        public AnnouncementController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAnnouncementService announcementService) : base(userManager, signInManager)
        {
            this.announcementService = announcementService;
        }

        public IActionResult Index()
        {
            var value = announcementService.GetByAppuserId(appuser.Id).ToPagedList(1, 20);

            return View(value);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AnnouncementModel model)
        {
            if (ModelState.IsValid)
            {
                Announcement announcement = new();

                if (model.Image == null)
                {
                    announcement.Image = null;
                }
                else if (model.Image.ContentType != "image/jpeg" && model.Image.ContentType != "image/png")
                {
                    ModelState.AddModelError(nameof(model.Image), "Şəkil formatını düzgün seçin");
                    return View(model);
                }
                else if (model.Image.ContentType == "image/jpeg" || model.Image.ContentType == "image/png")
                {
                    announcement.Image = SystemIOOperations.AddPhoto(model.Image, "Announcement");
                }

                announcement.Content = model.Content;
                announcement.Title = model.Title;
                announcement.Date = DateTime.Now;
                announcement.AppUserId = appuser.Id;
                announcementService.Add(announcement);

                return RedirectToAction("index");
            }
            return View(model);
        }


        public IActionResult Delete(int id)
        {
            announcementService.Delete(id);

            return RedirectToAction("index");
        }

        public IActionResult Update(int id)
        {
            var announcement = announcementService.GetById(id);

            AnnouncementModel model = new()
            {
                Id = announcement.Id,
                Content = announcement.Content,
                Title = announcement.Title,
                ImageString = announcement.Image
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(AnnouncementModel model)
        {
            if (ModelState.IsValid)
            {
                Announcement announcement = new();

                if (model.Image == null)
                {
                    announcement.Image = model.ImageString;
                }
                else if (model.Image.ContentType != "image/jpeg" && model.Image.ContentType != "image/png")
                {
                    ModelState.AddModelError(nameof(model.Image), "Şəkil formatını düzgün seçin");
                    return View(model);
                }
                else if (model.Image.ContentType == "image/jpeg" || model.Image.ContentType == "image/png")
                {
                    SystemIOOperations.DeletePhoto("Announcement", model.ImageString);

                    announcement.Image = SystemIOOperations.AddPhoto(model.Image, "Announcement");
                }

                announcement.Content = model.Content;
                announcement.Title = model.Title;
                announcement.Date = DateTime.Now;
                announcement.AppUserId = appuser.Id;
                announcement.Id = model.Id;
                announcementService.Update(announcement);

                return RedirectToAction("index");
            }
            return View(model);
        }

        public IActionResult AddMeeting()
        {

            return View();
        }


        [HttpPost]
        public IActionResult AddMeeting(MeetingModel model)
        {

            if (ModelState.IsValid)
            {
                Announcement announcement = new()
                {
                    Title = model.Title,
                    AppUserId = appuser.Id,
                    MeetingUrl = model.Url,
                    Date = DateTime.Now
                };
                announcementService.Add(announcement);
            }

            return RedirectToAction("Index");
        }

        public IActionResult UpdateMeeting(int id)
        {
            var value = announcementService.GetById(id);
            MeetingModel model = new()
            {
                Id = id,
                Title = value.Title,
                Url = value.MeetingUrl
            };
            return View(model);
        }


        [HttpPost]
        public IActionResult UpdateMeeting(MeetingModel model)
        {

            if (ModelState.IsValid)
            {
                Announcement announcement = new()
                {
                    Title = model.Title,
                    AppUserId = appuser.Id,
                    MeetingUrl = model.Url,
                    Date = DateTime.Now,
                    Id = model.Id
                };
                announcementService.Update(announcement);
            }

            return RedirectToAction("Index");
        }
    }
}

