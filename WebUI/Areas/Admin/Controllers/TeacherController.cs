using Business.Abstract;
using Business.Helper;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.Models;
using X.PagedList;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TeacherController : Controller
    {
        private readonly ITeacherService teacherService;
        protected UserManager<AppUser> userManager { get; }
        protected SignInManager<AppUser> signInManager { get; }

        public TeacherController(ITeacherService teacherService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.teacherService = teacherService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #region Index
        public IActionResult Index(int page = 1)
        {

            var teachers = teacherService.GetAllWithUser().ToPagedList(page, 20);

            teachers.Reverse();

            return View(teachers);
        }
        #endregion

        #region Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(TeacherModel model)
        {
            if (ModelState.IsValid)
            {

                if (model.Image == null)
                {
                }
                else if (model.Image.ContentType != "image/jpeg" && model.Image.ContentType != "image/png")
                {
                    ModelState.AddModelError(nameof(model.Image), "Şəkil formatını düzgün seçin");
                    return View(model);
                }

                AppUser user = new AppUser();
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var teacher = new Teacher
                    {
                        AppUserId = userManager.FindByEmailAsync(model.Email).Result.Id,
                        Name = model.Name,
                        Surname = model.Surname,
                        AcademicDegree = model.AcademicDegree,
                        Bio = model.Bio,
                        Image = SystemIOOperations.AddPhoto(model.Image, "Teacher")
                    };

                    teacherService.Add(teacher);

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
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            var teacher = teacherService.GetById(id);

            teacherService.Delete(id, teacher.Id);

            return RedirectToAction("Index");
        }

        #endregion

        #region Update
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = teacherService.GetById(id);

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
                AppUserId = value.AppUserId
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

        #endregion

        #region ChangePassword
        public IActionResult ChangePassword(int id)
        {
            ChangePasswordModel changePasswordModel = new ChangePasswordModel();
            changePasswordModel.AppUserId = id;

            return View(changePasswordModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.FindByIdAsync(changePasswordModel.AppUserId.ToString()).Result;

                var token = await userManager.GeneratePasswordResetTokenAsync(user);

                var result = await userManager.ResetPasswordAsync(user, token, changePasswordModel.NewPassword);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(changePasswordModel);
        }

        #endregion







    }
}
