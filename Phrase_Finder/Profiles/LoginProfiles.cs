using AutoMapper;
using Phrase_Finder.Application.Models;
using Phrase_Finder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phrase_Finder.Profiles
{
    public class LoginProfiles: Profile
    {
        public LoginProfiles()
        {
            CreateMap<RegistrationRequestModel, RegistrationRequestDto>();
            CreateMap<LoginRequestModel, LoginRequestDto>();
            CreateMap<LoginRequestModel, RegistrationRequestDto>();
        }
    }
}
