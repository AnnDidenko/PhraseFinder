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
    public class TranslationProfile: Profile
    {
        public TranslationProfile()
        {
            CreateMap<TranslationDto, Translation>()
                .ReverseMap();
        }
    }
}
