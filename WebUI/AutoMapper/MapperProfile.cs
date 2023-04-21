using AutoMapper;
using Entity.Concrete;
using WebUI.Areas.Admin.Models;

namespace WebUI.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TeacherModel, Teacher>();
            CreateMap<Teacher, TeacherModel>();
        }
    }
}
