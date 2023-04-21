using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace WebUI.Controllers
{
    public class TeacherController : Controller
    {
        ITeacherService teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        public IActionResult Index(int page = 1)
        {
            var teacher = teacherService.GetAllWithUser().ToPagedList(page, 4);

            ViewBag.TeachersCount = teacherService.GetAllWithUser().Count;

            teacher.Reverse();

            return View(teacher);
        }
    }
}
