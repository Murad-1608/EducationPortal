using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class VacancyManager : IVacancyService
    {
        private readonly IVacancyDal vacancyDal;
        public VacancyManager(IVacancyDal vacancyDal)
        {
            this.vacancyDal = vacancyDal;
        }

        public void Add(Vacancy vacancy)
        {
            vacancyDal.Add(vacancy);
        }

        public void Delete(int id)
        {
            var vacancy = vacancyDal.Get(x => x.Id == id);

            vacancyDal.Delete(vacancy);
        }

        public Vacancy GetById(int id)
        {
            return vacancyDal.Get(x => x.Id == id);
        }

        public List<Vacancy> GetByAppUserId(int userId)
        {
            return vacancyDal.GetWithAppUser(x => x.AppUserId == userId);
        }

        public void Update(Vacancy vacancy)
        {
            vacancyDal.Update(vacancy);
        }

        public List<Vacancy> GetAll()
        {
            return vacancyDal.GetAll();
        }

        public List<Vacancy> Search(string word)
        {
            return vacancyDal.GetAll(x => x.Name.Contains(word) ||
                                          x.CompanyName.Contains(word));
        }
    }
}
