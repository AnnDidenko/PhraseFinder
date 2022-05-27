using AutoMapper;
using Phrase_Finder.Application.Models;
using Phrase_Finder.Domain.Entities;

namespace Phrase_Finder.Application.Profiles
{
    public class TranslationalWordProfile: Profile
    {
        public TranslationalWordProfile()
        {
            CreateMap<TranslationalWordDto, TranslationalWord>()
                .ReverseMap();
        }
    }
}
