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

            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Notes, NoteDto>().ReverseMap();
                   

        }

    }
}
