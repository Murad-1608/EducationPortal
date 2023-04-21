using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TeacherManager>().As<ITeacherService>().SingleInstance();
            builder.RegisterType<TeacherDal>().As<ITeacherDal>().SingleInstance();

            builder.RegisterType<BookManager>().As<IBookService>().SingleInstance();
            builder.RegisterType<BookDal>().As<IBookDal>().SingleInstance();

            builder.RegisterType<VacancyManager>().As<IVacancyService>().SingleInstance();
            builder.RegisterType<VacancyDal>().As<IVacancyDal>().SingleInstance();

            builder.RegisterType<AnnouncementManager>().As<IAnnouncementService>().SingleInstance();
            builder.RegisterType<AnnouncementDal>().As<IAnnouncementDal>().SingleInstance();

        }
    }
}
