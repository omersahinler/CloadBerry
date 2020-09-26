using AutoMapper;
using CloadBerry.Models;
using CloadBerry.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloadBerry
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CurrentUserDTO, User>();
            CreateMap<User, CurrentUserDTO > ();
            CreateMap<LoginDTO, User>();
            CreateMap<User, LoginDTO>();
            CreateMap<UserRegisterDTO, User>();
            CreateMap<User, UserRegisterDTO>();

        }
    }
}
