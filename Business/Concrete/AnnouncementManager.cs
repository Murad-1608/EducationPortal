using Business.Abstract;
using Business.Helper;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal AnnouncementDal;
        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            AnnouncementDal = announcementDal;
        }

        public void Add(Announcement announcement)
        {
            AnnouncementDal.Add(announcement);
        }

        public void Delete(int id)
        {
            var value = AnnouncementDal.Get(x => x.Id == id);

            SystemIOOperations.DeletePhoto("Announcement", value.Image);

            AnnouncementDal.Delete(value);
        }

        public List<Announcement> GetAll()
        {
            return AnnouncementDal.GetAll();
        }

        public List<Announcement> GetByAppuserId(int userId)
        {
            return AnnouncementDal.GetWithAppUser(x => x.AppUserId == userId);
        }

        public Announcement GetById(int id)
        {
            return AnnouncementDal.Get(x => x.Id == id);
        }

        public List<Announcement> Search(string word)
        {
            return AnnouncementDal.GetAll(x => x.Title.Contains(word) ||
                                               x.Content.Contains(word));
        }

        public void Update(Announcement announcement)
        {
            AnnouncementDal.Update(announcement);
        }
    }
}
