using AutoMapper;
using DayaAcces.Model;
using Service_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Profimap
{
    public class MapProfile:Profile
    {

        public MapProfile() 
        {
            CreateMap<UserDto, User>()
                   .ForMember(d => d.Id, map => map.MapFrom(s => s.Id))
                   .ForMember(d => d.Name, map => map.MapFrom(s => s.Name))
                   .ForMember(d => d.Login, map => map.MapFrom(s => s.Login))
                    .ForMember(d => d.Password, map => map.MapFrom(s => s.Password));


            CreateMap<User, UserDto>()
                  .ForMember(d => d.Id, map => map.MapFrom(s => s.Id))
                  .ForMember(d => d.Name, map => map.MapFrom(s => s.Name))
                  .ForMember(d => d.Login, map => map.MapFrom(s => s.Login))
                   .ForMember(d => d.Password, map => map.MapFrom(s => s.Password));


            CreateMap<NoteDto, Notes>()
                   .ForMember(d => d.Id, map => map.MapFrom(s => s.Id))
                   .ForMember(d => d.Info, map => map.MapFrom(s => s.Info))
                   .ForMember(d => d.Date, map => map.MapFrom(s => s.Date))
                    .ForMember(d => d.UserId, map => map.MapFrom(s => s.UserId));



            CreateMap<Notes, NoteDto>()
                   .ForMember(d => d.Id, map => map.MapFrom(s => s.Id))
                   .ForMember(d => d.Info, map => map.MapFrom(s => s.Info))
                   .ForMember(d => d.Date, map => map.MapFrom(s => s.Date))
                    .ForMember(d => d.UserId, map => map.MapFrom(s => s.UserId));

        }

    }
}
