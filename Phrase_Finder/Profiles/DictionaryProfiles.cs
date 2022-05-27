using AutoMapper;
using Phrase_Finder.Application.Models;
using Phrase_Finder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phrase_Finder.Profiles
{
    public class DictionaryProfiles: Profile
    {
        public DictionaryProfiles()
        {
            CreateMap<TranslationModel, TranslationDto>();
            //.ReverseMap();
            CreateMap<TranslationDto, TranslationModel>();

            CreateMap<DictionaryModel, DictionaryDto>()
                .ReverseMap();

            CreateMap<EnglishWordModel, EnglishWordDto>()
                .ReverseMap();

            CreateMap<TranslationalWordModel, TranslationalWordDto>()
                .ReverseMap();
        }
    }
}
