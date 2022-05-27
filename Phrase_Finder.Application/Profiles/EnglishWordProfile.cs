using AutoMapper;
using Phrase_Finder.Application.Models;
using Phrase_Finder.Domain.Entities;

namespace Phrase_Finder.Application.Profiles
{
    public class EnglishWordProfile: Profile
    {
        public EnglishWordProfile()
        {
            CreateMap<EnglishWordDto, EnglishWord>()
                .ReverseMap();
        }
    }
}
