using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace WebUI.Controllers
{
    public class VacancyController : Controller
    {
        IVacancyService vacancyService;
        public VacancyController(IVacancyService vacancyService)
        {
            this.vacancyService = vacancyService;
        }

        public IActionResult Index(int page = 1)
        {

            var vacancy = vacancyService.GetAll();

            ViewBag.VacanciesCount = vacancy.Count;

            vacancy.Reverse();

            var pagedList = vacancy.ToPagedList(page, 6);

            return View(pagedList);
        }

        public IActionResult Detail(int id)
        {
            var vacancy = vacancyService.GetById(id);
            return View(vacancy);
        }

        public IActionResult Search(string word)
        {
            var vacancy = vacancyService.Search(word).ToPagedList(1, 6);
            vacancy.Reverse();

            ViewBag.VacanciesCount = vacancyService.Search(word).Count;

            return View(vacancy);
        }
    }
}
