using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phrase_Finder.Application.Infrastructure;
using Phrase_Finder.Application.Services;
using Phrase_Finder.Domain.Extensions;
using RestEase.HttpClientFactory;

namespace Phrase_Finder.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, string connectionString)
        {
            services.AddDomainServices(connectionString);

            services.AddScoped<IWordInfoService, WordInfoService>();
            services.AddScoped<IVideoScrappingService, VideoScrappingService>();
            services.AddScoped<IVideosService, VideosService>();
            services.AddRestEaseClient<IWordInfoApi>();
            services.AddRestEaseClient<ITEDApi>();

            return services;
        }
    }
}
