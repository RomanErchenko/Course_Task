using AutoMapper;
using DayaAcces.Model;
using kurs2_bloknot.Models;
using Service_Layer.Model;

namespace kurs2_bloknot.Mapper
{
    public class Profimap:Profile
    {
        public Profimap()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, UserCreated>().ReverseMap();

            CreateMap<Notes, NoteDto>().ReverseMap();
            CreateMap<LoginBindingModel, LoginServiceModel>().ReverseMap()
             .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Email))
             .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
            CreateMap<NotesCreated, NoteDto>().ReverseMap();

            CreateMap<NoteDto, NotesView>().ReverseMap();
            

        }
    }
}
