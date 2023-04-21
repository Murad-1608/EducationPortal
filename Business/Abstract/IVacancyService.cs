using Entity.Concrete;

namespace Business.Abstract
{
    public interface IVacancyService
    {
        void Add(Vacancy vacancy);
        List<Vacancy> GetByAppUserId(int id);
        void Delete(int id);
        Vacancy GetById(int id);
        void Update(Vacancy vacancy);
        List<Vacancy> GetAll();
        List<Vacancy> Search(string word);

    }
}
