using AutoMapper;
using Phrase_Finder.Application.Models;

namespace Phrase_Finder.Profiles
{
    public class VideoModelProfile : Profile
    {
        public VideoModelProfile()
        {
            CreateMap<VideoModelProfile, VideoDto>()
                .ReverseMap();
        }
    }
}
