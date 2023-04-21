using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.User.Models;
using X.PagedList;

namespace WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class VacancyController : BaseController
    {
        private readonly IVacancyService vacancyService;
        public VacancyController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IVacancyService vacancyService) : base(userManager, signInManager)
        {
            this.vacancyService = vacancyService;
        }

        public IActionResult Index()
        {
            var vacancy = vacancyService.GetByAppUserId(appuser.Id).ToPagedList(1, 20);

            vacancy.Reverse();

            return View(vacancy);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(VacancyModel model)
        {
            if (ModelState.IsValid)
            {
                Vacancy vacancy = new()
                {
                    Name = model.Name,
                    CompanyName = model.CompanyName,
                    JobInformation = model.JobInformation,
                    Requirements = model.Requirements,
                    Appeal = model.Appeal,
                    AppUserId = appuser.Id,
                    CreateDate = DateTime.Now
                };
                vacancyService.Add(vacancy);

                return RedirectToAction("Index", "Vacancy");

            }
            return View();
        }

        public IActionResult AddOnlyLink()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddOnlyLink(VacancyOnlyLinkModel model)
        {
            if (ModelState.IsValid)
            {
                Vacancy vacancy = new()
                {
                    Name = model.Name,
                    CompanyName = model.CompanyName,
                    Appeal = model.Appeal,
                    AppUserId = appuser.Id,
                    CreateDate = DateTime.Now
                };
                vacancyService.Add(vacancy);

                return RedirectToAction("Index", "Vacancy");

            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            vacancyService.Delete(id);

            return RedirectToAction("Index", "Vacancy");
        }

        public IActionResult Update(int id)
        {
            var vacancy = vacancyService.GetById(id);

            VacancyModel model = new()
            {
                Name = vacancy.Name,
                CompanyName = vacancy.CompanyName,
                JobInformation = vacancy.JobInformation,
                Requirements = vacancy.Requirements,
                Appeal = vacancy.Appeal
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(VacancyModel model)
        {

            if (ModelState.IsValid)
            {
                Vacancy vacancy = new()
                {
                    Id = model.Id,
                    AppUserId = appuser.Id,
                    Name = model.Name,
                    CompanyName = model.CompanyName,
                    JobInformation = model.JobInformation,
                    Requirements = model.Requirements,
                    Appeal = model.Appeal,
                    CreateDate = DateTime.Now,
                };
                vacancyService.Update(vacancy);
                return RedirectToAction("Index", "Vacancy");
            }
            return View(model);
        }


        public IActionResult UpdateOnlyLink(int id)
        {
            var vacancy = vacancyService.GetById(id);

            VacancyOnlyLinkModel model = new()
            {
                Name = vacancy.Name,
                CompanyName = vacancy.CompanyName,
                Appeal = vacancy.Appeal,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateOnlyLink(VacancyOnlyLinkModel model)
        {

            if (ModelState.IsValid)
            {
                Vacancy vacancy = new()
                {
                    Id = model.Id,
                    AppUserId = appuser.Id,
                    Name = model.Name,
                    CompanyName = model.CompanyName,
                    Appeal = model.Appeal,
                    CreateDate = DateTime.Now
                };
                vacancyService.Update(vacancy);
                return RedirectToAction("Index", "Vacancy");
            }
            return View(model);
        }


    }
}
