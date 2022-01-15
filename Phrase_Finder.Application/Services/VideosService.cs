using AutoMapper;
using Phrase_Finder.Application.Infrastructure;
using Phrase_Finder.Application.Models;
using Phrase_Finder.Domain.Entities;
using Phrase_Finder.Domain.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phrase_Finder.Application.Services
{
    public class VideosService : IVideosService
    {
        private IVideosRepository _videosRepository;
        private IMapper _mapper;

        public VideosService(IVideosRepository videosRepository,
                             IMapper mapper)
        {
            _videosRepository = videosRepository;
            _mapper = mapper;
        }

        public async Task AddVideo(VideoDto videoDto)
        {
            Video video = _mapper.Map<VideoDto, Video>(videoDto);
            await _videosRepository.AddVideo(video);
        }

        public void DeleteVideo(VideoDto videoDto)
        {
            Video video = _mapper.Map<VideoDto, Video>(videoDto);
            _videosRepository.DeleteVideo(video);
        }

        public IEnumerable<VideoDto> GetVideos()
        {
            List<Video> videos = _videosRepository.GetAllVideos()
                                                  .ToList();

            return _mapper.Map<IEnumerable<Video>, IEnumerable<VideoDto>>(videos);
        }

        public void UpdateVideo(VideoDto videoDto)
        {
            Video video = _mapper.Map<VideoDto, Video>(videoDto);
            _videosRepository.UpdateVideo(video);
        }
    }
}
