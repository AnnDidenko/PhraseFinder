using HtmlAgilityPack;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Phrase_Finder.Application.Infrastructure;
using Phrase_Finder.Application.Models;
using RestEase;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Phrase_Finder.Jobs
{
    public class VideoScrappingHostedService : BackgroundService
    {
        private IServiceProvider Services { get; }
        private IVideoScrappingService _videoScrappingService;
        private IVideosService _videosService;
        private List<VideoDto> AddedVideos { get; set; }


        public VideoScrappingHostedService(IServiceProvider services)
        {
            Services = services;
        }

        private async Task InitializeVideoData(VideoDto video, string TEDVideoLink)
        {
            HtmlDocument videoHtml = await _videoScrappingService.GetVideoTranscriptHtml(TEDVideoLink, "en");

            video.Name = _videoScrappingService.GetVideoName(videoHtml);
            video.Subtitles = _videoScrappingService.GetVideoSubtitles(videoHtml);
            video.YouTubeVideoId = _videoScrappingService.GetYoutubeVideoId(videoHtml);
        }

        public async Task UpdateVideosWithoutYoutubeLinks()
        {
            List<VideoDto> videosWithoutYoutubeLinks = AddedVideos
                                                            .Where(video => video.YouTubeVideoId == null)
                                                            .ToList();

            for(int i = 0; i < videosWithoutYoutubeLinks.Count; i++)
            {
                try
                {
                    await InitializeVideoData(videosWithoutYoutubeLinks[i], videosWithoutYoutubeLinks[i].Url);
                    _videosService.UpdateVideo(videosWithoutYoutubeLinks[i]);
                }
                catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    Log.Warning("Video with url {path} doesn't have any subtitles", videosWithoutYoutubeLinks[i]);
                }
            }
        }

        public async Task AddNewVideosInfo()
        {
            int numberOfPages = await _videoScrappingService.GetPageCount(1);

            for (int i = 1; i <= numberOfPages; i++)
            {
                List<string> listOfTEDVideoLinks = await _videoScrappingService.GetVideoLinks(i);

                for (int k = 0; k < listOfTEDVideoLinks.Count; k++)
                {
                    if (!AddedVideos.Exists(video => video.Url == listOfTEDVideoLinks[k]))
                    {
                        VideoDto video = new VideoDto();
                        video.Url = listOfTEDVideoLinks[k];

                        try
                        {
                            await InitializeVideoData(video, listOfTEDVideoLinks[k]);

                            await _videosService.AddVideo(video);
                        }
                        catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
                        {
                            Log.Warning("Video with url {path} doesn't have any subtitles", listOfTEDVideoLinks[k]);
                            await _videosService.AddVideo(video);
                        }
                    }
                }
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                DateTime currentDate = DateTime.Now;
                Log.Information("Start scrapping of TED videos at {currentDate}", currentDate);

                try
                {
                    using (var scope = Services.CreateScope())
                    {
                        _videoScrappingService =
                            scope.ServiceProvider
                                .GetRequiredService<IVideoScrappingService>();

                        _videosService =
                            scope.ServiceProvider
                                .GetRequiredService<IVideosService>();

                        AddedVideos = _videosService.GetVideos().ToList();

                        await UpdateVideosWithoutYoutubeLinks();
                        await AddNewVideosInfo();
                    }

                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                }

                await Task.Delay(new TimeSpan(0, 0, 1, 0));
            }
            Log.Information("Scrapping of TED videos is ended");
        }
    }
}
