using Business.Abstract;
using Business.Helper;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata;

namespace Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        UserManager<AppUser> userManager;
        private readonly ITeacherDal teacherDal;
        public TeacherManager(ITeacherDal teacherDal, UserManager<AppUser> userManager)
        {
            this.teacherDal = teacherDal;
            this.userManager = userManager;
        }

        public void Add(Teacher teacher)
        {
            teacherDal.Add(teacher);
        }

        public List<Teacher> GetAllWithUser()
        {
            return teacherDal.GetAllWithUser();
        }

        public void Delete(int userId, int teacherId)
        {
            var user = userManager.FindByIdAsync(userId.ToString()).Result;

            var teacher = teacherDal.Get(x => x.Id == teacherId);

            SystemIOOperations.DeletePhoto("Teacher", teacher.Image);

            userManager.DeleteAsync(user);
        }

        public Teacher GetById(int id)
        {
            return teacherDal.GetByUserId(id);
        }

        public void Update(Teacher teacher)
        {
            teacherDal.Update(teacher);
        }

        public Teacher GetByAppUserId(int id)
        {
            return teacherDal.GetAllWithUser(x => x.AppUserId == id).FirstOrDefault();
        }
    }
}
