using AutoMapper;
using Phrase_Finder.Application.Models;
using Phrase_Finder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phrase_Finder.Application.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>()
                .ReverseMap();

            CreateMap<RegistrationRequestDto, User>()
                .ForMember(x => x.Role, opt => opt.MapFrom(y => "User"))
                .ForMember(x => x.Login, opt => opt.MapFrom(y => y.Username));
        }
    }
}
