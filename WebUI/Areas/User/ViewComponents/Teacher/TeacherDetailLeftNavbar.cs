using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models.ViewModels;

namespace WebUI.ViewComponents.Teacher
{
    public class TeacherDetailLeftNavbar : ViewComponent
    {
        UserManager<AppUser> userManager { get; }
        ITeacherService teacherService;
        public TeacherDetailLeftNavbar(UserManager<AppUser> userManager, ITeacherService teacherService)
        {
            this.userManager = userManager;
            this.teacherService = teacherService;
        }

        public IViewComponentResult Invoke()
        {
            LeftNavbarViewModel viewModel = new LeftNavbarViewModel();
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;

            viewModel.Teacher = teacherService.GetById(user.Id);

            return View(viewModel);
        }
    }
}
