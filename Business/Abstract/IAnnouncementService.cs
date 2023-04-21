using Entity.Concrete;

namespace Business.Abstract
{
    public interface IAnnouncementService
    {
        List<Announcement> GetByAppuserId(int userId);
        void Add(Announcement announcement);
        void Delete(int id);
        void Update(Announcement announcement);
        Announcement GetById(int id);
        List<Announcement> GetAll();
        List<Announcement> Search(string word);
        
    }
}
