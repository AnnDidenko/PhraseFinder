using AutoMapper;
using Phrase_Finder.Application.Models;
using Phrase_Finder.Models;
using System.Collections.Generic;

namespace Phrase_Finder.Profiles
{
    public class VideoModelProfile : Profile
    {
        public VideoModelProfile()
        {
            CreateMap<VideoModel, VideoDto>()
                .ReverseMap();

            //CreateMap<Dictionary<VideoDto, string[]>, Dictionary<VideoModel, string[]>>();
        }
    }
}
