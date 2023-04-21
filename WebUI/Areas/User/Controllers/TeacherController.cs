using Business.Abstract;
using Business.Helper;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.User.Models;

namespace WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class TeacherController : BaseController
    {
        private readonly ITeacherService teacherService;
        public TeacherController(ITeacherService teacherService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(userManager, signInManager)
        {
            this.teacherService = teacherService;
        }
        public IActionResult Index()
        {
            var id = appuser.Id;

            var value = teacherService.GetByAppUserId(id);

            TeacherModel model = new()
            {
                Name = value.Name,
                UserName = value.AppUser.UserName,
                Surname = value.Surname,
                Bio = value.Bio,
                AcademicDegree = value.AcademicDegree,
                Email = value.AppUser.Email,
                Password = value.AppUser.PasswordHash,
                ImageString = value.Image,
                PhoneNumber = value.AppUser.PhoneNumber,
                AppUserId = id
            };


            return View(model);
        }

        [HttpPost]
        public IActionResult Update(TeacherModel model)
        {


            Teacher teacher = teacherService.GetById(Convert.ToInt32(model.AppUserId));
            if (ModelState.IsValid)
            {
                if (model.Image == null)
                {
                    SystemIOOperations.DeletePhoto("Teacher", model.ImageString);

                    teacher.Image = model.ImageString;
                }
                else if (model.Image.ContentType != "image/jpeg" && model.Image.ContentType != "image/png")
                {
                    ModelState.AddModelError(nameof(model.Image), "Şəkil formatını düzgün seçin");
                    return View(model);
                }
                else if (model.Image.ContentType == "image/jpeg" || model.Image.ContentType == "image/png")
                {
                    SystemIOOperations.DeletePhoto("User", model.ImageString);

                    teacher.Image = SystemIOOperations.AddPhoto(model.Image, "Teacher");
                }

                AppUser user = userManager.FindByIdAsync(teacher.AppUserId.ToString()).Result;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                IdentityResult result = userManager.UpdateAsync(user).Result;
                if (result.Succeeded)
                {

                    teacher.AppUserId = userManager.FindByEmailAsync(model.Email).Result.Id;
                    teacher.Name = model.Name;
                    teacher.Surname = model.Surname;
                    teacher.AcademicDegree = model.AcademicDegree;
                    teacher.Bio = model.Bio;

                    teacherService.Update(teacher);

                    return RedirectToAction("Index", "Teacher");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(nameof(item), item.Description);
                    }
                }
            }
            return View(model);

        }


        public IActionResult ChangePassword()
        {
            ViewBag.Success = 0;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {

            if (ModelState.IsValid)
            {
                bool check = userManager.CheckPasswordAsync(appuser, model.Password).Result;

                if (check)
                {
                    IdentityResult result = userManager.ChangePasswordAsync(appuser, model.Password, model.NewPassword).Result;

                    if (result.Succeeded)
                    {
                        ViewBag.Success = 1;
                        return View();
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(nameof(model.Password), "Mövcud parol yanlışdır");
                }
            }
            return View(model);
        }
    }
}
