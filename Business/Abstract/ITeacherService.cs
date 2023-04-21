using Entity.Concrete;

namespace Business.Abstract
{
    public interface ITeacherService
    {
        List<Teacher> GetAllWithUser();
        void Add(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(int userId, int teacherId);
        Teacher GetById(int id);
        Teacher GetByAppUserId(int id);
    }
}
